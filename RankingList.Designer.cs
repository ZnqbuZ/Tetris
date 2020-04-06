namespace Tetris
{
    partial class RankingList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tctlList = new System.Windows.Forms.TabControl();
            this.ppScoreList = new System.Windows.Forms.TabPage();
            this.lblScoreList = new System.Windows.Forms.Label();
            this.lvwScoreList = new System.Windows.Forms.ListView();
            this.colName1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ppTimeList = new System.Windows.Forms.TabPage();
            this.lblTimeList = new System.Windows.Forms.Label();
            this.lvwTimeList = new System.Windows.Forms.ListView();
            this.colName2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tctlList.SuspendLayout();
            this.ppScoreList.SuspendLayout();
            this.ppTimeList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tctlList
            // 
            this.tctlList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tctlList.Controls.Add(this.ppScoreList);
            this.tctlList.Controls.Add(this.ppTimeList);
            this.tctlList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tctlList.Location = new System.Drawing.Point(12, 12);
            this.tctlList.Name = "tctlList";
            this.tctlList.SelectedIndex = 0;
            this.tctlList.Size = new System.Drawing.Size(360, 325);
            this.tctlList.TabIndex = 0;
            // 
            // ppScoreList
            // 
            this.ppScoreList.Controls.Add(this.lblScoreList);
            this.ppScoreList.Controls.Add(this.lvwScoreList);
            this.ppScoreList.Location = new System.Drawing.Point(4, 29);
            this.ppScoreList.Name = "ppScoreList";
            this.ppScoreList.Padding = new System.Windows.Forms.Padding(3);
            this.ppScoreList.Size = new System.Drawing.Size(352, 292);
            this.ppScoreList.TabIndex = 0;
            this.ppScoreList.Text = "得分";
            this.ppScoreList.UseVisualStyleBackColor = true;
            // 
            // lblScoreList
            // 
            this.lblScoreList.AutoSize = true;
            this.lblScoreList.Location = new System.Drawing.Point(3, 3);
            this.lblScoreList.Name = "lblScoreList";
            this.lblScoreList.Size = new System.Drawing.Size(177, 20);
            this.lblScoreList.TabIndex = 1;
            this.lblScoreList.Text = "一局游戏得分最高的玩家：";
            // 
            // lvwScoreList
            // 
            this.lvwScoreList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName1,
            this.colScore1,
            this.colTime1,
            this.colDate1});
            this.lvwScoreList.FullRowSelect = true;
            this.lvwScoreList.GridLines = true;
            this.lvwScoreList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwScoreList.HideSelection = false;
            this.lvwScoreList.Location = new System.Drawing.Point(0, 26);
            this.lvwScoreList.Name = "lvwScoreList";
            this.lvwScoreList.Size = new System.Drawing.Size(352, 270);
            this.lvwScoreList.TabIndex = 0;
            this.lvwScoreList.UseCompatibleStateImageBehavior = false;
            this.lvwScoreList.View = System.Windows.Forms.View.Details;
            // 
            // colName1
            // 
            this.colName1.Text = "玩家";
            this.colName1.Width = 100;
            // 
            // colScore1
            // 
            this.colScore1.Text = "得分";
            this.colScore1.Width = 70;
            // 
            // colTime1
            // 
            this.colTime1.Text = "游戏时长";
            this.colTime1.Width = 75;
            // 
            // colDate1
            // 
            this.colDate1.Text = "日期";
            this.colDate1.Width = 103;
            // 
            // ppTimeList
            // 
            this.ppTimeList.Controls.Add(this.lblTimeList);
            this.ppTimeList.Controls.Add(this.lvwTimeList);
            this.ppTimeList.Location = new System.Drawing.Point(4, 29);
            this.ppTimeList.Name = "ppTimeList";
            this.ppTimeList.Padding = new System.Windows.Forms.Padding(3);
            this.ppTimeList.Size = new System.Drawing.Size(352, 292);
            this.ppTimeList.TabIndex = 1;
            this.ppTimeList.Text = "时长";
            this.ppTimeList.UseVisualStyleBackColor = true;
            // 
            // lblTimeList
            // 
            this.lblTimeList.AutoSize = true;
            this.lblTimeList.Location = new System.Drawing.Point(3, 3);
            this.lblTimeList.Name = "lblTimeList";
            this.lblTimeList.Size = new System.Drawing.Size(177, 20);
            this.lblTimeList.TabIndex = 3;
            this.lblTimeList.Text = "一局游戏时间最长的玩家：";
            // 
            // lvwTimeList
            // 
            this.lvwTimeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName2,
            this.colScore2,
            this.colTime2,
            this.colDate2});
            this.lvwTimeList.FullRowSelect = true;
            this.lvwTimeList.GridLines = true;
            this.lvwTimeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwTimeList.HideSelection = false;
            this.lvwTimeList.Location = new System.Drawing.Point(0, 26);
            this.lvwTimeList.Name = "lvwTimeList";
            this.lvwTimeList.Size = new System.Drawing.Size(352, 270);
            this.lvwTimeList.TabIndex = 2;
            this.lvwTimeList.UseCompatibleStateImageBehavior = false;
            this.lvwTimeList.View = System.Windows.Forms.View.Details;
            // 
            // colName2
            // 
            this.colName2.Text = "玩家";
            this.colName2.Width = 100;
            // 
            // colScore2
            // 
            this.colScore2.DisplayIndex = 2;
            this.colScore2.Text = "得分";
            this.colScore2.Width = 70;
            // 
            // colTime2
            // 
            this.colTime2.DisplayIndex = 1;
            this.colTime2.Text = "游戏时长";
            this.colTime2.Width = 75;
            // 
            // colDate2
            // 
            this.colDate2.Text = "日期";
            this.colDate2.Width = 103;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.AutoSize = true;
            this.btnNewGame.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewGame.Location = new System.Drawing.Point(297, 343);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 30);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "回到游戏";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(12, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // RankingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 385);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.tctlList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RankingList";
            this.Text = "排行榜";
            this.tctlList.ResumeLayout(false);
            this.ppScoreList.ResumeLayout(false);
            this.ppScoreList.PerformLayout();
            this.ppTimeList.ResumeLayout(false);
            this.ppTimeList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tctlList;
        private System.Windows.Forms.TabPage ppScoreList;
        private System.Windows.Forms.TabPage ppTimeList;
        private System.Windows.Forms.ListView lvwScoreList;
        private System.Windows.Forms.Label lblScoreList;
        private System.Windows.Forms.Label lblTimeList;
        private System.Windows.Forms.ListView lvwTimeList;
        private System.Windows.Forms.ColumnHeader colName1;
        private System.Windows.Forms.ColumnHeader colScore1;
        private System.Windows.Forms.ColumnHeader colTime1;
        private System.Windows.Forms.ColumnHeader colDate1;
        private System.Windows.Forms.ColumnHeader colName2;
        private System.Windows.Forms.ColumnHeader colTime2;
        private System.Windows.Forms.ColumnHeader colScore2;
        private System.Windows.Forms.ColumnHeader colDate2;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnCancel;
    }
}