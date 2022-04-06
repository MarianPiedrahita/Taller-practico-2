using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_practico_2
{
    public class Card
    {
        public string name { get; set; }

        public string rarity { get; set; }

        public int costPoints { get; set; }

        public string type { get; set; }

        public bool used { get; set; } = false;

        public int attackPoints { get; set; }
        public int resistPoints { get; set; }
        public List<Card> equip { get; set; }
        public string affinity { get; set; }
        public string targetAttribute { get; set; }
        public int effectPoints { get; set; }
        public string effectType { get; set; }


        public Card(string name, string rarity, int costPoints, string type)
        {
            this.name = name;
            this.rarity = rarity;
            this.costPoints = costPoints;
            this.type = type;
        }
    }
}