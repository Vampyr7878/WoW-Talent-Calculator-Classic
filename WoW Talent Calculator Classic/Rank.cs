using System;
using System.Xml;

namespace WoW_Talent_Calculator_Classic
{
    //class to store different ranks of the talent
    class Rank
    {
        //rank's number
        private int number;
        //rank's description
        private string description;

        //read data
        public Rank(XmlNode rank)
        {
            number = Int32.Parse(rank.ChildNodes[0].InnerText);
            description = rank.ChildNodes[1].InnerText;
        }

        public string Description
        {
            get { return description; }
        }
    }
}
