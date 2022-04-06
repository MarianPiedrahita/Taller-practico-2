using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taller_practico_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tests tests = new Tests();

            Deck deck = tests.createDeckTest();
            List<Deck> decks = tests.createPlayers();

            if (tests.useCard(decks)) Console.WriteLine("Test Passed");
            if (tests.testCardCreation()) Console.WriteLine("Test Passed");
            if (tests.verifyTypesOfCards(deck)) Console.WriteLine("Test Passed");
            if (tests.checkPlayerStatus(deck)) Console.WriteLine("Test Passed");

            Console.ReadLine();
        }
    }
}