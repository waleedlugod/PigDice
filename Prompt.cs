using System;

namespace PigDice
{
    public static class Prompt
    {
        public static int AskPlayers()
        {
            int playerCount;

            bool isValid = false;
            do
            {
                Console.Write("Enter amount of players: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out playerCount);
                if (isValid && playerCount < 2)
                {
                    isValid = false;
                }
            } while (!isValid);

            return playerCount;
        }

        public static string AskMove(Player player)
        {
            bool isValid = false;
            string move;

            do
            {
                Console.WriteLine("What would " + player.name + " like to do?");
                Console.WriteLine("\tR - ROLL\n" + "\tH - HOLD");
                move = Console.ReadLine();
                move = move.ToUpper();
                switch (move)
                {
                    case "R":
                    case "ROLL":
                    case "H":
                    case "HOLD":
                        isValid = true;
                        break;
                }
            } while (!isValid);

            return move;
        }
    }
}