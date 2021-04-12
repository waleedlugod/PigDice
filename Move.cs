using System;

namespace PigDice
{
    public static class Move
    {

        public static void Execute(string move, Player player)
        {
            switch (move)
            {
                case "R":
                case "ROLL":
                    Move.Roll(player);
                    break;
                case "H":
                case "HOLD":
                    player.endTurn = true;
                    break;
            }
        }
        public static void Roll(Player player)
        {
            Random rnd = new Random();
            for (int i = 0; i < 2; i++)
            {
                int face = rnd.Next(1, 6);
                
                Console.WriteLine(player.name + " rolled a " + face);

                switch (face)
                {
                    case 1:
                        player.score = 0;
                        i += 99; // Stop rolling
                        break;
                    default:
                        player.score += face;
                        break;
                }
            }
        }
    }
}