using System;
using System.Collections.Generic;

namespace PigDice
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_SCORE = 100;
            List<Player> players = new List<Player>();
            Player winner = new Player("Nobody");
            bool gameOver = false;

            int playerCount = Prompt.AskPlayers();

            // Setups player names
            for (int i = 1; i <= playerCount; i++)
            {
                string playerNum = i.ToString();

                Player player = new Player("Player" + playerNum);
                players.Add(player);
            }

            while (!gameOver)
            {
                for (int currPlayer = 0; currPlayer < players.Count; currPlayer++)
                {
                    players[currPlayer].endTurn = false;
                    while (!players[currPlayer].endTurn && !gameOver)
                    {
                        Console.Clear();
                        Console.WriteLine(players[currPlayer].name + "'s score: " + players[currPlayer].score);

                        string move = Prompt.AskMove(players[currPlayer]);

                        Move.Execute(move, players[currPlayer]);
                        players[currPlayer].score = 101;

                        // If player won
                        if (players[currPlayer].score > MAX_SCORE)
                        {
                            winner = players[currPlayer];
                            gameOver = true;
                        }
                        // If player rolled a 1
                        else if (players[currPlayer].score == 0)
                        {
                            players[currPlayer].endTurn = true;
                        }

                        Console.WriteLine(players[currPlayer].name + "'s score: " + players[currPlayer].score);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }

                    if (gameOver)
                    {
                        currPlayer = playerCount + 1;
                    }
                }   
            }

            Console.WriteLine(winner.name + " won!!!");
            Console.WriteLine("Score of all players:");
            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine(players[i].name + " 's score: " + players[i].score);
            }
        }
    }
}
