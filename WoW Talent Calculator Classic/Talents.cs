using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace WoW_Talent_Calculator_Classic
{
    public partial class Talents : Form
    {
        //specializations
        private Specialization[] specializations;
        //talent's buttons
        private Button[, ,] buttons;
        //talent's labels
        private Label[, ,] labels;
        //specialization's label
        private Label[] spent;
        //specialization's spent points
        private Label[] points;
        //specialization's panel
        private Panel[] panels;
        //arrow's pictureboxes
        private PictureBox[] arrows;
        //class xml file
        private XmlDocument classFile;
        //file writer
        private StreamWriter writer;
        //file reader
        private StreamReader reader;
        //graphics handler
        private Graphics[] graphics;
        //talent's tooltip
        private FormattedToolTip toolTip;
        //talent's coordinates
        private int t, x, y;
        //loop helpers
        private int i, j, k;
        //additional loop helpers
        private int a, b, c;
        //points left to spent
        private int pointsLeft;
        //helper to handle mouse clicks
        private bool click;
        //current class
        private string current;

        //setup application
        public Talents()
        {
            toolTip = new FormattedToolTip(50);
            ReadSettings();
            click = false;
            InitializeComponent();
            ClientSize = new Size(386 + SystemInformation.VerticalScrollBarWidth, 390);
            tabs.Width += SystemInformation.VerticalScrollBarWidth;
            Set();
        }

        //read settings file
        private void ReadSettings()
        {
            reader = new StreamReader(File.Open(@"settings.txt", FileMode.Open));
            t = int.Parse(reader.ReadLine());
            x = int.Parse(reader.ReadLine());
            y = int.Parse(reader.ReadLine());
            pointsLeft = int.Parse(reader.ReadLine());
            reader.Close();
        }

        //setup all elements
        private void Set()
        {
            left.Text = pointsLeft.ToString();
            buttons = new Button[t, x, y];
            labels = new Label[t, x, y];
            spent = new Label[t];
            points = new Label[t];
            panels = new Panel[t];
            arrows = new PictureBox[t];
            graphics = new Graphics[t];
            i = 0;
            foreach (TabPage tab in tabs.TabPages)
            {
                tab.Width -= SystemInformation.VerticalScrollBarWidth;
                panels[i] = new Panel();
                SetPanel(panels[i], tab);
                tab.Controls.Add(panels[i]);
                spent[i] = new Label();
                SetLabel(spent[i], new Point(3, 5), "Points spent in Specialization Talents: ");
                panels[i].Controls.Add(spent[i]);
                points[i] = new Label();
                SetLabel(points[i], new Point(233, 5), "0");
                panels[i].Controls.Add(points[i]);
                for (j = 0; j < x; j++)
                {
                    for (k = 0; k < y; k++)
                    {
                        labels[i, j, k] = new Label();
                        SetTalentLabel(labels[i, j, k], new Point(60 * k + 49, 60 * j + 70));
                        panels[i].Controls.Add(labels[i, j, k]);
                        buttons[i, j, k] = new Button();
                        SetTalentButton(buttons[i, j, k], new Point(60 * k + 12, 60 * j + 32));
                        panels[i].Controls.Add(buttons[i, j, k]);
                    }
                }
                arrows[i] = new PictureBox();
                SetPictureBox(arrows[i], panels[i]);
                graphics[i] = Graphics.FromImage(arrows[i].BackgroundImage);
                panels[i].Controls.Add(arrows[i]);
                i++;
            }
        }

        //reset application
        private void Clear()
        {
            left.Text = pointsLeft.ToString();
            i = 0;
            foreach (TabPage tab in tabs.TabPages)
            {
                SetLabel(spent[i], new Point(3, 5), "Points spent in Specialization Talents: ");
                SetLabel(points[i], new Point(233, 5), "0");
                for (j = 0; j < x; j++)
                {
                    for (k = 0; k < y; k++)
                    {
                        SetTalentLabel(labels[i, j, k], new Point(60 * k + 49, 60 * j + 70));
                        SetTalentButton(buttons[i, j, k], new Point(60 * k + 12, 60 * j + 32));
                    }
                }
                SetPictureBox(arrows[i], panels[i]);
                graphics[i] = Graphics.FromImage(arrows[i].BackgroundImage);
                i++;
            }
        }

        //setup picturebox element
        private void SetPictureBox(PictureBox pictureBox, Panel panel)
        {
            pictureBox.Size = panel.Size;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImage = new Bitmap(panel.Size.Width, panel.Size.Height);
            for (j = 0; j < pictureBox.BackgroundImage.Width; j++)
            {
                for (k = 0; k < pictureBox.BackgroundImage.Height; k++)
                {
                    ((Bitmap)pictureBox.BackgroundImage).SetPixel(j, k, Color.Transparent);
                }
            }
        }

        //setup panel element
        private void SetPanel(Panel panel, TabPage tab)
        {
            panel.BackgroundImageLayout = ImageLayout.Stretch;
            panel.Location = new Point(0, 0);
            panel.Size = new Size(252, x * 60 + 32);
        }

        //setup label element
        private void SetLabel(Label label, Point position, string text)
        {
            label.AutoSize = true;
            label.BackColor = Color.FromArgb(0, 0, 0, 0);
            label.ForeColor = Color.Yellow;
            label.Location = position;
            label.Text = text;
        }

        //setup talent's label element
        private void SetTalentLabel(Label label, Point position)
        {
            label.Location = position;
            label.Size = new Size(14, 14);
            label.Text = "";
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Hide();
            label.BringToFront();
        }

        //setup talent's button element
        private void SetTalentButton(Button button, Point position)
        {
            button.Location = position;
            button.Size = new Size(48, 48);
            button.Text = "";
            button.FlatStyle = FlatStyle.Flat;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Hide();
            button.MouseEnter += new EventHandler(this.Talents_MouseEnter);
            button.MouseLeave += new EventHandler(this.Talents_MouseLeave);
            button.MouseDown += new MouseEventHandler(this.Talents_MouseDown);
            button.MouseUp += new MouseEventHandler(this.Talents_MouseUp);
        }

        //load class' specialization
        private void LoadSpecialization(string className, Specialization specialization, int index)
        {
            panels[index].BackgroundImage = new Bitmap(@"Textures\" + className + "\\" + specialization.Name + ".png");
            tabs.TabPages[index].Text = specialization.Name;
            spent[index].Text = "Points spent in " + specialization.Name + " Talents: ";
            for (j = 0; j < x; j++)
            {
                for (k = 0; k < y; k++)
                {
                    if (specialization.Talents[k + j + 3 * j].Icon != "")
                    {
                        SetTalnet(specialization, buttons[index, j, k], labels[index, j, k], panels[index], arrows[index], graphics[index], k + j + 3 * j);
                    }
                }
            }
            arrows[index].Refresh();
        }

        //setup specific talent
        private void SetTalnet(Specialization specialization, Button button, Label label, Panel panel, PictureBox arrow, Graphics graphic, int index)
        {
            button.BackgroundImage = specialization.Talents[index].Gray;
            button.Show();
            label.Text = specialization.Talents[index].Rank.ToString();
            if (specialization.Talents[index].Tier == 1)
            {
                if (specialization.Talents[index].Dependancy == "")
                {
                    label.Show();
                    button.BackgroundImage = specialization.Talents[index].Picture;
                }
            }
            button.FlatAppearance.BorderColor = specialization.Talents[index].BackColor;
            button.BackColor = specialization.Talents[index].BackColor;
            label.ForeColor = specialization.Talents[index].BackColor;
            label.BackColor = Color.Black;
            if (specialization.Talents[index].Arrow != "")
            {
                graphic.DrawImage(specialization.Talents[index].Arrow2, specialization.Talents[index].X, specialization.Talents[index].Y, specialization.Talents[index].Arrow2.Width, specialization.Talents[index].Arrow2.Height);
            }
        }

        //redraw window to applay changes
        private void Redraw()
        {
            for (i = 0; i < t; i++)
            {
                graphics[i].Clear(Color.Transparent);
                foreach (Talent talent in specializations[i].Talents)
                {
                    if (talent.Name != "")
                    {
                        specializations[i].Availability(talent, pointsLeft);
                    }
                }
                points[i].Text = specializations[i].Spent.Sum().ToString();
                left.Text = pointsLeft.ToString();
                for (j = 0; j < x; j++)
                {
                    for (k = 0; k < y; k++)
                    {
                        RedrawTalent(specializations[i], buttons[i, j, k], labels[i, j, k], arrows[i], graphics[i], k + j + 3 * j);
                    }
                }
                arrows[i].Refresh();
            }
        }

        //redraw specific talent
        private void RedrawTalent(Specialization specialization, Button button, Label label, PictureBox arrow, Graphics graphic, int index)
        {
            if (specialization.Talents[index].BackColor == Color.Gray)
            {
                label.Hide();
            }
            else
            {
                label.Show();
            }
            if (label.Enabled)
            {
                label.Text = specialization.Talents[index].Rank.ToString();
                label.ForeColor = specialization.Talents[index].BackColor;
            }
            if (button.Enabled)
            {
                button.FlatAppearance.BorderColor = specialization.Talents[index].BackColor;
                button.BackColor = specialization.Talents[index].BackColor;
                if ((specialization.Talents[index].Tier - 1) * 5 <= specialization.Spent.Sum())
                {
                    if (!specialization.Dependancy(specialization.Talents[index]))
                    {
                        if (pointsLeft == 0 && specialization.Talents[index].Rank == 0)
                        {
                            button.BackgroundImage = specialization.Talents[index].Gray;
                        }
                        else
                        {
                            button.BackgroundImage = specialization.Talents[index].Picture;
                        }
                    }
                    else
                    {
                        button.BackgroundImage = specialization.Talents[index].Gray;
                    }
                }
                else
                {
                    button.BackgroundImage = specialization.Talents[index].Gray;
                }
                if (specialization.Talents[index].Arrow != "")
                {
                    if ((specialization.Talents[index].Tier - 1) * 5 <= specialization.Spent.Sum())
                    {
                        if (!specialization.Dependancy(specialization.Talents[index]))
                        {
                            graphic.DrawImage(specialization.Talents[index].Arrow1, specialization.Talents[index].X, specialization.Talents[index].Y, specialization.Talents[index].Arrow2.Width, specialization.Talents[index].Arrow2.Height);
                        }
                        else
                        {
                            graphic.DrawImage(specialization.Talents[index].Arrow2, specialization.Talents[index].X, specialization.Talents[index].Y, specialization.Talents[index].Arrow2.Width, specialization.Talents[index].Arrow2.Height);
                        }
                    }
                    else
                    {
                        graphic.DrawImage(specialization.Talents[index].Arrow2, specialization.Talents[index].X, specialization.Talents[index].Y, specialization.Talents[index].Arrow2.Width, specialization.Talents[index].Arrow2.Height);
                    }
                }
            }
        }

        //open and read class file
        private void OpenTalnets(string name)
        {
            classFile = new XmlDocument();
            classFile.Load(@"Data\" + name + ".xml");
            specializations = new Specialization[classFile.ChildNodes[1].ChildNodes.Count];
            for (i = 0; i < specializations.Count(); i++)
            {
                specializations[i] = new Specialization(classFile.ChildNodes[1].ChildNodes[i], x, y);
                LoadSpecialization(name, specializations[i], i);
            }
        }

        //save current build
        private void SaveFile()
        {
            try
            {
                if (current != null)
                {
                    saveFileDialog.FileName = current + ".bld";
                    saveFileDialog.ShowDialog();
                    writer = new StreamWriter(File.Create(saveFileDialog.FileName));
                    writer.WriteLine(current);
                    for (a = 0; a < specializations.Count(); a++)
                    {
                        for (b = 0; b < specializations[a].Talents.Count(); b++)
                        {
                            writer.WriteLine(specializations[a].Talents[b].Rank.ToString());
                        }
                    }
                    writer.Close();
                }
            }
            catch
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        //load saved build
        private void OpenFile()
        {
            try
            {
                int rank;
                MouseEventArgs mouse = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                openFileDialog.FileName = "";
                openFileDialog.ShowDialog();
                reader = new StreamReader(File.Open(openFileDialog.FileName, FileMode.Open));
                current = reader.ReadLine();
                OpenTalnets(current);
                for (a = 0; a < specializations.Count(); a++)
                {
                    tabs.SelectedIndex = a;
                    for (b = 0; b < specializations[a].Talents.Count(); b++)
                    {
                        rank = Int32.Parse(reader.ReadLine());
                        if (specializations[a].Talents[b].Name != "")
                        {
                            specializations[a].Talents[b].Rank = rank;
                            specializations[a].Spent[specializations[a].Talents[b].Tier - 1] += rank;
                            pointsLeft -= rank;
                            Redraw();
                        }
                    }
                }
                reader.Close();
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        //event handler for buttons
        private void button_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Save":
                    SaveFile();
                    break;
                case "Open":
                    ReadSettings();
                    Clear();
                    OpenFile();
                    break;
                case "Reset":
                    if (current != null)
                    {
                        ReadSettings();
                        Clear();
                        OpenTalnets(current);
                    }
                    break;
                default:
                    ReadSettings();
                    Clear();
                    current = ((Button)sender).Text;
                    OpenTalnets(current);
                    break;
            }
        }

        //event handler for talents to support mouse hover
        private void Talents_MouseEnter(object sender, EventArgs e)
        {
            int index;
            index = (((Button)sender).Location.X - 12) / 60 + (((Button)sender).Location.Y - 32) / 60 + 3 * ((((Button)sender).Location.Y - 32) / 60);
            toolTip.ToolTipTitle = specializations[tabs.SelectedIndex].Talents[index].Name;
            toolTip.Show(specializations[tabs.SelectedIndex].Tooltip(specializations[tabs.SelectedIndex].Talents[index], pointsLeft), (Button)sender, 48, 48);
        }

        //event handler for talents to support mouse hover
        private void Talents_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide((Button)sender);
        }

        //event handler for talents to support mouse clicks
        private void Talents_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
        }

        //event handler for talents to support mouse clicks
        private void Talents_MouseUp(object sender, MouseEventArgs e)
        {
            if (click)
            {
                int index;
                i = tabs.SelectedIndex;
                j = (((Button)sender).Location.Y - 32) / 60;
                k = (((Button)sender).Location.X - 12) / 60;
                index = k + j + 3 * j;
                if (pointsLeft > 0 && e.Button == MouseButtons.Left)
                {
                    if (!specializations[i].Dependancy(specializations[i].Talents[index]))
                    {
                        if (specializations[i].Talents[index].IncreaseRank(specializations[i].Spent.Sum()))
                        {
                            specializations[i].Spent[specializations[i].Talents[index].Tier - 1]++;
                            pointsLeft--;
                            Redraw();
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (specializations[i].EmptyTiers(specializations[i].Talents[index].Tier))
                    {
                        if (!specializations[i].Dependant(specializations[i].Talents[index]))
                        {
                            if (specializations[i].Talents[index].DecreaseRank())
                            {
                                specializations[i].Spent[specializations[i].Talents[index].Tier - 1]--;
                                pointsLeft++;
                                Redraw();
                            }
                        }
                    }
                }
                Talents_MouseEnter(sender, e);
                click = false;
            }
        }
    }
}
