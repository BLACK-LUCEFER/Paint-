using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public class Logick
    {
        #region Объяснение какая переменная за что отвечает
        /*
         * Переменная Checked с индексом [0] отвечает за кнопку [PlusTolschina]
         * Переменная Checked с индексом [1] отвечает за кнопку [MinusTolschina]
         * Переменная Checked с индексом [2] отвечает за кнопку [button1_Click в Form2]
         * Переменная Checked с индексом [3] отвечает за кнопку [kvadratToolStripMenuItem_Click в Form1]
         * 
         * Переменная Checked с индексом [4] отвечает за кнопку [toolStripButton2_Click в Form1]
         * Переменная Checked с индексом [5] отвечает за кнопку [button1_Click в Form3]
         * Переменная Checked с индексом [6] отвечает за кнопку [toolStripButton1_Click в Form1]
        */
        #endregion

        //Перемнные отвечающие нажата ли кнопка или нет
        public bool[] Checked = new bool[7];

        //Массвивы для определения координат фигр
        //Квадрат
        public int[] XY_Kvadrat = new int[8]; //X_Kvadrat,Y_Kvadrat,X2_Kvadrat,Y2_Kvadrat,X3_Kvadrat,Y3_Kvadrat,X4_Kvadrat,Y4_Kvadrat;
        public int[] XY_Kvadrat_2 = new int[4];
        void Kvadrat()
        {
            //Третья координат
            XY_Kvadrat_2[0] = XY_Kvadrat[0];
            XY_Kvadrat_2[1] = XY_Kvadrat[4];

            //Четвёртая координата
            XY_Kvadrat_2[2] = XY_Kvadrat[6];
            XY_Kvadrat_2[3] = XY_Kvadrat[1];

        }

        //
        public void WH(int w, int h)
        {
            int Wi = w;
            int He = h;
            Rasmer(Wi, He);
        }

        public int W, H;
        void Rasmer(int wi, int he)
        {
            W = wi;
            H = he;
        }

        public int PbW, PbH;
        public void Create(int pictureBoxWidth, int pictureBoxHeight)
        {
            PbW = pictureBoxWidth;
            PbH = pictureBoxHeight;
        }
    }
}