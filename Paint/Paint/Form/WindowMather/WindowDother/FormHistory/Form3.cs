using System;
using Paint.Script.FormScript.HistoryScript;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        //Обьявления объектов
        DravingLine dl = new DravingLine();
        History h = new History();
        Logick lg = new Logick();

        //Обьявления переменных
        public int count;
        public int cou;

        public int HistoryDelete
        {
            get
            {
                if (lg.Checked[6] != false) { cou = count; }
                return cou;
            }
        }

        //Вернуть историю назад
        private void button1_Click(object sender, EventArgs e)
        {
            lg.Checked[6] = true;
            lg.Checked[6] = false;
        }

        //Вернуть историю вперёд
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
