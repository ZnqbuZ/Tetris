namespace Tetris
{
    partial class About
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
            this.lblProgramName = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblTool = new System.Windows.Forms.Label();
            this.btnConfirmed = new System.Windows.Forms.Button();
            this.picDecoration = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDecoration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProgramName.Location = new System.Drawing.Point(12, 103);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(107, 26);
            this.lblProgramName.TabIndex = 1;
            this.lblProgramName.Text = "俄罗斯方块";
            this.lblProgramName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAuthor.Location = new System.Drawing.Point(13, 128);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(51, 20);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "姚怀祯";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTool
            // 
            this.lblTool.AutoSize = true;
            this.lblTool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTool.Location = new System.Drawing.Point(13, 148);
            this.lblTool.Name = "lblTool";
            this.lblTool.Size = new System.Drawing.Size(160, 20);
            this.lblTool.TabIndex = 3;
            this.lblTool.Text = "Made by Visual Studio";
            this.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConfirmed
            // 
            this.btnConfirmed.AutoSize = true;
            this.btnConfirmed.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirmed.Location = new System.Drawing.Point(313, 143);
            this.btnConfirmed.Name = "btnConfirmed";
            this.btnConfirmed.Size = new System.Drawing.Size(75, 30);
            this.btnConfirmed.TabIndex = 4;
            this.btnConfirmed.Text = "确认";
            this.btnConfirmed.UseVisualStyleBackColor = true;
            this.btnConfirmed.Click += new System.EventHandler(this.BtnConfirmed_Click);
            // 
            // picDecoration
            // 
            this.picDecoration.Image = global::Tetris.Properties.Resources.About;
            this.picDecoration.Location = new System.Drawing.Point(0, 0);
            this.picDecoration.Name = "picDecoration";
            this.picDecoration.Size = new System.Drawing.Size(400, 100);
            this.picDecoration.TabIndex = 0;
            this.picDecoration.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 188);
            this.Controls.Add(this.btnConfirmed);
            this.Controls.Add(this.lblTool);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.picDecoration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "关于";
            ((System.ComponentModel.ISupportInitialize)(this.picDecoration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDecoration;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblTool;
        private System.Windows.Forms.Button btnConfirmed;
    }
}