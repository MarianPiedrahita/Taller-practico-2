using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_practico_2
{
    public class TestsData
    {
        public List<CardData> cards = new List<CardData>();
        //cartas de personaje
        private CardData charCard1 = new CardData("Megatron", "Common", 2, "Character", 5, 2, "Mage", null, 0, null);
        private CardData charCard2 = new CardData("Cokun", "Ultra Rare", 16, "Character", 20, 15, "Knight", null, 0, null);
        private CardData charCard3 = new CardData("Tony Giusepelli", "Super Rare", 12, "Character", 6, 17, "Undead", null, 0, null);
        private CardData charCard4 = new CardData("Pamcito Ratache", "Super Rare", 12, "Character", 18, 3, "Mage", null, 0, null);
        private CardData charCard5 = new CardData("Neko Arc", "Rare", 3, "Character", 6, 6, null, "Undead", 0, null);
        //cartas de equipamiento
        private CardData equipCard1 = new CardData("Mr Chicken Sword", "Super Rare", 10, "Equip", 0, 0, "Knight", "AP", 12, null);
        private CardData equipCard2 = new CardData("Spike Sword", "Common", 3, "Equip", 0, 0, "Undead", "AP", 6, null);
        private CardData equipCard3 = new CardData("Staff of Virgilium", "Ultra Rare", 20, "Equip", 0, 0, "Mage", "ALL", 20, null);
        private CardData equipCard4 = new CardData("Avenger Shield", "Super Rare", 10, "Equip", 0, 0, "Knight", "RP", 12, null);
        private CardData equipCard5 = new CardData("Nokia 3200", "Ultra Rare", 3, "Equip", 0, 0, "ALL", "ALL", 25, null);
        private CardData equipCard6 = new CardData("Parry Shield", "Common", 5, "Equip", 0, 0, "Undead", "ALL", 5, null);
        private CardData equipCard7 = new CardData("Moonlight Sword", "Super Rare", 15, "Equip", 0, 0, "Knight", "AP", 15, null);
        private CardData equipCard8 = new CardData("Vampires Coat", "Rare", 3, "Equip", 0, 0, "Mage", "RP", 8, null);
        private CardData equipCard9 = new CardData("Grimoire Weiss", "Ultra Rare", 16, "Equip", 0, 0, "Mage", "AP", 20, null);
        private CardData equipCard10 = new CardData("Skateboard", "Rare", 6, "Equip", 0, 0, "Undead", "ALL", 6, null);
        //cartas especiales de soporte
        private CardData supportSkillCard1 = new CardData("Favor from Allah", "Rare", 8, "Support Skill", 0, 0, null, null, 12, "RestoreRP");
        private CardData supportSkillCard2 = new CardData("Lightness from Ra", "Common", 8, "Support Skill", 0, 0, null, null, 0, "DestroyEquip");
        private CardData supportSkillCard3 = new CardData("Hatred of Hel", "Common", 8, "Support Skill", 0, 0, null, null, 12, "ReduceAll");
        private CardData supportSkillCard4 = new CardData("Strength of Thor", "Ultra Rare", 8, "Support Skill", 0, 0, null, null, 12, "ReduceAP");
        private CardData supportSkillCard5 = new CardData("Wisdom of Odin", "Super Rare", 8, "Support Skill", 0, 0, null, null, 12, "ReduceRP");
        public int playerCP = 165;

        public TestsData()
        {
            cards.Add(charCard1);
            cards.Add(charCard2);
            cards.Add(charCard3);
            cards.Add(charCard4);
            cards.Add(charCard5);

            cards.Add(equipCard1);
            cards.Add(equipCard2);
            cards.Add(equipCard3);
            cards.Add(equipCard4);
            cards.Add(equipCard5);
            cards.Add(equipCard6);
            cards.Add(equipCard7);
            cards.Add(equipCard8);
            cards.Add(equipCard9);
            cards.Add(equipCard10);

            cards.Add(supportSkillCard1);
            cards.Add(supportSkillCard2);
            cards.Add(supportSkillCard3);
            cards.Add(supportSkillCard4);
            cards.Add(supportSkillCard5);
        }
    }

    public struct CardData
    {
        public string name;
        public string rarity;
        public int costPoints;
        public string type;
        public int attackPoints;
        public int resistPoints;
        public List<Card> equip;
        public string affinity;
        public string targetAttribute;
        public int effectPoints;
        public string effectType;

        public CardData(string name, string rarity, int costPoints, string type, int attackPoints, int resistPoints, string affinity, string targetAttribute, int effectPoints, string effectType)
        {
            this.name = name;
            this.rarity = rarity;
            this.costPoints = costPoints;
            this.type = type;
            this.attackPoints = attackPoints;
            this.resistPoints = resistPoints;
            this.equip = new List<Card>();
            this.affinity = affinity;
            this.targetAttribute = targetAttribute;
            this.effectPoints = effectPoints;
            this.effectType = effectType;
        }
    }
}
