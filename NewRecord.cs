using System;
using System.Windows.Forms;

namespace Tetris
{
    public partial class NewRecord : Form
    {
        public string UserName { get; set; }
        public NewRecord()
        {
            InitializeComponent();
        }

        private void BtnConfirmed_Click(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Trim(' ');
            if (string.IsNullOrEmpty(txtName.Text)) UserName = "Player";
            else UserName = txtName.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
