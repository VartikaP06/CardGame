using System;

namespace CardDisplayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.StartGame();

            Console.WriteLine("Start Playing!");

            do
            {
                Console.WriteLine("Enter 'P' to Play a Card \n 'S' to Shuffle Deck \n 'R' to Restart Game");
                var option = Console.ReadLine();

                if (!Enum.IsDefined(typeof(GameOption), option))
                {
                    var userOption = option;
                    while (!Enum.IsDefined(typeof(GameOption), userOption))
                    {
                        Console.WriteLine($"You have entered an invalid option {userOption}");
                        Console.WriteLine("Please enter 'P' to Play a Card \n 'S' to Shuffle Deck \n 'R' to Restart Game");
                        userOption = Console.ReadLine();
                    }
                }
                else
                {
                    Enum.TryParse(option, out GameOption userOption);
                    game.PlayGame(userOption);
                }
            } while (game.Deck.CardDeck.Count > 0);
        }
    }
}
