using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Taller_practico_2
{
    public class Tests
    {
        private TestsData testsData = new TestsData();

        public Deck createDeckTest()
        {
            int costPoints = testsData.playerCP;
            List<Card> cards = new List<Card>();


            foreach (CardData card in testsData.cards)
            {
                Card cardx = new Card(card.name, card.rarity, card.costPoints, card.type);

                if (costPoints > card.costPoints && costPoints - card.costPoints != 0)
                {
                    cards.Add(cardx);
                    costPoints -= card.costPoints;
                }
                else
                {
                    break;
                }
            }

            Random random = new Random();
            cards.OrderBy<Card, int>((item) => random.Next()).ToList();

            Deck newDeck = new Deck(costPoints, cards);
            return newDeck;
        }

        public bool checkPlayerStatus(Deck deck)
        {

            for (int i = deck.cards.Count - 1; i > 0; i--)
            {
                if (deck.cards[i].type == "Character" && deck.cards[i].resistPoints <= 0)
                {
                    deck.cards.RemoveAt(i);
                }
            }

            int numberOfCharacters = 0;
            foreach (Card card in deck.cards)
            {
                if (card.type == "Character")
                {
                    numberOfCharacters++;
                }
            }

            if (numberOfCharacters <= 0)
            {
                return false;
            }

            return true;
        }

        public List<Deck> createPlayers()
        {
            Deck deck1 = createDeckTest();
            Deck deck2 = createDeckTest();

            List<Deck> decks = new List<Deck>() { deck1, deck2 };

            return decks;
        }

        public bool useCard(List<Deck> decks)
        {
            Card player1CharCard = null;
            Card player2CharCard = null;
            Card player1EquipCard = null;
            Card player2EquipCard = null;
            Card player1SupportCard = null;
            Card player2SupportCard = null;

            foreach (Card card in decks[0].cards)
            {
                if (card.type == "Character")
                {
                    if (player1CharCard == null)
                    {
                        player1CharCard = card;
                    }
                }
                else if (card.type == "Equip")
                {
                    if (player1EquipCard == null)
                    {
                        player1EquipCard = card;
                    }
                }
                else if (card.type == "Support Skill")
                {
                    if (player1SupportCard == null)
                    {
                        player1SupportCard = card;
                    }
                }
            }

            foreach (Card card in decks[1].cards)
            {
                if (card.type == "Character")
                {
                    if (player2CharCard == null)
                    {
                        player2CharCard = card;
                    }
                }
                else if (card.type == "Equip")
                {
                    if (player2EquipCard == null)
                    {
                        player2EquipCard = card;
                    }
                }
                else if (card.type == "Support Skill")
                {
                    if (player2SupportCard == null)
                    {
                        player2SupportCard = card;
                    }
                }
            }



            if (!useCharCard(player1CharCard, player2CharCard)) return false;
            if (!useEquipCard(player1EquipCard, player1CharCard)) return false;
            if (!useSupportCard(player1SupportCard, player2CharCard)) return false;

            return true;
        }

        public bool useCharCard(Card charCard1, Card charCard2)
        {

            if (charCard1.attackPoints == charCard2.resistPoints)
            {

                if (charCard1.affinity == "Kinght")
                {
                    if (charCard2.affinity == "Mage")
                    {
                        (charCard2.resistPoints) -= (charCard1.attackPoints + 2);
                    }
                }

                if (charCard1.affinity == "Mage")
                {
                    if (charCard2.affinity == "Undead")
                    {
                        (charCard2.resistPoints) -= (charCard1.attackPoints + 2);
                    }
                }

                if (charCard1.affinity == "Undead")
                {
                    if (charCard2.affinity == "Knight")
                    {
                        (charCard2.resistPoints) -= (charCard1.attackPoints + 2);
                    }
                }

            }
            else
            {
                charCard2.resistPoints -= charCard1.attackPoints;
            }

            return true;

        }

        public bool useEquipCard(Card equipCard1, Card charCard1)
        {
            if (equipCard1.affinity != charCard1.affinity && equipCard1.affinity != "ALL") return false;

            if (charCard1.equip != null && charCard1.equip.Count > 2) return false;

            if (equipCard1.targetAttribute == "AP")
            {
                charCard1.attackPoints += equipCard1.effectPoints;
            }
            else if (equipCard1.targetAttribute == "RP")
            {
                charCard1.resistPoints += equipCard1.effectPoints;
            }
            else if (equipCard1.targetAttribute == "ALL")
            {
                charCard1.attackPoints += equipCard1.effectPoints;
                charCard1.resistPoints += equipCard1.effectPoints;
            }

            if (equipCard1.equip != null)
            {
                charCard1.equip.Add(equipCard1);

            }
            return true;
        }

        public bool useSupportCard(Card supportCard1, Card objetiveCard)
        {
            if (supportCard1.effectType == "ReduceAP")
            {
                objetiveCard.attackPoints -= supportCard1.effectPoints;
            }
            else if (supportCard1.effectType == "ReduceRP")
            {
                objetiveCard.resistPoints -= supportCard1.effectPoints;
            }
            else if (supportCard1.effectType == "ReduceAll")
            {
                objetiveCard.attackPoints -= supportCard1.effectPoints;
                objetiveCard.resistPoints -= supportCard1.effectPoints;
            }
            else if (supportCard1.effectType == "DestroyEquip")
            {
                if (supportCard1.used == false)
                {
                    if (objetiveCard.type == "Character")
                    {
                        if (objetiveCard.equip.Count > 0)
                        {
                            Random rnd = new Random();
                            int index = rnd.Next(objetiveCard.equip.Count - 1);
                            removeEquip(objetiveCard, index);
                        }
                    }
                }

            }
            else if (supportCard1.effectType == "RestoreRP")
            {
                objetiveCard.resistPoints += supportCard1.effectPoints;
            }

            supportCard1.used = true;
            return true;
        }

        public bool removeEquip(Card objetiveCard, int index)
        {
            Card equipCard1 = objetiveCard.equip[index];

            if (equipCard1.targetAttribute == "AP")
            {
                objetiveCard.attackPoints -= equipCard1.effectPoints;
            }
            else if (equipCard1.targetAttribute == "RP")
            {
                objetiveCard.resistPoints -= equipCard1.effectPoints;
            }
            else if (equipCard1.targetAttribute == "ALL")
            {
                objetiveCard.attackPoints -= equipCard1.effectPoints;
                objetiveCard.resistPoints -= equipCard1.effectPoints;
            }

            objetiveCard.equip.RemoveAt(index);

            return true;
        }


        public bool testCardCreation()
        {
            string name = "Megatron";
            string rarity = "Rare";
            int points = 6;
            string type = "Rare";
            Card newCard = new Card(name, rarity, points, type);

            if (newCard.name == name && newCard.rarity == rarity && newCard.costPoints == points && newCard.type == type)
            {
                return true;
            }

            return false;
        }

        public bool verifyTypesOfCards(Deck deck)
        {
            int charCards = 0;
            int equipCards = 0;
            int supportCards = 0;

            foreach (Card card in deck.cards)
            {
                if (card.type == "character")
                {
                    charCards++;
                }
                else if (card.type == "equip")
                {
                    equipCards++;
                }
                else if (card.type == "support")
                {
                    supportCards++;
                }
            }

            if (charCards > 5) return false;
            if (equipCards > 10) return false;
            if (supportCards > 5) return false;

            return true;
        }

    }


}
