using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_practico_2
{
    public class CharacterCard : Card
    {
        public CharacterCard(string name, string rarity, int costPoints, string type, int attackPoints, int resistPoints, List<Card> equip, string affinity) : base(name, rarity, costPoints, type)
        {
            this.attackPoints = attackPoints;
            this.resistPoints = resistPoints;
            this.equip = equip;
            this.affinity = affinity;
        }
    }
}