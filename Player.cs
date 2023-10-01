using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Oktober
{
    public class Player
    {
        public string name;
        public int score;
        public Hands Choice;
        public Player(string Name)
        {
            name = Name;
        }

        // player options
        public void RandomHand()
        {
            Random random = new Random();
            int RandomChoice = random.Next(3);
            switch (RandomChoice)
            {
                case 1: Choice = Hands.Rock;
                    Console.WriteLine("Bot chose Rock");
                    break;
                case 2: Choice = Hands.Paper;
                    Console.WriteLine("Bot chose Paper");
                    break;
                case 3: Choice = Hands.Scissors;
                    Console.WriteLine("Bot chose Scissors");
                    break;
            }
        }
        public void Hand()
        {
            bool PickHand = true;
            while (PickHand)
            {
                Console.WriteLine("Player " + name + ", pick (r)ock, (p)aper, or (s)cissors");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "r":
                        Choice = Hands.Rock;
                        PickHand = false;
                        break;
                    case "p":
                        Choice = Hands.Paper;
                        PickHand = false;
                        break;
                    case "s":
                        Choice = Hands.Scissors;
                        PickHand = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
