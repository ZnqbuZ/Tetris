using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tetris
{
    public enum Direction { None, Down, Left, Right, Up }

    public class TetrisField
    {
        public int TilesWidth { get; private set; }
        public int TilesHeight { get; private set; }
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }

        //保存区域内的块
        private readonly TileType[,] Tiles;

        public TileType this[int row, int col]
        {
            get
            {
                try
                {
                    return Tiles[row, col];
                }
                catch (IndexOutOfRangeException)
                {
                    //数组出界说明到达边界
                    return TileType.Wall;
                }
            }
        }

        public TetrisField(int height, int width)
        {
            TilesWidth = width;
            TilesHeight = height;
            Tiles = new TileType[height, width];

            BorderColor = Color.FromArgb(192, 192, 192);
            BackColor = Color.FromArgb(240, 240, 240);

            Clear();
        }

        //设置某坐标上的块
        public bool SetCell(int row, int col, TileType type)
        {
            try
            {
                Tiles[row, col] = type;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool IsEmpty(int row, int col)
        {
            if (this[row, col] != TileType.Empty) return false;
            return true;
        }

        private bool IsRowEmpty(int row)
        {
            for (int col = 0; col < TilesWidth; col++)
            {
                if (Tiles[row, col] != TileType.Empty)
                    return false;
            }
            return true;
        }

        //将Tetromino写入Tiles
        public bool DrawTetromino(Tetromino t, bool rewrite)
        {
            try
            {
                if (Tiles[t.YC, t.XC] == TileType.Empty || rewrite) Tiles[t.YC, t.XC] = t.Type;
                else return false;

                if (Tiles[t.Y1, t.X1] == TileType.Empty || rewrite) Tiles[t.Y1, t.X1] = t.Type;
                else return false;

                if (Tiles[t.Y2, t.X2] == TileType.Empty || rewrite) Tiles[t.Y2, t.X2] = t.Type;
                else return false;

                if (Tiles[t.Y3, t.X3] == TileType.Empty || rewrite) Tiles[t.Y3, t.X3] = t.Type;
                else return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        protected void EraseTetromino(Tetromino t)
        {
            t.Type = TileType.Empty;
            DrawTetromino(t, true);
        }

        public bool IsEmpty(Tetromino t)
        {
            if (this[t.YC, t.XC] != TileType.Empty) return false;
            if (this[t.Y1, t.X1] != TileType.Empty) return false;
            if (this[t.Y2, t.X2] != TileType.Empty) return false;
            if (this[t.Y3, t.X3] != TileType.Empty) return false;
            return true;
        }

        protected bool Move(Tetromino t, Direction direction)
        {
            Tetromino moved = t.Move(direction);

            //先将传入的tetromino从tiles中抹掉
            EraseTetromino(t);

            if (IsEmpty(moved))
            {
                //若可写入则写入tiles
                DrawTetromino(moved, false);
                return true;
            }
            else
            {
                //如果非空则将传入的tetromino写回tiles，即不运动
                t.Type = moved.Type;
                DrawTetromino(t, false);
                return false;
            }
        }

        protected Tetromino RotateTetromino(Tetromino t)
        {
            Tetromino rotated = t.Rotate();
            EraseTetromino(t);

            //旋转后可能与其他块有重叠，故略微挪动以找到空位
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                if (IsEmpty(rotated.Move(direction)))
                {
                    DrawTetromino(rotated, false);
                    return rotated;
                }
            }

            DrawTetromino(t, false);
            return Tetromino.Zero;
        }

        public int RemoveFullRows()
        {
            List<int> FullRows = new List<int>();

            //计算满行数量
            for (int row = 0; row < TilesHeight; row++)
            {
                bool isRowFull = true;
                for (int col = 0; col < TilesWidth; col++)
                {
                    if (Tiles[row, col] == TileType.Empty)
                    {
                        isRowFull = false;
                        break;
                    }
                }
                if (isRowFull) FullRows.Add(row);
            }

            //整体向下移动
            foreach (int fullRow in FullRows)
            {
                for (int row = fullRow - 1; row > 0; row--)
                {
                    for (int col = 0; col < TilesWidth; col++)
                    {
                        Tiles[row + 1, col] = Tiles[row, col];
                        if (IsRowEmpty(row + 1)) break;
                    }
                }
            }

            return TilesWidth * FullRows.Count;
        }

        public virtual void Clear()
        {
            for (int row = 0; row < TilesHeight; row++)
            {
                for (int col = 0; col < TilesWidth; col++)
                {
                    SetCell(row, col, TileType.Empty);
                }
            }
        }

        public const int TileSize = 20;

        //绘制tiles
        public virtual void Paint(Graphics graphics)
        {
            Pen border = new Pen(BorderColor, 2F);
            SolidBrush fone = new SolidBrush(BackColor);

            graphics.DrawRectangle(border, 4, 4, TilesWidth * TileSize + 2, TilesHeight * TileSize + 2);
            graphics.FillRectangle(fone, 5, 5, TilesWidth * TileSize, TilesHeight * TileSize);

            for (int row = 0; row < TilesHeight; row++)
            {
                for (int col = 0; col < TilesWidth; col++)
                {
                    Rectangle tile = new Rectangle(5 + col * TileSize, 5 + row * TileSize, TileSize, TileSize);
                    switch (Tiles[row, col])
                    {
                        case TileType.Blue:
                            if (Blue == null) graphics.FillRectangle(Brushes.Blue, tile);
                            else graphics.DrawImage(Blue, tile);
                            break;
                        case TileType.Green:
                            if (Green == null) graphics.FillRectangle(Brushes.Green, tile);
                            else graphics.DrawImage(Green, tile);
                            break;
                        case TileType.Yellow:
                            if (Yellow == null) graphics.FillRectangle(Brushes.Yellow, tile);
                            else graphics.DrawImage(Yellow, tile);
                            break;
                        case TileType.Purple:
                            if (Purple == null) graphics.FillRectangle(Brushes.Purple, tile);
                            else graphics.DrawImage(Purple, tile);
                            break;
                        case TileType.Orange:
                            if (Orange == null) graphics.FillRectangle(Brushes.Orange, tile);
                            else graphics.DrawImage(Orange, tile);
                            break;
                        case TileType.Red:
                            if (Red == null) graphics.FillRectangle(Brushes.Red, tile);
                            else graphics.DrawImage(Red, tile);
                            break;
                        case TileType.LightBlue:
                            if (LightBlue == null) graphics.FillRectangle(Brushes.LightBlue, tile);
                            else graphics.DrawImage(LightBlue, tile);
                            break;
                    }
                }
            }
        }

        public static Bitmap Red, Green, Blue, Yellow, Orange, Purple, LightBlue;
    }

    public class GameField : TetrisField
    {
        private Tetromino current;

        public bool IsTetrominoFalling { get; private set; }

        public bool ProjectEnabled { get; set; }

        public GameField(int height, int width) : base(height, width)
        {
            IsTetrominoFalling = false;
            ProjectEnabled = true;
            current = Tetromino.Zero;
        }

        public bool PlaceTetromino(Tetromino t)
        {
            t = t.MoveTo(0, TilesWidth / 2 - 1);
            current = t;
            //无法写入新的tetromino，说明游戏结束
            if (!DrawTetromino(t, false)) return false;
            IsTetrominoFalling = true;
            return true;
        }

        public Tetromino ChangeTetromino(Tetromino nextTetromino)
        {
            if (current == Tetromino.Zero) return current;
            EraseTetromino(current);
            if (!PlaceTetromino(nextTetromino)) return Tetromino.Zero;
            return current;
        }

        public bool RotateTetromino()
        {
            if (current == Tetromino.Zero) return false;
            Tetromino t = RotateTetromino(current);
            if (t != Tetromino.Zero)
            {
                current = t;
                return true;
            }
            return false;
        }

        public bool Move(Direction direction)
        {
            if (current == Tetromino.Zero) return false;
            if (Move(current, direction))
            {
                current = current.Move(direction);
                return true;
            }
            return false;
        }

        //下落到底
        public bool Drop()
        {
            if (current == Tetromino.Zero) return false;
            while (current != Tetromino.Zero) DoStep();
            return true;
        }

        //下落一步
        public void DoStep()
        {
            if (current != Tetromino.Zero)
            {
                IsTetrominoFalling = Move(current, Direction.Down);
                if (IsTetrominoFalling) current = current.Move(Direction.Down);
                else current = Tetromino.Zero;
            }
            else IsTetrominoFalling = false;
        }

        public override void Clear()
        {
            base.Clear();

            current = Tetromino.Zero;
            IsTetrominoFalling = false;
        }

        public override void Paint(Graphics graphics)
        {
            base.Paint(graphics);

            //绘制投影
            if (ProjectEnabled && IsTetrominoFalling)
            {
                Tetromino proj = current;

                EraseTetromino(current);

                while (IsEmpty(proj))
                {
                    proj = proj.Move(Direction.Down);
                }

                proj = proj.Move(Direction.Up);

                DrawTetromino(current, false);

                Point[] cells = new Point[]
                {
                    new Point(proj.XC, proj.YC), new Point(proj.X1, proj.Y1),
                    new Point(proj.X2, proj.Y2), new Point(proj.X3, proj.Y3)
                };

                SolidBrush brush = new SolidBrush(Color.FromArgb(32, 192, 0, 0));

                foreach (Point cell in cells)
                {
                    if (!IsEmpty(cell.Y, cell.X)) continue;
                    Rectangle tile = new Rectangle(6 + cell.X * TileSize, 6 + cell.Y * TileSize, TileSize - 2, TileSize - 2);
                    graphics.FillRectangle(brush, tile);
                }
            }
        }
    }

    //定义俄罗斯方块结构体
    public struct Tetromino
    {
        public int XC { get; private set; }
        public int YC { get; private set; }

        public int X1 { get; private set; }
        public int Y1 { get; private set; }

        public int X2 { get; private set; }
        public int Y2 { get; private set; }

        public int X3 { get; private set; }
        public int Y3 { get; private set; }

        public TileType Type;

        public static readonly Tetromino Zero = new Tetromino(TileType.Empty);

        public Tetromino(TileType type)
        {
            Type = type;

            XC = 0;
            YC = 0;

            switch (type)
            {
                //对于每种方块，选出一中心块，并借其计算其余三块的坐标
                case TileType.Blue: // I
                    X1 = XC - 1; X2 = XC + 1; X3 = XC + 2;
                    Y1 = YC; Y2 = YC; Y3 = YC;
                    break;
                case TileType.LightBlue: // L
                    X1 = XC - 1; X2 = XC - 1; X3 = XC + 1;
                    Y1 = YC + 1; Y2 = YC; Y3 = YC;
                    break;
                case TileType.Green: // Z
                    X1 = XC - 1; X2 = XC; X3 = XC + 1;
                    Y1 = YC; Y2 = YC + 1; Y3 = YC + 1;
                    break;
                case TileType.Orange: // Г
                    X1 = XC - 1; X2 = XC + 1; X3 = XC + 1;
                    Y1 = YC; Y2 = YC; Y3 = YC + 1;
                    break;
                case TileType.Purple: // T
                    X1 = XC - 1; X2 = XC; X3 = XC + 1;
                    Y1 = YC; Y2 = YC + 1; Y3 = YC;
                    break;
                case TileType.Red: // S
                    X1 = XC - 1; X2 = XC; X3 = XC + 1;
                    Y1 = YC + 1; Y2 = YC + 1; Y3 = YC;
                    break;
                case TileType.Yellow: // [ ]
                    X1 = XC + 1; X2 = XC; X3 = XC + 1;
                    Y1 = YC; Y2 = YC + 1; Y3 = YC + 1;
                    break;
                case TileType.Empty: // zero
                    X3 = X2 = X1 = XC = 0;
                    Y3 = Y2 = Y1 = YC = 0;
                    break;
                default:
                    X3 = X2 = X1 = XC = 0;
                    Y3 = Y2 = Y1 = YC = 0;
                    break;
            }
        }

        //移动方法
        #region
        public Tetromino Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return MoveTo(YC - 1, XC);
                case Direction.Down: return MoveTo(YC + 1, XC);
                case Direction.Left: return MoveTo(YC, XC - 1);
                case Direction.Right: return MoveTo(YC, XC + 1);
                default: return this;
            }
        }
        //瞬移
        public Tetromino MoveTo(int row, int col)
        {
            //坐标偏移量
            int dx = col - XC, dy = row - YC;
            //返回移动后的方块
            return new Tetromino(Type)
            {
                XC = col,
                YC = row,
                X1 = X1 + dx,
                Y1 = Y1 + dy,
                X2 = X2 + dx,
                Y2 = Y2 + dy,
                X3 = X3 + dx,
                Y3 = Y3 + dy
            };
        }
        #endregion

        //旋转方法
        #region
        //旋转辅助函数
        private int RotateCol(int col) => YC - XC + col;
        private int RotateRow(int row) => XC - row + YC;

        public Tetromino Rotate()
        {
            Tetromino res = Clone();
            res.X1 = RotateRow(Y1); res.Y1 = RotateCol(X1);
            res.X2 = RotateRow(Y2); res.Y2 = RotateCol(X2);
            res.X3 = RotateRow(Y3); res.Y3 = RotateCol(X3);
            return res;
        }
        #endregion

        //重载相等、不等运算符
        #region
        public static bool operator ==(Tetromino left, Tetromino right)
        {
            return left.Type == right.Type && left.XC == right.XC && left.YC == right.YC &&
                left.X1 == right.X1 && left.X2 == right.X2 && left.X3 == right.X3 &&
                left.Y1 == right.Y1 && left.Y2 == right.Y2 && left.Y3 == right.Y3;
        }
        public static bool operator !=(Tetromino left, Tetromino right)
        {
            return !(left == right);
        }
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion

        //定义Clone方法
        private Tetromino Clone()
        {
            return new Tetromino(Type)
            {
                XC = XC,
                YC = YC,
                X1 = X1,
                Y1 = Y1,
                X2 = X2,
                Y2 = Y2,
                X3 = X3,
                Y3 = Y3
            };
        }

        //产生随机方块
        private static readonly Random rnd = new Random();
        public static Tetromino RandomTetromino() { return new Tetromino((TileType)rnd.Next(1, 7)); }
    }

    public enum TileType { Empty, Red, Green, Blue, Yellow, Orange, Purple, LightBlue, Wall }
}
