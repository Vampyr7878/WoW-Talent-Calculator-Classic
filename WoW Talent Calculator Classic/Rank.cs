using System.Xml;

namespace WoW_Talent_Calculator_Classic
{
    //class to store different ranks of the talent
    class Rank
    {
        //rank's number
        private int number;

        //rank's description
        public string Description { get; }

        //read data
        public Rank(XmlNode rank)
        {
            number = int.Parse(rank.ChildNodes[0].InnerText);
            Description = rank.ChildNodes[1].InnerText;
        }
    }
}
