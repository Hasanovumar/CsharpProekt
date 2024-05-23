namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += PictureBox1_Paint;
        }
        public bool IsSinus { get => radioButton1.Checked; }
        public bool IsCosinus { get => radioButton2.Checked; }
        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            var graphic = e.Graphics;
            var blackPen = new Pen(Color.Black);
            var width = pictureBox1.Width;
            var height = pictureBox1.Height;
            Point NullPoint = new Point(10, height / 2);
            Point XAxisPoint = new Point(x: NullPoint.X + ((int)(XLenthProcent / 100.0 * width)), y: NullPoint.Y);
            Point YAxisPoint = new Point(x: NullPoint.X, y: NullPoint.Y - ((int)(XLenthProcent / 2 / 100.0 * height)));
            Point YAxisPointMinus = new Point(x: NullPoint.X, y: NullPoint.Y + ((int)(XLenthProcent / 2 / 100.0 * height)));

            graphic.DrawLine(blackPen,
                NullPoint,
                XAxisPoint
                );

            graphic.DrawLine(blackPen,
              NullPoint,
              YAxisPoint
              );

            graphic.DrawLine(blackPen,
              NullPoint,
              YAxisPointMinus
              );

            //graphic.DrawLine(blackPen,
            //    x1: 250, y1: 50,
            //    x2: 250, y2: 200
            //    );
            //graphic.DrawLine(blackPen,
            //    x1: 250, y1: 200,
            //    x2: 400, y2: 200
            //    );

            //graphic.DrawLine(blackPen,
            //    x1: 250, y1: 50,
            //    x2: 240, y2: 60
            //    );
            //graphic.DrawLine(blackPen,
            //    x1: 250, y1: 50,
            //    x2: 260, y2: 60
            //    );

            //graphic.DrawLine(blackPen,
            //    x1: 390, y1: 190,
            //    x2: 400, y2: 200
            //     );

            //graphic.DrawLine(blackPen,
            //    x1: 390, y1: 210,
            //    x2: 400, y2: 200
            //     );

            //graphic.DrawLine(blackPen,
            //   x1: 240, y1: 125,
            //   x2: 260, y2: 125
            //    );

            //graphic.DrawLine(blackPen,
            //  x1: 322, y1: 210,
            //  x2: 322, y2: 190
            //   );

            graphic.DrawString(
                s: "Achse Y",
                font: Font,
                brush: Brushes.Black,
                YAxisPoint
                );

            graphic.DrawString(
                s: "Achse X",
                font: Font,
                brush: Brushes.Black,
                XAxisPoint
                );



            graphic.DrawString(
                s: "0",
                font: Font,
                brush: Brushes.Black,
                 NullPoint
                );

            graphic.DrawString(
                s: "" + Ymax,
                font: Font,
                brush: Brushes.Black,
                x: YAxisPoint.X,
                y: YAxisPoint.Y + 10
                );

            graphic.DrawString(
                s: "-" + Ymax,
                font: Font,
                brush: Brushes.Black,
                x: YAxisPointMinus.X,
                y: YAxisPointMinus.Y /*+ 10*/
                );

            graphic.DrawString(

                s: "" + Xmax,
                font: Font,
                brush: Brushes.Black,
                x: XAxisPoint.X,
                y: XAxisPoint.Y + 10
                );

            graphic.DrawString(
                s: "" + Xmax / 2,
                font: Font,
                brush: Brushes.Black,
                x: NullPoint.X + (XAxisPoint.X - NullPoint.X) / 2,
                y: NullPoint.Y
                );

            graphic.DrawString(
                s: "" + Ymax / 2.0,
                font: Font,
                brush: Brushes.Black,
                x: NullPoint.X,
                y: YAxisPoint.Y + (NullPoint.Y - YAxisPoint.Y) / 2
                );


            graphic.DrawString(
                s: "-" + Ymax / 2.0,
                font: Font,
                brush: Brushes.Black,
                x: NullPoint.X,
                y: YAxisPointMinus.Y - (YAxisPointMinus.Y - NullPoint.Y) / 2
                );

            // sinus 
            for (int i = 0; i < Xmax * 10; i++)
            {
                double sd = i / 10.0;
                double result_Math = 0.0;
                //if (IsSinus)
                //{
                //    result_Math = Math.Sin(sd);
                //}
                //else
                //{
                //    result_Math = Math.Cos(sd);
                //}

                result_Math = Math.Sin(sd);
                DrawCircle(graphic, blackPen, NullPoint, XAxisPoint, YAxisPoint, sd, result_Math);
                result_Math = Math.Cos(sd + (Math.PI / 2));
                DrawCircle(graphic, blackPen, NullPoint, XAxisPoint, YAxisPoint, sd, result_Math);
            }

            //graphic.DrawEllipse(blackPen, new Rectangle(x: 325 - 2, y: 128 - 2, width: 4, height: 4));
            //var result1 = Math.Sin(0.5);
            //graphic.DrawEllipse(blackPen, new Rectangle(x: 310 - 2, y: 141 - 2, width: 4, height: 4));
            //var result2 = Math.Sin(0.4);
            //graphic.DrawEllipse(blackPen, new Rectangle(x: 295, y: 154, width: 4, height: 4));
            //var result3 = Math.Sin(0.3);
            //graphic.DrawEllipse(blackPen, new Rectangle(x: 292, y: 180, width: 7, height: 7));
            //var result4 = Math.Sin(0.2);
            //graphic.DrawEllipse(blackPen, new Rectangle(x: 282, y: 190, width: 7, height: 7));
            //var result5 = Math.Sin(0.1);
            //graphic.DrawEllipse(blackPen, new Rectangle(x: 272, y: 200, width: 7, height: 7));
            //var result6 = Math.Sin(0.0);
        }

        private void DrawCircle(Graphics graphic, Pen blackPen, Point NullPoint, Point XAxisPoint, Point YAxisPoint, double sd, double result_Math)
        {
            int yPixel = (NullPoint.Y - YAxisPoint.Y) / Ymax;
            int resultPixel = (int)(result_Math * yPixel);

            int xPixel = (XAxisPoint.X - NullPoint.X) / Xmax;
            int forOffset = (int)(sd * xPixel);
            graphic.DrawEllipse(
                blackPen,
                new Rectangle(
                    x: NullPoint.X + forOffset - 2,
                    y: NullPoint.Y - resultPixel - 2,
                    width: 4,
                    height: 4));
        }

        string CalTotal;
        int num1;
        int num2;
        string option;
        int result;

        int Xmax = 6;
        int Ymax = 1;
        int XLenthProcent = 50;



        private void button1_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text + "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            option = "+";
            num1 = int.Parse(txtTotal.Text);

            txtTotal.Clear();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            option = "-";
            num1 = int.Parse(txtTotal.Text);

            txtTotal.Clear();
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            option = "*";
            num1 = int.Parse(txtTotal.Text);

            txtTotal.Clear();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            option = "/";
            num1 = int.Parse(txtTotal.Text);

            txtTotal.Clear();
        }

        private void btnEql_Click(object sender, EventArgs e)
        {
            num2 = int.Parse(txtTotal.Text);

            if (option.Equals("+"))
                result = num1 + num2;

            if (option.Equals("-"))
                result = num1 - num2;

            if (option.Equals("*"))
                result = num1 * num2;

            if (option.Equals("/"))
                result = num1 / num2;

            txtTotal.Text = result + "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTotal.Clear();
            result = (0);
            num1 = (0);
            num2 = (0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_XAxis_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox_XAxis.Text, out int maxXValue))
            {
                Xmax = maxXValue;
                pictureBox1.Invalidate();
            }
        }

        private void textBox_XAxis_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out int maxXValue))
            {
                XLenthProcent = maxXValue;
                pictureBox1.Invalidate();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = !radioButton1.Checked;
            pictureBox1.Invalidate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
            pictureBox1.Invalidate();
        }
    }
}
  
