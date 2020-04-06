namespace Tetris
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停继续ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.静音ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxStatistics = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblDropped = new System.Windows.Forms.Label();
            this.lblTimeRecord = new System.Windows.Forms.Label();
            this.lblScoreRecord = new System.Windows.Forms.Label();
            this.lblDroppedRecord = new System.Windows.Forms.Label();
            this.gbxNext = new System.Windows.Forms.GroupBox();
            this.picNextTetromido = new System.Windows.Forms.PictureBox();
            this.chkIsProjectEnabled = new System.Windows.Forms.CheckBox();
            this.gbxTips = new System.Windows.Forms.GroupBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.picGameField = new System.Windows.Forms.PictureBox();
            this.msMain.SuspendLayout();
            this.gbxStatistics.SuspendLayout();
            this.gbxNext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNextTetromido)).BeginInit();
            this.gbxTips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGameField)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(484, 28);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "菜单";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.暂停继续ToolStripMenuItem,
            this.静音ToolStripMenuItem,
            this.toolStripSeparator1,
            this.排行榜ToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.新游戏ToolStripMenuItem.Text = "新游戏";
            this.新游戏ToolStripMenuItem.Click += new System.EventHandler(this.新游戏ToolStripMenuItem_Click);
            // 
            // 暂停继续ToolStripMenuItem
            // 
            this.暂停继续ToolStripMenuItem.AutoSize = false;
            this.暂停继续ToolStripMenuItem.Name = "暂停继续ToolStripMenuItem";
            this.暂停继续ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.暂停继续ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.暂停继续ToolStripMenuItem.Text = "暂停/继续";
            this.暂停继续ToolStripMenuItem.Click += new System.EventHandler(this.暂停继续ToolStripMenuItem_Click);
            // 
            // 静音ToolStripMenuItem
            // 
            this.静音ToolStripMenuItem.Name = "静音ToolStripMenuItem";
            this.静音ToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.静音ToolStripMenuItem.Text = "静音";
            this.静音ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.静音ToolStripMenuItem_CheckedChanged);
            this.静音ToolStripMenuItem.Click += new System.EventHandler(this.静音ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // 排行榜ToolStripMenuItem
            // 
            this.排行榜ToolStripMenuItem.Name = "排行榜ToolStripMenuItem";
            this.排行榜ToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.排行榜ToolStripMenuItem.Text = "排行榜";
            this.排行榜ToolStripMenuItem.Click += new System.EventHandler(this.排行榜ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // gbxStatistics
            // 
            this.gbxStatistics.Controls.Add(this.lblTime);
            this.gbxStatistics.Controls.Add(this.lblScore);
            this.gbxStatistics.Controls.Add(this.lblDropped);
            this.gbxStatistics.Controls.Add(this.lblTimeRecord);
            this.gbxStatistics.Controls.Add(this.lblScoreRecord);
            this.gbxStatistics.Controls.Add(this.lblDroppedRecord);
            this.gbxStatistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxStatistics.Location = new System.Drawing.Point(12, 31);
            this.gbxStatistics.Name = "gbxStatistics";
            this.gbxStatistics.Size = new System.Drawing.Size(150, 110);
            this.gbxStatistics.TabIndex = 1;
            this.gbxStatistics.TabStop = false;
            this.gbxStatistics.Text = "统计";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(89, 75);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(55, 25);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "7:21";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScore.Location = new System.Drawing.Point(89, 50);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(55, 25);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDropped
            // 
            this.lblDropped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDropped.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDropped.Location = new System.Drawing.Point(89, 25);
            this.lblDropped.Name = "lblDropped";
            this.lblDropped.Size = new System.Drawing.Size(55, 25);
            this.lblDropped.TabIndex = 3;
            this.lblDropped.Text = "296";
            this.lblDropped.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeRecord
            // 
            this.lblTimeRecord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimeRecord.Location = new System.Drawing.Point(6, 75);
            this.lblTimeRecord.Name = "lblTimeRecord";
            this.lblTimeRecord.Size = new System.Drawing.Size(75, 25);
            this.lblTimeRecord.TabIndex = 2;
            this.lblTimeRecord.Text = "时长：";
            this.lblTimeRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScoreRecord
            // 
            this.lblScoreRecord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScoreRecord.Location = new System.Drawing.Point(6, 50);
            this.lblScoreRecord.Name = "lblScoreRecord";
            this.lblScoreRecord.Size = new System.Drawing.Size(75, 25);
            this.lblScoreRecord.TabIndex = 1;
            this.lblScoreRecord.Text = "得分：";
            this.lblScoreRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDroppedRecord
            // 
            this.lblDroppedRecord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDroppedRecord.Location = new System.Drawing.Point(6, 25);
            this.lblDroppedRecord.Name = "lblDroppedRecord";
            this.lblDroppedRecord.Size = new System.Drawing.Size(75, 25);
            this.lblDroppedRecord.TabIndex = 0;
            this.lblDroppedRecord.Text = "已落下：";
            this.lblDroppedRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbxNext
            // 
            this.gbxNext.Controls.Add(this.picNextTetromido);
            this.gbxNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxNext.Location = new System.Drawing.Point(12, 147);
            this.gbxNext.Name = "gbxNext";
            this.gbxNext.Size = new System.Drawing.Size(150, 134);
            this.gbxNext.TabIndex = 6;
            this.gbxNext.TabStop = false;
            this.gbxNext.Text = "下一个";
            // 
            // picNextTetromido
            // 
            this.picNextTetromido.Location = new System.Drawing.Point(31, 28);
            this.picNextTetromido.Name = "picNextTetromido";
            this.picNextTetromido.Size = new System.Drawing.Size(88, 88);
            this.picNextTetromido.TabIndex = 0;
            this.picNextTetromido.TabStop = false;
            this.picNextTetromido.Paint += new System.Windows.Forms.PaintEventHandler(this.PicNextTetromido_Paint);
            // 
            // chkIsProjectEnabled
            // 
            this.chkIsProjectEnabled.AutoSize = true;
            this.chkIsProjectEnabled.Checked = true;
            this.chkIsProjectEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsProjectEnabled.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsProjectEnabled.Location = new System.Drawing.Point(12, 287);
            this.chkIsProjectEnabled.Name = "chkIsProjectEnabled";
            this.chkIsProjectEnabled.Size = new System.Drawing.Size(84, 24);
            this.chkIsProjectEnabled.TabIndex = 7;
            this.chkIsProjectEnabled.Text = "下落投影";
            this.chkIsProjectEnabled.UseVisualStyleBackColor = true;
            this.chkIsProjectEnabled.CheckedChanged += new System.EventHandler(this.ChkIsProjectEnabled_CheckedChanged);
            // 
            // gbxTips
            // 
            this.gbxTips.Controls.Add(this.lblTip);
            this.gbxTips.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxTips.Location = new System.Drawing.Point(12, 317);
            this.gbxTips.Name = "gbxTips";
            this.gbxTips.Size = new System.Drawing.Size(150, 124);
            this.gbxTips.TabIndex = 7;
            this.gbxTips.TabStop = false;
            this.gbxTips.Text = "提示";
            // 
            // lblTip
            // 
            this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.Location = new System.Drawing.Point(6, 25);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(138, 92);
            this.lblTip.TabIndex = 0;
            this.lblTip.Text = "按Q将当前图块与“下一个”交换";
            // 
            // tmrGame
            // 
            this.tmrGame.Tick += new System.EventHandler(this.TmrGame_Tick);
            // 
            // picGameField
            // 
            this.picGameField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picGameField.BackColor = System.Drawing.Color.White;
            this.picGameField.Location = new System.Drawing.Point(167, 31);
            this.picGameField.Name = "picGameField";
            this.picGameField.Size = new System.Drawing.Size(310, 410);
            this.picGameField.TabIndex = 8;
            this.picGameField.TabStop = false;
            this.picGameField.Paint += new System.Windows.Forms.PaintEventHandler(this.PicGameField_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(484, 451);
            this.Controls.Add(this.gbxTips);
            this.Controls.Add(this.chkIsProjectEnabled);
            this.Controls.Add(this.gbxNext);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.gbxStatistics);
            this.Controls.Add(this.picGameField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "俄罗斯方块";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbxStatistics.ResumeLayout(false);
            this.gbxNext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNextTetromido)).EndInit();
            this.gbxTips.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.GroupBox gbxStatistics;
        private System.Windows.Forms.Label lblTimeRecord;
        private System.Windows.Forms.Label lblScoreRecord;
        private System.Windows.Forms.Label lblDroppedRecord;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停继续ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 静音ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 排行榜ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblDropped;
        private System.Windows.Forms.GroupBox gbxNext;
        private System.Windows.Forms.PictureBox picNextTetromido;
        private System.Windows.Forms.CheckBox chkIsProjectEnabled;
        private System.Windows.Forms.GroupBox gbxTips;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.PictureBox picGameField;
        private System.Windows.Forms.Timer tmrGame;
    }
}

