using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class RankingList : Form
    {
        public RankingList(TetrisSave current)
        {
            InitializeComponent();

            //读取存档并显示数据
            for (int i = 0; i < 10; i++)
            {
                TetrisSave newRecord;

                newRecord = Saver.highScores[i];
                lvwScoreList.Items.Add(new RankingListItem(newRecord, newRecord.Equals(current)));

                newRecord = Saver.highTimes[i];
                lvwTimeList.Items.Add(new RankingListItem(newRecord, newRecord.Equals(current)));
            }
        }

        public RankingList(TetrisSave current, bool isHighTime) : this(current)
        {
            if (isHighTime)
            {
                tctlList.SelectedTab = ppTimeList;
            }
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        [Serializable]
        private class RankingListItem : ListViewItem
        {
            public RankingListItem(TetrisSave save, bool highLight) : base()
            {
                Text = save.UserName;
                SubItems.Add(save.Score.ToString());
                SubItems.Add(save.GameDuration.ToString(@"mm\:ss"));
                SubItems.Add(save.GameEnded.ToShortDateString());

                if (highLight)
                {
                    UseItemStyleForSubItems = true;
                    BackColor = Color.FromArgb(255, 242, 242);
                    ForeColor = Color.FromArgb(160, 0, 0);
                    Font = new Font("YaHei", (float)10.5, FontStyle.Bold);
                }
            }

            protected RankingListItem(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            {
                throw new NotImplementedException();
            }
        }
    }
}
