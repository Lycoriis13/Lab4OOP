using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadrantFinder
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public string GetQuadrant()
        {
            if (X > 0 && Y > 0)
                return "Перша четверть";
            else if (X < 0 && Y > 0)
                return "Друга четверть";
            else if (X < 0 && Y < 0)
                return "Третя четверть";
            else if (X > 0 && Y < 0)
                return "Четверта четверть";
            else if (X == 0 && Y == 0)
                return "Точка знаходиться на початку координат";
            else if (X == 0)
                return "Точка знаходиться на осі Y";
            else
                return "Точка знаходиться на осі X";
        }
    }

}
