using System;

namespace Tetris
{
    public class TetrisGame
    {
        public Tetromino NextTetromino;

        private int score;
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnStateChanged();
            }
        }

        private int tetrominosDropped;
        public int TetrominosDropped
        {
            get { return tetrominosDropped; }
            set
            {
                tetrominosDropped = value;
                OnStateChanged();
            }
        }

        private bool gameOver, paused, tetrominoChanged;
        public bool GameOver
        {
            get { return gameOver; }
            set
            {
                gameOver = value;
                OnStateChanged();
            }
        }
        public bool Paused
        {
            get { return paused; }
            set
            {
                //游戏暂停
                if (!paused && value)
                {
                    GamePaused = DateTime.Now;
                    paused = value;
                    OnStateChanged();
                }
                //游戏继续
                if (paused && !value)
                {
                    GameStarted = GameStarted + (DateTime.Now - GamePaused);
                    paused = value;
                    OnStateChanged();
                }
            }
        }
        public bool TetrominoChanged
        {
            get { return tetrominoChanged; }
            set
            {
                tetrominoChanged = value;
                OnStateChanged();
            }
        }

        public DateTime GameStarted, GamePaused;

        public TetrisGame()
        {
            Score = 0;
            TetrominosDropped = 0;
            NextTetromino = Tetromino.RandomTetromino();
            GameOver = Paused = TetrominoChanged = false;
            GameStarted = DateTime.Now;
        }

        public void Over()
        { 
            GameOver = true; 
        }

        public event EventHandler StateChanged;
        protected virtual void OnStateChanged()
        {
            StateChanged?.Invoke(this, new EventArgs());
        }
    }
}