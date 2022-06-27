using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLifeWinForms
{
    public partial class Form1 : Form
    {
        private Image imageGameField;
        private Graphics grafField;
        public List<GameCell> ListGameField;
        int blockSize;
        int size;
        int coefficient;
        string shape;
        double? speed;
        int polisy;
        Random propability;
        bool active = false;
        bool spontaneous = false;
        int countLivingCells = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                SelectItemSize(cbSize.SelectedItem.ToString());
                SelectItemSeed(cbSeed.SelectedItem.ToString());
                SelectItemShape(cbShape.SelectedItem.ToString());
                SelectItemSpeed(cbSpeed.SelectedItem.ToString());
                SelectItemPolicy(cbPolicy.SelectedItem.ToString());
                SelectItemWalls(cbWalls.SelectedItem.ToString());

                PreparingForTheGame();
                GenerationOfLivingCells();
            }
            catch (Exception eee)
            {
                MessageBox.Show($"Error: {eee}");
            }
        }

        private void SelectItemWalls(string currentItem)
        {
            if (currentItem.Contains("Alive"))
                active = true;
        }

        private void SelectItemPolicy(string currentItem)
        {
            if (currentItem.Contains("Conway"))
                polisy = 3;
            else if (currentItem.Contains("Hyperactive"))
                polisy = 5;
            else if (currentItem.Contains("High Life"))
                polisy = 3;
            else if (currentItem.Contains("Spontaneous"))
            {
                polisy = 3;
                propability = new Random();
                spontaneous = true;
            }
        }

        private void SelectItemSpeed(string currentItem)
        {
            if (currentItem.Contains("Stop"))
                speed = null;
            else if (currentItem == "Very Slow")
                speed = 2;
            else if (currentItem == "Slow")
                speed = 1;
            else if (currentItem.Contains("Normal"))
                speed = 0.5;
            else if (currentItem == "Fast")
                speed = 0.2;
            else if (currentItem == "Very Fast")
                speed = 0;
        }

        private void SelectItemShape(string currentItem)
        {
            if (currentItem.Contains("Rectengular"))
                shape = "Rectengular";
            else if (currentItem.Contains("Diamond"))
                shape = "Diamond";
            else if (currentItem.Contains("Cross"))
                shape = "Cross";
            else if (currentItem.Contains("Circular"))
                shape = "Circular";
            else if (currentItem.Contains("Ring"))
                shape = "Ring";
        }

        private void SelectItemSize(string currentItem)
        {
            if (currentItem.Contains("6x6"))
            {
                blockSize = 115;
                size = 6;
            }
            else if (currentItem.Contains("8x8"))
            {
                blockSize = 90;
                size = 8;
            }
            else if (currentItem.Contains("10x10"))
            {
                blockSize = 75;
                size = 10;
            }
            else if (currentItem.Contains("15x15"))
            {
                blockSize = 50;
                size = 15;
            }
            else if (currentItem.Contains("20x20"))
            {
                blockSize = 40;
                size = 20;
            }
            else if (currentItem.Contains("30x30"))
            {
                blockSize = 25;
                size = 30;
            }
            else if (currentItem.Contains("50x50"))
            {
                blockSize = 15;
                size = 50;
            }
            else if (currentItem.Contains("75x75"))
            {
                blockSize = 10;
                size = 75;
            }
            else if (currentItem.Contains("100x100"))
            {
                blockSize = 8;
                size = 100;
            }

            ListGameField = new List<GameCell>();
        }

        private void SelectItemSeed(string currentItem)
        {
            if (currentItem.Contains("Low"))
                coefficient = 10;
            else if (currentItem.Contains("Medium"))
                coefficient = 30;
            else if (currentItem.Contains("Large"))
                coefficient = 50;
        }

        private void PreparingForTheGame()
        {
            pictureBox.Width = (blockSize * size) + 2;
            pictureBox.Height = (blockSize * size) + 2;

            imageGameField = new Bitmap(size * blockSize, size * blockSize);
            grafField = Graphics.FromImage(imageGameField);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    PaintCellFirstGeneration(i, j, true);
            }

            if (shape == "Diamond")
                CreateDiamond();
            else if (shape == "Cross")
                CreateCross();
            else if (shape == "Circular")
                CreateCircular();
            else if (shape == "Ring")
                CreateRing();
            
            pictureBox.Image = imageGameField;
        }

        private void PaintCellFirstGeneration(int x, int y, bool first)
        {
            int left = x * blockSize;
            int top = y * blockSize;
            int right = (x * blockSize) + blockSize - 1;
            int bottom = (y * blockSize) + blockSize - 1;
            Rectangle rec = new Rectangle(left, top, blockSize - 1, blockSize - 1);

            if (first)
            {
                grafField.FillRectangle(Brushes.White, rec);
                Pen mainPen = new Pen(Color.Silver);

                var cell = new GameCell(new Point(x, y), false, false, false);
                ListGameField.Add(cell);

                if (x == 0)
                    grafField.DrawLine(mainPen, left, top, left, bottom);

                if (y == 0)
                    grafField.DrawLine(mainPen, left, top, right, top);

                grafField.DrawLine(mainPen, left, bottom, right, bottom);
                grafField.DrawLine(mainPen, right, top, right, bottom);

                grafField.DrawImage(imageGameField, left, top, rec, GraphicsUnit.Pixel);
                mainPen.Dispose();
            }
            else
            {
                grafField.FillEllipse(Brushes.Green, rec);
                countLivingCells++;
                ListGameField.Where(lambda => lambda.Point == new Point(x, y)).FirstOrDefault().IsALiveCurrent = true;
            }
        }
        private void CreateRing()
        {
            CreateCircular();


        }

        private void CreateCircular()
        {
            var r = size / 2 ;
            var x0 = size / 2 ;
            var y0 = size / 2 ;
            var x = -r;

            if (size % 2 == 0)
            {
                while (x >= r)
                {
                    var y = (int)Math.Floor(Math.Sqrt(r * r - x * x));
                    var trueY = x0 + x;
                    var a = y + y0;

                    for (var i = size; i >= y + y0; i--)
                    {
                        PaintWall(x0 + x, i);
                    }

                    y = -y;
                    for (int i = 0; i <= y + y0; i++)
                    {
                        PaintWall(x0 + x, i);
                    }

                    x++;
                }
            }
            else
            {
                while (x <= r)
                {
                    var y = (int)Math.Floor(Math.Sqrt(r * r - x * x));
                    var trueY = x0 + x;
                    var a = y + y0;

                    for (var i = size; i >= y + y0; i--)
                    {
                        PaintWall(x0 + x, i);
                    }

                    y = -y;
                    for (int i = 0; i <= y + y0; i++)
                    {
                        PaintWall(x0 + x, i);
                    }

                    x++;
                }
            }            
        }

        private void CreateCross()
        {
            if (size > 10)
            {
                int sideBox = size / 3;
                var count = 0;

                if (size % 2 == 0)
                {
                    sideBox++;
                    count++;
                }

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j < sideBox && i < sideBox)
                            PaintWall(i, j);
                        else if (j >= sideBox * 2 - count && i >= sideBox * 2 - count)
                            PaintWall(i, j);
                        else if (j < sideBox && i >= sideBox * 2 - count)
                            PaintWall(i, j);
                        else if (j >= sideBox * 2 - count && i < sideBox)
                            PaintWall(i, j);
                    }
                }
            }            
            else
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j != size / 2 && j != size / 2 - 1 && i != size / 2 && i != size / 2 - 1)
                            PaintWall(i, j);
                    }
                }
            }                    
        }

        private void CreateDiamond()
        {
            int count1 = 0;
            int count2 = 0;

            if (size % 2 == 0)
                count1 = 1;

            for (int i = 0; i < size / 2; i++)
            {
                for (int j = 0; j < size; j++)
                {                   
                    if (j < size / 2 - count1)
                        PaintWall(i, j);

                    if (j > size / 2 + count2)
                        PaintWall(i, j);
                }
                count1++;
                count2++;
            }

            count1 = 0;
            count2 = 0;

            if (size % 2 == 0)
                count1 = 1;

            for (int i = size - 1; i > size / 2; i--)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j < size / 2 - count1)
                        PaintWall(i, j);

                    if (j > size / 2 + count2)
                        PaintWall(i, j);
                }
                count1++;
                count2++;
            }

        }

        private void PaintWall(int x, int y)
        {
            var cell = ListGameField.Where(lambda => lambda.Point == new Point(x, y)).FirstOrDefault();

            if (cell != null)
            {
                cell.IsWall = true;

                if (active)
                    cell.IsALiveCurrent = true;

                PaintCell(cell);
            }
        }

        private void GenerationOfLivingCells()
        {
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!(bool)GetStatusCell(i, j, true))
                    {
                        var number = random.Next(100);

                        if (number < coefficient)
                            PaintCellFirstGeneration(i, j, false);
                    }
                }
            }
        }

        private void Run()
        {
            NextGeneration();
        }

        public void NextGeneration()
        {
            SetNextGeneration();
            PaintChanges();
        }

        private void SetNextGeneration()
        {
            bool CellStatusNext;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!(bool)GetStatusCell(i, j, true))
                    {
                        CellStatusNext = GetNextCellGeneration(i, j);
                        SetStatusCell(i, j, CellStatusNext);
                    }
                }
            }
        }

        private bool GetNextCellGeneration(int x, int y)
        {
            int liveCells = 0;
            bool returnStatus = false;

            bool? xm_ym = GetStatusCell(x - 1, y - 1, false);
            bool? x0_ym = GetStatusCell(x, y - 1, false);
            bool? xp_ym = GetStatusCell(x + 1, y - 1, false);
            bool? xm_y0 = GetStatusCell(x - 1, y, false);
            bool? x0_y0 = GetStatusCell(x, y, false);
            bool? xp_y0 = GetStatusCell(x + 1, y, false);
            bool? xm_yp = GetStatusCell(x - 1, y + 1, false);
            bool? x0_yp = GetStatusCell(x, y + 1, false);
            bool? xp_yp = GetStatusCell(x + 1, y + 1, false);

            if (xm_ym != null)
                liveCells = (bool)xm_ym ? ++liveCells : liveCells;
            if (x0_ym != null)
                liveCells = (bool)x0_ym ? ++liveCells : liveCells;
            if (xp_ym != null)
                liveCells = (bool)xp_ym ? ++liveCells : liveCells;
            if (xm_y0 != null)
                liveCells = (bool)xm_y0 ? ++liveCells : liveCells;
            if (xp_y0 != null)
                liveCells = (bool)xp_y0 ? ++liveCells : liveCells;
            if (xm_yp != null)
                liveCells = (bool)xm_yp ? ++liveCells : liveCells;
            if (x0_yp != null)
                liveCells = (bool)x0_yp ? ++liveCells : liveCells;
            if (xp_yp != null)
                liveCells = (bool)xp_yp ? ++liveCells : liveCells;

            if ((bool)x0_y0)
            {
                if (liveCells < 2 || liveCells > polisy)
                    returnStatus = false;
                else if (liveCells == 2 || liveCells == 3)
                    returnStatus = true;
            }
            else
            {
                if (liveCells == 3)
                    returnStatus = true;
                else if (liveCells != 3 && spontaneous && propability.Next(1000) == 5)
                    returnStatus = true;
            }

            return returnStatus;
        }

        public bool? GetStatusCell(int x, int y, bool checkWall)
        {
            if (checkWall)
                return ListGameField.Where(lambda => lambda.Point == new Point(x, y)).FirstOrDefault().IsWall;
            else
            {
                int? trueX;
                int? trueY;

                if (x < 0 || x == size)
                    trueX = null;
                else
                    trueX = x;

                if (y < 0 || y == size)
                    trueY = null;
                else
                    trueY = y;

                if (trueX == null || trueY == null)
                    return null;

                if (ListGameField.Where(lambda => lambda.Point == new Point(x, y)).FirstOrDefault().IsWall)
                {
                    if (!active)
                        return null;
                    else
                        return true;
                }
                else
                    return ListGameField.Where(lambda => lambda.Point == new Point((int)trueX, (int)trueY)).FirstOrDefault().IsALiveCurrent;
            }            
        }

        public void SetStatusCell(int x, int y, bool live)
        {
            if (live)
                ListGameField.Where(lambda => lambda.Point == new Point(x, y)).FirstOrDefault().IsALiveNext = true;
            else
                ListGameField.Where(lambda => lambda.Point == new Point(x, y)).FirstOrDefault().IsALiveNext = false;
        }

        private void PaintChanges()
        {
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    var cell = ListGameField.Where(x => x.Point == new Point(i, j)).FirstOrDefault();
                    PaintCell(cell);
                    cell.IsALiveCurrent = cell.IsALiveNext;
                }
            }
            pictureBox.Refresh();
        }

        private void PaintCell(GameCell cell)
        {
            int left = cell.Point.X * blockSize;
            int top = cell.Point.Y * blockSize;

            Rectangle rec = new Rectangle(left, top, blockSize - 1, blockSize - 1);

            if (cell.IsWall)
                grafField.FillRectangle(Brushes.Black, rec);
            else
            {
                if (cell.IsALiveNext)
                    grafField.FillEllipse(Brushes.Green, rec);
                else
                    grafField.FillRectangle(Brushes.White, rec);
            }

            grafField.DrawImage(imageGameField, left, top, rec, GraphicsUnit.Pixel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameTimer.Start();
        }

        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            GameTimer.Stop();

            int x = e.X / blockSize;
            int y = e.Y / blockSize;
            var cell = ListGameField.Where(lambda => lambda.Point == new Point(x, y)).FirstOrDefault();

            if (cell.IsALiveCurrent)
            {
                cell.IsALiveNext = false;
                cell.IsALiveCurrent = false;
            }
            else
            {
                cell.IsALiveNext = true;
                cell.IsALiveCurrent = true;
            }

            PaintCell(cell);
            pictureBox.Refresh();

            GameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Run();
            GameTimer.Stop();
        }
    }

    public class GameCell
    {
        public Point Point;
        public bool IsALiveCurrent;
        public bool IsALiveNext;
        public bool IsWall;

        public GameCell(Point point, bool isALiveCurrent, bool isAliveNext, bool isWall)
        {
            Point = point;
            IsALiveCurrent = isALiveCurrent;
            IsALiveNext = isAliveNext;
            IsWall = isWall;
        }
    }
}
