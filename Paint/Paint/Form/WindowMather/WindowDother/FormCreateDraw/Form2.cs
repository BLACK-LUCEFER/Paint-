using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        Logick Lg = new Logick();

        //Кнопка создать холст
        private void button1_Click(object sender, EventArgs e)
        {
            Lg.Checked[2] = true;
            int Witch = (int)numericUpDown1.Value;
            int Height = (int)numericUpDown2.Value;
            Lg.WH(Witch, Height);

            Lg.PbW = Lg.W;
            Lg.PbH = Lg.H;

            Lg.Checked[2] = false;

            Console.WriteLine("Ширина " + Lg.W);
            Console.WriteLine("Высота " + Lg.H);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
