using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeAndLadderSimulator
{
    public class SnakeAndLadderBoard
    {
        private int[] snakesAndLaddersArray = new int[101];
        public SnakeAndLadderBoard()
        {
            for (int i = 0; i <= 100; i++)
            {
                snakesAndLaddersArray[i] = -1;
            }
            ReadBoardValues();
        }

        public int[] GetSnakesAndLadderArray()
        {
            return snakesAndLaddersArray;
        }

        private void ReadBoardValues()
        {
            Console.WriteLine("Enter the no.of Snakes and Ladders in the Board:");
            int snakesAndLaddersCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Snakes and Ladders Starting and Ending positions separated by ',' eg(46,32)");
            for (int i = 0; i < snakesAndLaddersCount; i++)
            {
                string snakesAndLaddersValue = Console.ReadLine();
                if (snakesAndLaddersValue != null && snakesAndLaddersValue.Contains(","))
                {
                    List<int> slList = snakesAndLaddersValue.Split(',').Select(int.Parse).ToList();
                    snakesAndLaddersArray[slList[0]] = slList[1];
                }
            }
        }
    }
}