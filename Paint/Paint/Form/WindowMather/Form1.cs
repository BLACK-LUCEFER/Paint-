using System;
using System.Collections.Generic;
using System.Drawing;
using Paint.Script.DopolnenieScript;
using Paint.Script.FormScript.HistoryScript;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        List<DravingLine> dravingLine = new List<DravingLine>(); //Список с координатами для линий
        List<DravingLine> dravingKarandasch = new List<DravingLine>(); //Список с координатами для карандаша
        List<Pen> pens = new List<Pen>();

        public Form1()
        {
            InitializeComponent();
        }

        //Обьявления объектов
        Logick Lg = new Logick();
        DravingLine draw_ln = new DravingLine();
        History h = new History();
        Icon_Cursor ic = new Icon_Cursor();
        Pen pen = new Pen(Color.Black, 1);

        //Переменные
        int X;
        int Y;
        int X1;
        int Y1;
        bool[] Cliced = new bool[2];
        byte wi;
        byte id = 1;
        int count = 0;
        string fd;

        //Form1
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Кнопки инструментов
        //Карандаш
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.CheckOnClick = true;
            if (toolStripButton1.CheckState == CheckState.Checked) { Lg.Checked[6] = true; }
            else { Lg.Checked[6] = false; }
        }

        //Линия
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton2.CheckOnClick = true;
            if (toolStripButton2.CheckState == CheckState.Checked) { Lg.Checked[4] = true; }
            else { Lg.Checked[4] = false; }
        }

        //Прямоугольник
        private void kvadratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kvadratToolStripMenuItem.CheckOnClick = true;
            if (kvadratToolStripMenuItem.CheckState == CheckState.Checked) { Lg.Checked[3] = true; }
            else { Lg.Checked[3] = false; }
        }

        //MinusTolschina
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Всё это дело должно быть в функций PM
            Lg.Checked[1] = true;
            if (Lg.Checked[1] != false)
            {
                int WidthInt = Convert.ToInt32(toolStripLabel1.Text);
                string WidthSring = "1";

                if (WidthInt == 1) {} //Если WidthInt равен еденице, то ничего не делаем
                if (WidthInt > 1) //Если WidthInt больше еденицы вычитаем один
                {
                    WidthInt--;
                    pen.Width = WidthInt;
                    id--;
                }
                WidthSring = Convert.ToString(WidthInt);
                toolStripLabel1.Text = WidthSring;
            }
            Lg.Checked[1] = false;
        }

        //PlusTolschina
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Всё это дело должно быть в функций PM
            Lg.Checked[0] = true;
            if (Lg.Checked[0] != false)
            {
                byte WidthInt = Convert.ToByte(toolStripLabel1.Text);
                string WidthSring = "1";

                if (WidthInt == 50) {} //Если WidthInt равен пятидесяти, то ничего не делаем
                if (WidthInt < 50)  //Если WidthInt меньше пятидесяти, то прибовляем один
                {
                    WidthInt++;
                    pen.Width = WidthInt;
                    id++;
                    wi = WidthInt;
                }
                WidthSring = Convert.ToString(WidthInt);
                toolStripLabel1.Text = WidthSring;
            }
            Lg.Checked[0] = false;
        }
        #endregion

        #region Осушествление нажатий кнопки мыши
        //Нажатие кнопки мыши
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //Действия по линий
            if (e.Button == MouseButtons.Left && toolStripButton2.Checked == true)
            {
                Cliced[0] = true;
                X = e.X;
                Y = e.Y;
            }

            //Действия для карандаша
            if (e.Button == MouseButtons.Left && toolStripButton1.Checked == true)
            {
                Cliced[1] = true;
                draw_ln.dop_x1 = e.X;
                draw_ln.dop_y1 = e.Y;
            }
        }

        //Видение кнопки мыши
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ic.CursorPaint();

            //Действия по линий
            if (Cliced[0] == true)
            {
                X1 = e.X;
                Y1 = e.Y;
                pictureBox1.Invalidate();
            }

            //Действия для карандаша -->
            if (Cliced[1] == true)
            {
                draw_ln.dop_x2 = e.X;
                draw_ln.dop_y2 = e.Y;
                pictureBox1.Invalidate();
            }
            //--x Действия для карандаша
            if (toolStripButton1.Checked == true)
            {
                dravingKarandasch.Add(new DravingLine(new Point(draw_ln.dop_x1, draw_ln.dop_y1), new Point(draw_ln.dop_x2, draw_ln.dop_y2), id));
            }
        }

        //Отпускание кнопки мыши
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            count++;
            //Действия по линий
            if (toolStripButton2.Checked == true)
            {
                Cliced[0] = false;
                dravingLine.Add(new DravingLine(new Point(X, Y), new Point(X1, Y1), id, count));
            }

            Cliced[1] = false;
            Lg.Checked[3] = false;
        }

        //Отрисовка
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ic.CursorPaint();

            #region Отрисовка для линий
            //Действия по линий
            e.Graphics.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));

            Pen pensen_1 = new Pen(Color.Black, 1);
            Pen pensen_2 = new Pen(Color.Black, 2);
            Pen pensen_3 = new Pen(Color.Black, 3);
            Pen pensen_4 = new Pen(Color.Black, 4);
            Pen pensen_5 = new Pen(Color.Black, 5);
            Pen pensen_6 = new Pen(Color.Black, 6);
            Pen pensen_7 = new Pen(Color.Black, 7);
            Pen pensen_8 = new Pen(Color.Black, 8);
            Pen pensen_9 = new Pen(Color.Black, 9);
            Pen pensen_10 = new Pen(Color.Black, 10);
            Pen pensen_11 = new Pen(Color.Black, 11);
            Pen pensen_12 = new Pen(Color.Black, 12);
            Pen pensen_13 = new Pen(Color.Black, 13);
            Pen pensen_14 = new Pen(Color.Black, 14);
            Pen pensen_15 = new Pen(Color.Black, 15);
            Pen pensen_16 = new Pen(Color.Black, 16);
            Pen pensen_17 = new Pen(Color.Black, 17);
            Pen pensen_18 = new Pen(Color.Black, 18);
            Pen pensen_19 = new Pen(Color.Black, 19);
            Pen pensen_20 = new Pen(Color.Black, 20);
            Pen pensen_21 = new Pen(Color.Black, 21);
            Pen pensen_22 = new Pen(Color.Black, 22);
            Pen pensen_23 = new Pen(Color.Black, 23);
            Pen pensen_24 = new Pen(Color.Black, 24);
            Pen pensen_25 = new Pen(Color.Black, 25);
            Pen pensen_26 = new Pen(Color.Black, 26);
            Pen pensen_27 = new Pen(Color.Black, 27);
            Pen pensen_28 = new Pen(Color.Black, 28);
            Pen pensen_29 = new Pen(Color.Black, 29);
            Pen pensen_30 = new Pen(Color.Black, 30);
            Pen pensen_31 = new Pen(Color.Black, 31);
            Pen pensen_32 = new Pen(Color.Black, 32);
            Pen pensen_33 = new Pen(Color.Black, 33);
            Pen pensen_34 = new Pen(Color.Black, 34);
            Pen pensen_35 = new Pen(Color.Black, 35);
            Pen pensen_36 = new Pen(Color.Black, 36);
            Pen pensen_37 = new Pen(Color.Black, 37);
            Pen pensen_38 = new Pen(Color.Black, 38);
            Pen pensen_39 = new Pen(Color.Black, 39);
            Pen pensen_40 = new Pen(Color.Black, 40);
            Pen pensen_41 = new Pen(Color.Black, 41);
            Pen pensen_42 = new Pen(Color.Black, 42);
            Pen pensen_43 = new Pen(Color.Black, 43);
            Pen pensen_44 = new Pen(Color.Black, 44);
            Pen pensen_45 = new Pen(Color.Black, 45);
            Pen pensen_46 = new Pen(Color.Black, 46);
            Pen pensen_47 = new Pen(Color.Black, 47);
            Pen pensen_48 = new Pen(Color.Black, 48);
            Pen pensen_49 = new Pen(Color.Black, 49);
            Pen pensen_50 = new Pen(Color.Black, 50);

            foreach (var dl in dravingLine)
            {
                if (dl.id == 1) { e.Graphics.DrawLine(pensen_1, dl.X, dl.Y); }
                if (dl.id == 2) { e.Graphics.DrawLine(pensen_2, dl.X, dl.Y); }
                if (dl.id == 3) { e.Graphics.DrawLine(pensen_3, dl.X, dl.Y); }
                if (dl.id == 4) { e.Graphics.DrawLine(pensen_4, dl.X, dl.Y); }
                if (dl.id == 5) { e.Graphics.DrawLine(pensen_5, dl.X, dl.Y); }
                if (dl.id == 6) { e.Graphics.DrawLine(pensen_6, dl.X, dl.Y); }
                if (dl.id == 7) { e.Graphics.DrawLine(pensen_7, dl.X, dl.Y); }
                if (dl.id == 8) { e.Graphics.DrawLine(pensen_8, dl.X, dl.Y); }
                if (dl.id == 9) { e.Graphics.DrawLine(pensen_9, dl.X, dl.Y); }
                if (dl.id == 10) { e.Graphics.DrawLine(pensen_10, dl.X, dl.Y); }
                if (dl.id == 11) { e.Graphics.DrawLine(pensen_11, dl.X, dl.Y); }
                if (dl.id == 12) { e.Graphics.DrawLine(pensen_12, dl.X, dl.Y); }
                if (dl.id == 13) { e.Graphics.DrawLine(pensen_13, dl.X, dl.Y); }
                if (dl.id == 14) { e.Graphics.DrawLine(pensen_14, dl.X, dl.Y); }
                if (dl.id == 15) { e.Graphics.DrawLine(pensen_15, dl.X, dl.Y); }
                if (dl.id == 16) { e.Graphics.DrawLine(pensen_16, dl.X, dl.Y); }
                if (dl.id == 17) { e.Graphics.DrawLine(pensen_17, dl.X, dl.Y); }
                if (dl.id == 18) { e.Graphics.DrawLine(pensen_18, dl.X, dl.Y); }
                if (dl.id == 19) { e.Graphics.DrawLine(pensen_19, dl.X, dl.Y); }
                if (dl.id == 20) { e.Graphics.DrawLine(pensen_20, dl.X, dl.Y); }
                if (dl.id == 21) { e.Graphics.DrawLine(pensen_21, dl.X, dl.Y); }
                if (dl.id == 22) { e.Graphics.DrawLine(pensen_22, dl.X, dl.Y); }
                if (dl.id == 23) { e.Graphics.DrawLine(pensen_23, dl.X, dl.Y); }
                if (dl.id == 24) { e.Graphics.DrawLine(pensen_24, dl.X, dl.Y); }
                if (dl.id == 25) { e.Graphics.DrawLine(pensen_25, dl.X, dl.Y); }
                if (dl.id == 26) { e.Graphics.DrawLine(pensen_26, dl.X, dl.Y); }
                if (dl.id == 27) { e.Graphics.DrawLine(pensen_27, dl.X, dl.Y); }
                if (dl.id == 28) { e.Graphics.DrawLine(pensen_28, dl.X, dl.Y); }
                if (dl.id == 29) { e.Graphics.DrawLine(pensen_29, dl.X, dl.Y); }
                if (dl.id == 30) { e.Graphics.DrawLine(pensen_30, dl.X, dl.Y); }
                if (dl.id == 31) { e.Graphics.DrawLine(pensen_31, dl.X, dl.Y); }
                if (dl.id == 32) { e.Graphics.DrawLine(pensen_32, dl.X, dl.Y); }
                if (dl.id == 33) { e.Graphics.DrawLine(pensen_33, dl.X, dl.Y); }
                if (dl.id == 34) { e.Graphics.DrawLine(pensen_34, dl.X, dl.Y); }
                if (dl.id == 35) { e.Graphics.DrawLine(pensen_35, dl.X, dl.Y); }
                if (dl.id == 36) { e.Graphics.DrawLine(pensen_36, dl.X, dl.Y); }
                if (dl.id == 37) { e.Graphics.DrawLine(pensen_37, dl.X, dl.Y); }
                if (dl.id == 38) { e.Graphics.DrawLine(pensen_38, dl.X, dl.Y); }
                if (dl.id == 39) { e.Graphics.DrawLine(pensen_39, dl.X, dl.Y); }
                if (dl.id == 40) { e.Graphics.DrawLine(pensen_40, dl.X, dl.Y); }
                if (dl.id == 41) { e.Graphics.DrawLine(pensen_41, dl.X, dl.Y); }
                if (dl.id == 42) { e.Graphics.DrawLine(pensen_42, dl.X, dl.Y); }
                if (dl.id == 43) { e.Graphics.DrawLine(pensen_43, dl.X, dl.Y); }
                if (dl.id == 44) { e.Graphics.DrawLine(pensen_44, dl.X, dl.Y); }
                if (dl.id == 45) { e.Graphics.DrawLine(pensen_45, dl.X, dl.Y); }
                if (dl.id == 46) { e.Graphics.DrawLine(pensen_46, dl.X, dl.Y); }
                if (dl.id == 47) { e.Graphics.DrawLine(pensen_47, dl.X, dl.Y); }
                if (dl.id == 48) { e.Graphics.DrawLine(pensen_48, dl.X, dl.Y); }
                if (dl.id == 49) { e.Graphics.DrawLine(pensen_49, dl.X, dl.Y); }
                if (dl.id == 50) { e.Graphics.DrawLine(pensen_50, dl.X, dl.Y); }
            }
            #endregion

            e.Graphics.DrawLine(pen, new Point(draw_ln.dop_x1, draw_ln.dop_y1), new Point(draw_ln.dop_x2, draw_ln.dop_y2));
            foreach (var dk in dravingKarandasch)
            {
                e.Graphics.DrawLine(pen, dk.x1, dk.y1);
            }

        }
        #endregion

        //======================================
        Form2 Fr2 = new Form2();

        Form3 Fr3 = new Form3();
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fr3.Show();
        }

        //Функция пока что отсутствует
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //
            Lg.Create(pictureBox1.Width, pictureBox1.Height);
        }

        //Открыть файл
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //Сохранить куда
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "PNG (*PNG)|*png|JPG (*JPG)|jpg|BMP (*BMP)|*bmp|TIFF (*TIF;*TIFF)|";

            save.InitialDirectory = "C:\\";
            save.FilterIndex = 1;
            save.RestoreDirectory = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(bm, pictureBox1.ClientRectangle);

                fd = save.FileName;

                if (save.FilterIndex == 1) { bm.Save(fd + "." + "png"); }
                if (save.FilterIndex == 2) { bm.Save(fd + "." + "jpg"); }
                if (save.FilterIndex == 3) { bm.Save(fd + "." + "bmp"); }
                if (save.FilterIndex == 4) { bm.Save(fd + "." + "tif"); }
            }
        }
    }
}