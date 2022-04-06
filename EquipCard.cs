using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_practico_2
{
    public class EquipCard : Card
    {
        public EquipCard(string name, string rarity, int costPoints, string type, string targetAttribute, int effectPoints, string affinity) : base(name, rarity, costPoints, type)
        {
            this.targetAttribute = targetAttribute;
            this.effectPoints = effectPoints;
            this.affinity = affinity;
        }
    }
}
