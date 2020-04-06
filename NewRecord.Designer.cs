namespace Tetris
{
    partial class NewRecord
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
            this.lblCongratulation = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnConfirmed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCongratulation
            // 
            this.lblCongratulation.AutoSize = true;
            this.lblCongratulation.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCongratulation.Location = new System.Drawing.Point(12, 9);
            this.lblCongratulation.Name = "lblCongratulation";
            this.lblCongratulation.Size = new System.Drawing.Size(177, 20);
            this.lblCongratulation.TabIndex = 0;
            this.lblCongratulation.Text = "恭喜上榜！请问尊姓大名？";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(12, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(219, 26);
            this.txtName.TabIndex = 1;
            // 
            // btnConfirmed
            // 
            this.btnConfirmed.AutoSize = true;
            this.btnConfirmed.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirmed.Location = new System.Drawing.Point(237, 41);
            this.btnConfirmed.Name = "btnConfirmed";
            this.btnConfirmed.Size = new System.Drawing.Size(75, 30);
            this.btnConfirmed.TabIndex = 2;
            this.btnConfirmed.Text = "确认";
            this.btnConfirmed.UseVisualStyleBackColor = true;
            this.btnConfirmed.Click += new System.EventHandler(this.BtnConfirmed_Click);
            // 
            // NewRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 85);
            this.Controls.Add(this.btnConfirmed);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCongratulation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewRecord";
            this.Text = "新纪录！";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCongratulation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnConfirmed;
    }
}