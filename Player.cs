using System;

namespace PigDice
{
    public class Player
    {
        public string name;
        public int score;
        public bool endTurn;

        public Player(string name)
        {
            this.name = name;
        }
    }
}