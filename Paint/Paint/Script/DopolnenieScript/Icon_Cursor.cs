using System;
using System.Windows.Forms;

namespace Paint.Script.DopolnenieScript
{
    public class Icon_Cursor
    {
        Logick lg = new Logick();
        byte[] Control =
        {

        };

        const string DIR_CURSORS = @"C:\Users\нет-бук\Desktop\Paint\Paint\Ressorse\Cursors\";
        public void CursorPaint()
        {
            if (lg.Checked[4] != false || lg.Checked[4] != true)
            {
                Cursor cur;
                cur = new Cursor(DIR_CURSORS + "Line.cur");
                Cursor.Current = cur;
            }

            /*
            if (lg.Checked[3] != false || lg.Checked[3] != true)
            {
                Cursor cur;
                cur = new Cursor(DIR_CURSORS + "Geometr.cur");
                Cursor.Current = cur;
            }
            */
        }
    }
}
