using Microsoft.DirectX.DirectSound;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainForm : Form
    {
        private readonly GameField gameField;
        private readonly TetrisField nextTetromino;
        private TetrisGame tetrisGame;

        private NewRecord newRecordDialog;
        private RankingList rankingList;

        private Image imgPaused, imgGameOver;

        private bool sound = true;

        //提供声音支持
        #region
        //MediaPlayer不支持多线程
        private readonly SoundPlayer backgroundPlayer = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("Background"));
        private Thread musicThread;
        //directX支持多线程，可同时播放多个音效
        private SecondaryBuffer secBuffer;//缓冲区对象    
        readonly Device secDev;//设备对象    
        #endregion

        public MainForm()
        {
            //新建背景音乐线程，循环播放
            musicThread = new Thread(new ThreadStart(delegate { backgroundPlayer.PlayLooping(); }));

            //初始化TetrisGame对象
            tetrisGame = new TetrisGame
            {
                Score = 0,
                GameOver = true
            };

            //加载存档
            Saver.Load();

            //初始化游戏区域，20×15
            gameField = new GameField(20, 15);

            //初始化“下一个”区域
            nextTetromino = new TetrisField(4, 4);
            //边界（指示器）颜色默认
            nextTetromino.BorderColor = nextTetromino.BackColor;

            //产生随机块
            Random rnd = new Random();

            for (int row = 0; row < gameField.TilesHeight; row++)
            {
                for (int col = 0; col < gameField.TilesWidth; col++)
                {
                    TileType t = (TileType)rnd.Next(0, 7);
                    gameField.SetCell(row, col, t);
                }
            }

            //注册游戏状态变化事件
            tetrisGame.StateChanged += new EventHandler(Game_StateChanged);

            InitializeComponent();

            //初始化声音设备，！当找不到声音设备时将报错！
            secDev = new Device();
            secDev.SetCooperativeLevel(this, CooperativeLevel.Normal);//设置设备协作级别    

            //启动背景音乐播放线程
            musicThread.Start();
        }

        private void Game_StateChanged(object sender, EventArgs e)
        {
            //记录游戏数据
            lblScore.Text = tetrisGame.Score.ToString();
            lblDropped.Text = tetrisGame.TetrominosDropped.ToString();
            lblTime.Text = (DateTime.Now - tetrisGame.GameStarted).ToString(@"mm\:ss");
            Refresh();
        }

        private void SetScore(int nscore)
        {
            tetrisGame.Score = nscore;
        }

        private void NewGame()
        {
            tetrisGame = new TetrisGame();
            tetrisGame.StateChanged += new EventHandler(Game_StateChanged);
            SetScore(0);

            tmrGame.Interval = 1000;
            tmrGame.Enabled = true;

            tetrisGame.NextTetromino = Tetromino.RandomTetromino();

            gameField.Clear();

            Refresh();
        }

        private void SetPause(bool enable)
        {
            if (tetrisGame.GameOver) return;
            tetrisGame.Paused = enable;

            tmrGame.Enabled = !enable;

            //Refresh();
        }

        private void OnGameOver()
        {
            tetrisGame.Over();
            tmrGame.Enabled = false;

            TetrisSave test = new TetrisSave("---", tetrisGame.Score, DateTime.Now - tetrisGame.GameStarted);

            //判断是否可以上榜
            if (Saver.highScores.CanAdd(test) || Saver.highTimes.CanAdd(test))
            {
                newRecordDialog = new NewRecord();
                if (newRecordDialog.ShowDialog() == DialogResult.OK)
                {
                    //存档
                    test.UserName = newRecordDialog.UserName;
                    Saver.Save(test);

                    //打开排行榜
                    rankingList = new RankingList(test);
                    if (rankingList.ShowDialog() == DialogResult.OK) NewGame();
                }
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                TetrisField.Blue = Properties.Resources.blue;
                TetrisField.Red = Properties.Resources.red;
                TetrisField.Green = Properties.Resources.green;
                TetrisField.LightBlue = Properties.Resources.lightblue;
                TetrisField.Purple = Properties.Resources.purple;
                TetrisField.Yellow = Properties.Resources.yellow;
                TetrisField.Orange = Properties.Resources.orange;

                imgPaused = Properties.Resources.pause;
                imgGameOver = Properties.Resources.gameover;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "加载图像出错！");
            }
        }

        private void TmrGame_Tick(object sender, EventArgs e)
        {
            //游戏暂停则跳过
            if (tetrisGame.Paused) return;

            gameField.DoStep();

            if (!gameField.IsTetrominoFalling)
            {
                //清除满行
                int removeRows = gameField.RemoveFullRows();
                SetScore(tetrisGame.Score + removeRows * 10);
                if (removeRows != 0 && sound)
                {
                    secBuffer = new SecondaryBuffer(Properties.Resources.clear, secDev);//创建辅助缓冲区    
                    secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
                }

                if (!gameField.PlaceTetromino(tetrisGame.NextTetromino))
                {
                    OnGameOver();
                }
                else
                {
                    tetrisGame.NextTetromino = Tetromino.RandomTetromino();
                    tetrisGame.TetrominosDropped++;
                    lblDropped.Text = tetrisGame.TetrominosDropped.ToString();
                    nextTetromino.Clear();
                    nextTetromino.DrawTetromino(tetrisGame.NextTetromino.MoveTo(1, 1), false);

                    //交换tetromino的冷却
                    if (tetrisGame.TetrominoChanged && tetrisGame.TetrominosDropped % 5 == 0) tetrisGame.TetrominoChanged = false;

                    //游戏加速
                    if (tetrisGame.TetrominosDropped % 15 == 0 && tetrisGame.Score != 0 && tmrGame.Interval > 300)
                        tmrGame.Interval -= 100;

                    ShowTips();
                }
            }
            lblTime.Text = (DateTime.Now - tetrisGame.GameStarted).ToString(@"mm\:ss");

            Refresh();
        }

        private static readonly string[] tips = new string[]
        {
            "当\"下一个\"周围的指示器消失时，可以推迟当前图形",
            "按Q键将当前图形与\"下一个\"交换",
            "随着交换的图形数量的增加，游戏的速度将不断提高",
            "要进入排行榜，您必须得分较高，或在游戏中停留的时间较长",
            "按F3暂停游戏",
            "新游戏？按F2立即开始！"
        };
        private void ShowTips(int advice)
        {
            lblTip.Text = tips[advice];
        }
        private void ShowTips()
        {
            ShowTips(new Random().Next(1, tips.Length));
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (tetrisGame.GameOver || tetrisGame.Paused) return;

            if (e.KeyData == Keys.Left || e.KeyData == Keys.A)
            {
                gameField.Move(Direction.Left);
                if (sound)
                {
                    secBuffer = new SecondaryBuffer(Properties.Resources.move, secDev);//创建辅助缓冲区    
                    secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
                }
            }
            if (e.KeyData == Keys.Right || e.KeyData == Keys.D)
            {
                gameField.Move(Direction.Right);
                if (sound)
                {
                    secBuffer = new SecondaryBuffer(Properties.Resources.move, secDev);//创建辅助缓冲区    
                    secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
                }
            }
            if (e.KeyData == Keys.Up || e.KeyData == Keys.W)
            {
                if (gameField.Drop())
                {
                    SetScore(tetrisGame.Score + 5);
                    if (sound)
                    {
                        secBuffer = new SecondaryBuffer(Properties.Resources.collided, secDev);//创建辅助缓冲区    
                        secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
                    }
                }
            }
            if (e.KeyData == Keys.Down || e.KeyData == Keys.S)
            {
                if (gameField.Move(Direction.Down))
                {
                    SetScore(tetrisGame.Score + 1);
                    if (sound)
                    {
                        secBuffer = new SecondaryBuffer(Properties.Resources.down, secDev);//创建辅助缓冲区    
                        secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
                    }
                }
            }
            if (e.KeyData == Keys.Space)
            {
                gameField.RotateTetromino();
                if (sound)
                {
                    secBuffer = new SecondaryBuffer(Properties.Resources.rotate, secDev);//创建辅助缓冲区    
                    secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
                }
            }

            if (e.KeyData == Keys.Q)
            {
                if (!tetrisGame.TetrominoChanged && gameField.IsTetrominoFalling)
                {
                    tetrisGame.NextTetromino = new Tetromino(gameField.ChangeTetromino(tetrisGame.NextTetromino).Type);
                    nextTetromino.Clear();
                    nextTetromino.DrawTetromino(tetrisGame.NextTetromino.MoveTo(1, 1), false);
                    tetrisGame.TetrominoChanged = true;
                    if (sound)
                    {
                        secBuffer = new SecondaryBuffer(Properties.Resources.exchange, secDev);//创建辅助缓冲区    
                        secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
                    }
                    if (tetrisGame.NextTetromino == Tetromino.Zero)
                        OnGameOver();
                }
                if (tetrisGame.TetrominoChanged)
                {
                    ShowTips(0);
                }
            }
            Refresh();
        }

        private void PicGameField_Paint(object sender, PaintEventArgs e)
        {
            gameField.Paint(e.Graphics);

            if (tetrisGame.Paused)
            {
                Rectangle img = new Rectangle((picGameField.Width - imgPaused.Width) / 2,
                                            (picGameField.Height - imgPaused.Height) / 2,
                                            imgPaused.Width, imgPaused.Height);
                e.Graphics.DrawImage(imgPaused, img);
                return;
            }
            if (tetrisGame.GameOver)
            {
                Rectangle img = new Rectangle((picGameField.Width - imgGameOver.Width) / 2,
                                            (picGameField.Height - imgGameOver.Height) / 2,
                                            imgGameOver.Width, imgGameOver.Height);
                e.Graphics.DrawImage(imgGameOver, img);
            }
        }

        private void PicNextTetromido_Paint(object sender, PaintEventArgs e)
        {
            nextTetromino.BorderColor = tetrisGame.TetrominoChanged ? Color.FromArgb(160, 128, 128) : nextTetromino.BackColor;
            nextTetromino.Paint(e.Graphics);
        }

        private void ChkIsProjectEnabled_CheckedChanged(object sender, EventArgs e)
        {
            gameField.ProjectEnabled = chkIsProjectEnabled.Checked;
        }

        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void 暂停继续ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPause(!tetrisGame.Paused);
        }

        private void 排行榜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rankingList = new RankingList(new TetrisSave());
            if (rankingList.ShowDialog() == DialogResult.OK)
            {
                if (tetrisGame.GameOver) NewGame();
                if (tetrisGame.Paused) SetPause(!tetrisGame.Paused);
            }
        }

        private void 静音ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            sound = !sound;
            if (sound)
            {
                musicThread = new Thread(new ThreadStart(delegate { backgroundPlayer.PlayLooping(); }));
                musicThread.Start();
            }
            else
            {
                backgroundPlayer.Stop();
                musicThread.Abort();
            }
        }

        private void 静音ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            静音ToolStripMenuItem.Checked = !静音ToolStripMenuItem.Checked;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
}
