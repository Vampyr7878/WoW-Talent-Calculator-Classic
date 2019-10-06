using System.Drawing;
using System.Linq;
using System.Xml;

namespace WoW_Talent_Calculator_Classic
{
    //class to store specialization trees
    class Specialization
    {
        //specialization's name
        public string Name { get; }

        //specialization's talents
        public Talent[] Talents { get; }

        //number of points spent in specific talent
        public int[] Spent { set; get; }

        public Specialization(XmlNode specialization, int x, int y) //read and set data
        {
            Spent = new int[x];
            Name = specialization.ChildNodes[0].InnerText;
            Talents = new Talent[x * y];
            for (int i = 0; i < Talents.Count(); i++)
            {
                if (i % y == 0)
                {
                    Spent[i / y] = 0;
                }
                Talents[i] = new Talent(specialization.ChildNodes[1].ChildNodes[i]);
            }
        }

        //check if talent is now available
        public bool Availability(Talent talent, int points)
        {
            if (talent.Rank == talent.Ranks.Count())
            {
                talent.BackColor = Color.Gold;
                return false;
            }
            else if ((talent.Tier - 1) * 5 > Spent.Sum())
            {
                talent.BackColor = Color.Gray;
                return false;
            }
            else
            {
                if (points == 0)
                {
                    if (talent.Rank == 0)
                    {
                        talent.BackColor = Color.Gray;
                    }
                    else
                    {
                        talent.BackColor = Color.Green;
                    }
                    return false;
                }
                else if (!Dependancy(talent))
                {
                    talent.BackColor = Color.Green;
                    return true;
                }
                else
                {
                    talent.BackColor = Color.Gray;
                    return false;
                }
            }
        }

        //show tooltip about talent
        public string Tooltip(Talent talent, int points)
        {
            string text;
            if (talent.Rank == 0)
            {
                text = "Rank " + talent.Rank.ToString() + "/" + talent.Ranks.Count().ToString() + "\n";
                if (Dependancy(talent))
                {
                    text += "Requires " + talent.Points + " points in " + talent.Dependancy + "\n";
                }
                if ((talent.Tier - 1) * 5 > Spent.Sum())
                {
                    text += "Requires " + (talent.Tier - 1) * 5 + " points in " + Name + " Talents\n";
                }
                text += talent.Ranks[talent.Rank].Description + "\n";
                if (Availability(talent, points))
                {
                    text += "Left click to learn\n";
                }
            }
            else if (talent.Rank == talent.Ranks.Count())
            {
                text = "Rank " + talent.Rank.ToString() + "/" + talent.Ranks.Count().ToString() + "\n";
                text += talent.Ranks[talent.Rank - 1].Description + "\n";
                text += "Right click to unlearn";
            }
            else
            {
                text = "Rank " + talent.Rank.ToString() + "/" + talent.Ranks.Count().ToString() + "\n";
                text += talent.Ranks[talent.Rank - 1].Description + "\n\n";
                text += "Next rank:\n";
                text += talent.Ranks[talent.Rank].Description + "\n";
                text += "Left click to learn\n";
                text += "Right click to unlearn";
            }
            return text;
        }

        //check if talent's dependancy is completed
        public bool Dependancy(Talent talent)
        {
            if (talent.Dependancy != "")
            {
                if (FindTalent(talent.Dependancy).Rank < talent.Points)
                {
                    return true;
                }
            }
            return false;
        }

        //find talent with specific name
        private Talent FindTalent(string name)
        {
            for (int i = 0; i < Talents.Length; i++)
            {
                if (Talents[i].Name == name)
                {
                    return Talents[i];
                }
            }
            return null;
        }

        //check if any talent depends on specifc talent
        public bool Dependant(Talent talent)
        {
            Talent dependant = FindDependancy(talent.Name);
            if (dependant != null)
            {
                if (dependant.Rank > 0)
                {
                    return true;
                }
            }
            return false;
        }

        //find dependand talent
        private Talent FindDependancy(string name)
        {
            for (int i = 0; i < Talents.Length; i++)
            {
                if (Talents[i].Dependancy == name)
                {
                    return Talents[i];
                }
            }
            return null;
        }

        //check if you can decrease specific talent's rank
        public bool EmptyTiers(int tier)
        {
            int sum = 0;
            if (tier == Spent.Length)
            {
                return true;
            }
            if (Spent[tier] > 0)
            {
                for (int i = tier - 1; i >= 0; i--)
                {
                    sum += Spent[i];
                }
                if (sum > tier * 5)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
