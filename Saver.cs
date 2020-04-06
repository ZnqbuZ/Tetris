using System;
using System.Collections.Generic;
using System.IO;

namespace Tetris
{
    public static class Constants
    {
        public const string fileName = "tetris.sav";
        public const int listLength = 10;
    }

    public static class Saver
    {
        private const string fileName = Constants.fileName;

        private const int listLength = Constants.listLength;

        public static HighTimesList highTimes = new HighTimesList();
        public static HighScoresList highScores = new HighScoresList();

        public static void Save(TetrisSave tetrisSave)
        {
            //判断并记录
            bool added = false;
            if (highScores.CanAdd(tetrisSave))
            { highScores.Add(tetrisSave); added = true; }
            if (highTimes.CanAdd(tetrisSave))
            { highTimes.Add(tetrisSave); added = true; }
            if (!added) return;

            //写入数据
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                for (int i = 0; i < listLength; i++)
                {
                    bw.Write(highScores[i].UserName);
                    bw.Write(highScores[i].Score);
                    bw.Write(highScores[i].GameDuration.Ticks);
                    bw.Write(highScores[i].GameEnded.Ticks);
                }
                for (int i = 0; i < listLength; i++)
                {
                    bw.Write(highTimes[i].UserName);
                    bw.Write(highTimes[i].Score);
                    bw.Write(highTimes[i].GameDuration.Ticks);
                    bw.Write(highTimes[i].GameEnded.Ticks);
                }
            }
        }

        public static void Load()
        {
            List<TetrisSave> loaded = new List<TetrisSave>();

            //加载存档
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (br.PeekChar() != -1)
                {
                    TetrisSave tetrisSave = new TetrisSave
                    {
                        UserName = br.ReadString(),
                        Score = br.ReadInt32(),
                        GameDuration = new TimeSpan(br.ReadInt64()),
                        GameEnded = new DateTime(br.ReadInt64())
                    };
                    loaded.Add(tetrisSave);
                }
            }

            //填补空白，存档文件必须具有正确格式，否则会出bug
            while (loaded.Count < 2 * listLength) loaded.Add(new TetrisSave("---", 0, new TimeSpan(0)));

            //传入数据
            TetrisSave[] scoreList = new TetrisSave[listLength];
            for (int i = 0; i < listLength; i++) scoreList[i] = loaded[i];
            highScores.Write(scoreList);

            TetrisSave[] timeList = new TetrisSave[listLength];
            for (int i = 0; i < listLength; i++) timeList[i] = loaded[listLength + i];
            highTimes.Write(timeList);
        }
    }

    public struct TetrisSave
    {
        public string UserName;
        public int Score;
        public DateTime GameEnded;
        public TimeSpan GameDuration;

        public TetrisSave(string uname, int sc, TimeSpan dur)
        {
            UserName = uname; Score = sc; GameDuration = dur; GameEnded = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            TetrisSave tetrisSave = (TetrisSave)obj;
            return (UserName == tetrisSave.UserName
                         && GameDuration == tetrisSave.GameDuration
                         && Score == tetrisSave.Score);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(TetrisSave left, TetrisSave right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TetrisSave left, TetrisSave right)
        {
            return !(left == right);
        }
    }

    public abstract class SavesList
    {
        protected const int listLength = Constants.listLength;

        protected TetrisSave[] Saves;

        public TetrisSave this[int index]
        {
            get { return Saves[index]; }
            set { Saves[index] = value; }
        }

        public SavesList()
        {
            Saves = new TetrisSave[listLength];
            for (int i = 0; i < listLength; i++)
            {
                Saves[i] = new TetrisSave("---", 0, new TimeSpan(0))
                {
                    UserName = "---",
                    GameEnded = new DateTime(0)
                };
            }
        }

        public void Write(TetrisSave[] tetrisSaves)
        {
            for (int i = 0; i < listLength; i++)
                Saves[i] = tetrisSaves[i];
            Sort();
        }

        public abstract void Add(TetrisSave s);
        public abstract bool CanAdd(TetrisSave s);
        protected abstract void Sort();
    }

    public sealed class HighScoresList : SavesList
    {
        public HighScoresList() : base() { }

        //按分数进行冒泡排序
        protected override void Sort()
        {
            for (int i = 0; i < listLength; i++)
            {
                int maxInd = i;
                for (int j = i; j < listLength; j++)
                {
                    if (Saves[j].Score > Saves[maxInd].Score)
                    {
                        maxInd = j;
                    }
                }
                TetrisSave tmp = Saves[maxInd];
                Saves[maxInd] = Saves[i];
                Saves[i] = tmp;
            }
        }

        public override bool CanAdd(TetrisSave tetrisSave)
        {
            Sort();
            //与最后一名比较
            return Saves[listLength - 1].Score < tetrisSave.Score;
        }

        //向存档中插入数据
        public override void Add(TetrisSave tetrisSave)
        {
            int i;
            for (i = listLength - 1; i >= 1; i--)
            {
                if (Saves[i - 1].Score >= tetrisSave.Score) break;
                Saves[i] = Saves[i - 1];
            }
            if (Saves[0].Score > tetrisSave.Score) Saves[i] = tetrisSave;
            else Saves[0] = tetrisSave;
        }
    }

    public sealed class HighTimesList : SavesList
    {
        public HighTimesList() : base() { }

        //按游戏时长进行冒泡排序
        protected override void Sort()
        {
            for (int i = 0; i < listLength; i++)
            {
                int maxInd = i;
                for (int j = i; j < listLength; j++)
                {
                    if (Saves[j].GameDuration > Saves[maxInd].GameDuration)
                    {
                        maxInd = j;
                    }
                }
                TetrisSave tmp = Saves[maxInd];
                Saves[maxInd] = Saves[i];
                Saves[i] = tmp;
            }
        }

        public override bool CanAdd(TetrisSave tetrisSave)
        {
            Sort();
            //与最后一名比较
            return Saves[listLength - 1].GameDuration < tetrisSave.GameDuration;
        }

        //向存档中插入数据
        public override void Add(TetrisSave tetrisSave)
        {
            int i;
            for (i = listLength - 1; i >= 1; i--)
            {
                if (Saves[i - 1].GameDuration >= tetrisSave.GameDuration) break;
                Saves[i] = Saves[i - 1];
            }
            if (Saves[0].GameDuration > tetrisSave.GameDuration) Saves[i] = tetrisSave;
            else Saves[0] = tetrisSave;
        }

    }
}
