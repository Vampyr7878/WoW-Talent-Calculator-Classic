using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;

namespace WoW_Talent_Calculator_Classic
{
    //class to store talents
    class Talent
    {
        //file reader
        private Stream reader;

        //talent's icon
        public string Icon { get; }

        //talent's name
        public string Name { get; }

        //talent's max points
        public int Points { get; }

        //talent's dependancy
        public string Dependancy { get; }

        //arrow pointing dependancy
        public string Arrow { get; }

        //arrow's x coordinate
        public int X { get; }

        //arrow's y coordinate
        public int Y { get; }

        //talent's tier
        public int Tier { get; }

        //talent's ranks
        public Rank[] Ranks { get; }

        //current talent's rank
        public int Rank { set; get; }

        //talent's icon in color
        public Bitmap Picture { get; }

        //talent's icon in grayscale
        public Bitmap Gray { get; }

        //arrow's graphics in color
        public Bitmap Arrow1 { get; }

        //arrow's graphics in grayscale
        public Bitmap Arrow2 { get; }

        //talent's color
        public Color BackColor { set; get; }

        //read and set data
        public Talent(XmlNode talent)
        {
            Icon = talent.ChildNodes[0].InnerText;
            Name = talent.ChildNodes[1].InnerText;
            if (talent.ChildNodes[2].InnerText != "")
            {
                Points = int.Parse(talent.ChildNodes[2].InnerText);
            }
            else
            {
                Points = 0;
            }
            Dependancy = talent.ChildNodes[3].InnerText;
            if (talent.ChildNodes[4].HasChildNodes)
            {
                Arrow = talent.ChildNodes[4].ChildNodes[0].InnerText;
                X = int.Parse(talent.ChildNodes[4].ChildNodes[1].InnerText);
                Y = int.Parse(talent.ChildNodes[4].ChildNodes[2].InnerText);
            }
            else
            {
                Arrow = talent.ChildNodes[4].InnerText;
            }
            if (talent.ChildNodes[5].InnerText != "")
            {
                Tier = int.Parse(talent.ChildNodes[5].InnerText);
            }
            else
            {
                Tier = 0;
            }
            if (talent.ChildNodes[6].HasChildNodes)
            {
                Ranks = new Rank[talent.ChildNodes[6].ChildNodes.Count];
                for (int i = 0; i < Ranks.Count(); i++)
                {
                    Ranks[i] = new Rank(talent.ChildNodes[6].ChildNodes[i]);
                }
            }
            if (Icon != "")
            {
                reader = File.Open(@"Textures\Icons\" + Icon + ".png", FileMode.Open);
                Picture = new Bitmap(reader);
                reader.Close();
                Gray = Grayscale(Picture);
            }
            if (Arrow != "")
            {
                reader = File.Open(@"Textures\Arrows\" + Arrow + ".png", FileMode.Open);
                Arrow1 = new Bitmap(reader);
                reader.Close();
                Arrow2 = Grayscale(Arrow1);
            }
            BackColor = Color.Gray;
            if (Tier == 1)
            {
                if (Dependancy == "")
                {
                    BackColor = Color.Green;
                }
            }
            Rank = 0;
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
            if ((Tier - 1) * 5 <= spent)
            {
                if (Rank < Ranks.Count())
                {
                    Rank++;
                    return true;
                }
            }
            return false;
        }

        //decrease current talent's rank
        public bool DecreaseRank()
        {
            if (Rank > 0)
            {
                Rank--;
                return true;
            }
            return false;
        }
    }
}
