using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadrantFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо введені значення
                double x = double.Parse(txtX.Text);
                double y = double.Parse(txtY.Text);

                // Створюємо об'єкт Point2D
                Point2D point = new Point2D(x, y);

                // Визначаємо четверть
                string quadrant = point.GetQuadrant();
                lblResult.Text = quadrant;

                // Візуалізуємо точку
                DrawPointOnGraph(x, y);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть коректні числові значення для координат X і Y.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlGraph_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawPointOnGraph(double x, double y)
        {
            // Очищуємо панель перед малюванням
            pnlGraph.Refresh();

            using (Graphics g = pnlGraph.CreateGraphics())
            {
                // Визначаємо центр панелі як початок координат
                int centerX = pnlGraph.Width / 2;
                int centerY = pnlGraph.Height / 2;

                // Масштабуємо координати для більшого зображення
                int scale = 20;  // Збільшення масштабу для наочності

                // Координати точки для малювання
                int drawX = centerX + (int)(x * scale);
                int drawY = centerY - (int)(y * scale);

                // Малюємо вісь координат
                Pen axisPen = new Pen(Color.Black, 2);
                g.DrawLine(axisPen, centerX, 0, centerX, pnlGraph.Height); // Y-axis
                g.DrawLine(axisPen, 0, centerY, pnlGraph.Width, centerY);  // X-axis

                // Малюємо точку
                SolidBrush brush = new SolidBrush(Color.Red);
                g.FillEllipse(brush, drawX - 5, drawY - 5, 10, 10); // Малюємо точку як маленький круг
            }
        }

    }
}
