using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_practico_2
{
    public class SupportSkillCard : Card
    {
        public SupportSkillCard(string name, string rarity, int costPoints, string type, string effecType, int effectPoints) : base(name, rarity, costPoints, type)
        {
            this.effectType = effecType;
            this.effectPoints = effectPoints;
        }
    }
}