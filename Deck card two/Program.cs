using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck_card
{
    class Program
    {
        static void Main ( string [] args )
        {
            Player player = new Player ();
            Deck deck = new Deck ();
            player.Work ( deck );
        }
    }

    class Player
    {
        private List<Card> _cardsPlayer = new List<Card> ();

        public void TakeCardPlayer ( Deck deckCard )
        {
            Random random = new Random ();
            int maxNumber = deckCard.CopyDeck ().Count;

            if ( deckCard.CopyDeck ().Count >= 1 )
            {
                Console.Write ( $"В колоде {deckCard.CopyDeck ().Count} карт.\nСколько хотете взять карт?\t" );
                int numberOfcards = int.Parse ( Console.ReadLine () );

                if ( numberOfcards <= maxNumber )
                {
                    for ( int i = 0; i < numberOfcards; i++ )
                    {
                        int rand = random.Next ( deckCard.CopyDeck ().Count );

                        _cardsPlayer.Add ( deckCard.CopyDeck () [ rand ] );
                        deckCard.DeleteCard ( rand );
                    }
                }

                else Console.WriteLine ( "Некорректное значение" );
            }

            Clear ();
        }

        public void ShowCardPlayer ()
        {
            if ( CopyDeck ().Count >= 1 )
            {
                Console.WriteLine ( "Ваши карты" );

                for ( int i = 0; i < CopyDeck ().Count; i++ )
                {
                    CopyDeck () [ i ].ShowDitalis ();
                }
            }

            else Console.WriteLine ( "У вас нет карт" );

            Clear ();
        }

        public void Work ( Deck deckCard )
        {

            string [] menu = { "Взять карту", "Посмотреть все карты", "Показать карты на руках", "Выход" };
            int index = 0;
            bool launchingTheProgram = true;

            while ( launchingTheProgram )
            {
                Console.SetCursorPosition ( 0, 0 );
                Console.ResetColor ();
                Console.WriteLine ( "\t\tМеню" );

                for ( int i = 0; i < menu.Length; i++ )
                {
                    if ( index == i )
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine ( menu [ i ] );
                    Console.ResetColor ();
                }

                ConsoleKeyInfo userInput = Console.ReadKey ( true );

                switch ( userInput.Key )
                {
                    case ConsoleKey.UpArrow:
                        if ( index != 0 ) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ( index != menu.Length - 1 ) index++;
                        break;
                    case ConsoleKey.Enter:

                        switch ( index )
                        {
                            case 0:
                                TakeCardPlayer ( deckCard );
                                break;
                            case 1:
                                deckCard.ShowCard ();
                                break;
                            case 2:
                                ShowCardPlayer ();
                                break;
                            case 3:
                                launchingTheProgram = !launchingTheProgram;
                                break;
                        }
                        break;
                }
            }
        }

        private List<Card> CopyDeck ()
        {
            List<Card> cards = _cardsPlayer.ToList ();
            return cards;
        }

        private void Clear ()
        {
            Console.ReadKey ();
            int numberVacation = 5;
            int numberOfRepetitions = 20;
            Console.SetCursorPosition ( 0, numberVacation );

            for ( int i = 0; i < numberOfRepetitions; i++ )
            {
                Console.WriteLine ( "\t\t\t\t\t\t\t\t\t" );
            }
        }
    }

    class Card
    {
        public Card ( string name, int numberRand )
        {
            Name = name;
            NumberRand = numberRand;
        }

        public string Name { get; private set; }
        public int NumberRand { get; private set; }

        public void ShowDitalis ()
        {
            Console.WriteLine ( $"Масть {Name} {NumberRand}" );
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card> ();

        public Deck ()
        {
            _cards.Add ( new Card ( "Буба", 7 ) );
            _cards.Add ( new Card ( "Пика", 9 ) );
            _cards.Add ( new Card ( "Крест", 10 ) );
            _cards.Add ( new Card ( "Чирва", 8 ) );
            _cards.Add ( new Card ( "Крест", 7 ) );
            _cards.Add ( new Card ( "Пика", 10 ) );
            _cards.Add ( new Card ( "Буба", 8 ) );
            _cards.Add ( new Card ( "Чирва", 9 ) );
        }

        public void DeleteCard ( int numberDelete )
        {
            _cards.RemoveAt ( numberDelete );
        }

        public List<Card> CopyDeck ()
        {
            List<Card> cards = _cards.ToList ();
            return cards;
        }

        public void ShowCard ()
        {
            if ( CopyDeck ().Count >= 1 )
            {
                Console.WriteLine ( "Все карты" );

                for ( int i = 0; i < CopyDeck ().Count; i++ )
                {
                    CopyDeck () [ i ].ShowDitalis ();
                }
            }

            else Console.WriteLine ( "Карт больше нет!" );

            Clear ();
        }

        private void Clear ()
        {
            Console.ReadKey ();
            int numberVacation = 5;
            int numberOfRepetitions = 20;
            Console.SetCursorPosition ( 0, numberVacation );

            for ( int i = 0; i < numberOfRepetitions; i++ )
            {
                Console.WriteLine ( "\t\t\t\t\t\t\t\t\t" );
            }
        }

    }
}
/*Есть колода с картами. Игрок достает карты, пока не решит, что ему хватит карт 
 *(может быть как выбор пользователя, так и количество сколько карт надо взять). 
 *После выводиться вся информация о вытянутых картах.
Возможные классы: Карта, Колода, Игрок*/
