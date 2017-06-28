using System.Drawing;
using System.Windows.Forms;

namespace WoW_Talent_Calculator_Classic
{
    //extension of ToolTip class to allow more formatted text
    class FormattedToolTip : ToolTip
    {
        //length of tooltip
        int length;

        //allow to override drawing with custom one
        public FormattedToolTip(int length)
            : base()
        {
            this.length = length;
            this.OwnerDraw = true;
            this.Draw += new DrawToolTipEventHandler(this.onDraw);
        }

        //format text
        private void onDraw(object sender, DrawToolTipEventArgs e)
        {
            string[] lines = e.ToolTipText.Split('\n');
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(Brushes.Black, e.Bounds);
            graphics.DrawRectangle(new Pen(Brushes.Gray, 1), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
            graphics.DrawString(this.ToolTipTitle, new Font(e.Font, FontStyle.Regular), Brushes.White, new PointF(e.Bounds.X + 1, e.Bounds.Y + 1));
            graphics.DrawString(lines[0], new Font(e.Font, FontStyle.Regular), Brushes.White, new PointF(e.Bounds.X, e.Bounds.Y + 16));
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i] == "Left click to learn")
                {
                    graphics.DrawString(lines[i], new Font(e.Font, FontStyle.Regular), Brushes.Green, new PointF(e.Bounds.X, e.Bounds.Y + 16 + 15 * i));
                }
                else if (lines[i] == "Right click to unlearn")
                {
                    graphics.DrawString(lines[i], new Font(e.Font, FontStyle.Regular), Brushes.Red, new PointF(e.Bounds.X, e.Bounds.Y + 16 + 15 * i));
                }
                else if (lines[i].StartsWith("Requires"))
                {
                    graphics.DrawString(lines[i], new Font(e.Font, FontStyle.Regular), Brushes.Red, new PointF(e.Bounds.X, e.Bounds.Y + 16 + 15 * i));
                }
                else
                {
                    graphics.DrawString(lines[i], new Font(e.Font, FontStyle.Regular), Brushes.Yellow, new PointF(e.Bounds.X, e.Bounds.Y + 16 + 15 * i));
                }
            }
        }

        //split text to lines that fit tooltip's length
        public void Show(string text, IWin32Window window, int x, int y)
        {
            string[] lines = text.Split('\n');
            string[] words;
            string temp;
            string final = "";
            foreach (string line in lines)
            {
                if (line.Length > length)
                {
                    words = line.Split(' ');
                    temp = "";
                    foreach (string word in words)
                    {
                        if (temp.Length < length)
                        {
                            if (length - temp.Length >= word.Length)
                            {
                                temp += word + " ";
                            }
                            else
                            {
                                final += temp + "\n";
                                temp = word + " ";
                            }
                        }
                        else
                        {
                            final += temp + "\n";
                            temp = word + " ";
                        }
                    }
                    final += temp + "\n";
                }
                else
                {
                    final += line + "\n";
                }
            }
            base.Show(final, window, x, y);
        }
    }
}
