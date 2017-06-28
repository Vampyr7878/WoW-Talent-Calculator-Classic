using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;

namespace WoW_Talent_Calculator_Classic
{
    //class to store talents
    class Talent
    {
        //talent's icon
        private string icon;
        //talent's name
        private string name;
        //talent's max points
        private int points;
        //talent's dependancy
        private string dependancy;
        //arrow pointing dependancy
        private string arrow;
        //arrow's coordinates
        private int x, y;
        //talent's tier
        private int tier;
        //talent's ranks
        private Rank[] ranks;
        //current talent's rank
        private int rank;
        //talent's icons in color and grayscale
        private Bitmap picture, gray;
        //arrow's graphics in color and grayscale
        private Bitmap arrow1, arrow2;
        //file reader
        private Stream reader;
        //talent's color
        private Color backColor;

        //read and set data
        public Talent(XmlNode talent)
        {
            icon = talent.ChildNodes[0].InnerText;
            name = talent.ChildNodes[1].InnerText;
            if (talent.ChildNodes[2].InnerText != "")
            {
                points = Int32.Parse(talent.ChildNodes[2].InnerText);
            }
            else
            {
                points = 0;
            }
            dependancy = talent.ChildNodes[3].InnerText;
            if (talent.ChildNodes[4].HasChildNodes)
            {
                arrow = talent.ChildNodes[4].ChildNodes[0].InnerText;
                x = Int32.Parse(talent.ChildNodes[4].ChildNodes[1].InnerText);
                y = Int32.Parse(talent.ChildNodes[4].ChildNodes[2].InnerText);
            }
            else
            {
                arrow = talent.ChildNodes[4].InnerText;
            }
            if (talent.ChildNodes[5].InnerText != "")
            {
                tier = Int32.Parse(talent.ChildNodes[5].InnerText);
            }
            else
            {
                tier = 0;
            }
            if (talent.ChildNodes[6].HasChildNodes)
            {
                ranks = new Rank[talent.ChildNodes[6].ChildNodes.Count];
                for (int i = 0; i < ranks.Count(); i++)
                {
                    ranks[i] = new Rank(talent.ChildNodes[6].ChildNodes[i]);
                }
            }
            if (icon != "")
            {
                reader = File.Open(@"Textures\Icons\" + icon + ".png", FileMode.Open);
                picture = new Bitmap(reader);
                reader.Close();
                gray = Grayscale(picture);
            }
            if (arrow != "")
            {
                reader = File.Open(@"Textures\Arrows\" + arrow + ".png", FileMode.Open);
                arrow1 = new Bitmap(reader);
                reader.Close();
                arrow2 = Grayscale(arrow1);
            }
            backColor = Color.Gray;
            if (tier == 1)
            {
                if (dependancy == "")
                {
                    backColor = Color.Green;
                }
            }
            rank = 0;
        }

        public string Icon
        {
            get { return icon; }
        }

        public string Name
        {
            get { return name; }
        }

        public int Points
        {
            get { return points; }
        }

        public string Dependancy
        {
            get { return dependancy; }
        }

        public string Arrow
        {
            get { return arrow; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int Tier
        {
            get { return tier; }
        }

        public Rank[] Ranks
        {
            get { return ranks; }
        }

        public int Rank
        {
            set { rank = value; }
            get { return rank; }
        }

        public Bitmap Picture
        {
            get { return picture; }
        }

        public Bitmap Gray
        {
            get { return gray; }
        }

        public Bitmap Arrow1
        {
            get { return arrow1; }
        }

        public Bitmap Arrow2
        {
            get { return arrow2; }
        }

        public Color BackColor
        {
            set { backColor = value; }
            get { return backColor; }
        }

        //change color bitmap to grayscale
        private Bitmap Grayscale(Bitmap bitmap)
        {
            Color color;
            int value;
            Bitmap temp = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    if (color.A == 255)
                    {
                        value = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        temp.SetPixel(i, j, Color.FromArgb(value, value, value));
                    }
                }
            }
            return temp;
        }

        //increase current talent's rank
        public bool IncreaseRank(int spent)
        {
            if ((tier - 1) * 5 <= spent)
            {
                if (rank < ranks.Count())
                {
                    rank++;
                    return true;
                }
            }
            return false;
        }

        //decrease current talent's rank
        public bool DecreaseRank()
        {
            if (rank > 0)
            {
                rank--;
                return true;
            }
            return false;
        }
    }
}
