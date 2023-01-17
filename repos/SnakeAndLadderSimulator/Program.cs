using System;
using System.Collections.Generic;

namespace SnakeAndLadderSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SnakeAndLadderBoard board = new SnakeAndLadderBoard();
            Console.WriteLine("Enter the no.of Simulation to run:");
            int simulationCount = Convert.ToInt32(Console.ReadLine());
            List<SnakeAndLadderSimulator> simulators = new List<SnakeAndLadderSimulator>(simulationCount);
            for (int i = 0; i < simulationCount; i++)
            {
                SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator(board.GetSnakesAndLadderArray());
                simulator.PlayGame();
                simulators.Add(simulator);
            }
            CalculateStats(simulators);
        }

        public static void CalculateStats(List<SnakeAndLadderSimulator> simulators)
        {
            int minRolls = 0, maxRols = 0, avgRolls = 0, minClimbs = 0, maxClimbs = 0, avgClimbs = 0, minSlides = 0, maxSlides = 0,
                avgSlides = 0, biggestSlide = 0, biggestClimb = 0, minUnLucky = 0, maxUnLucky = 0, avgUnLucky = 0, minLucky = 0,
                maxLucky = 0, avgLucky = 0;
            List<Roll> longestTurn = new List<Roll>();
            foreach (SnakeAndLadderSimulator s in simulators)
            {
                int count = 0, slides = 0, unLuckyRolls = 0, luckyRolls = 0, climbs = 0;
                var turns = s.GetTurns();
                turns.ForEach(x => {
                    int movement = x.GetEndingPosition() - x.GetStartingPosition();
                    if (movement > 0 && biggestClimb < movement)
                    {
                        biggestClimb = movement;
                    }
                    if (movement < 0)
                    {
                        movement = 0 - movement;
                        if (biggestSlide < movement)
                        {
                            biggestSlide = movement;
                        }
                    }
                    var rolls = x.GetRolls();
                    if (longestTurn.Count < rolls.Count)
                    {
                        longestTurn = rolls;
                    }
                    else if (longestTurn.Count == rolls.Count)
                    {
                        if (longestTurn[longestTurn.Count - 1].GetDiceValue() < rolls[rolls.Count - 1].GetDiceValue())
                        {
                            longestTurn = rolls;
                        }
                    }
                    count += rolls.Count;
                    slides += rolls.FindAll(y => y.GetIsSlide()).Count;
                    unLuckyRolls += rolls.FindAll(y => y.GetIsUnLuckyRoll()).Count;
                    luckyRolls += rolls.FindAll(y => y.GetIsLuckyRoll()).Count;
                    climbs += rolls.FindAll(y => y.GetIsClimb()).Count;
                });
                if (minRolls == 0)
                {
                    minRolls = count;
                }
                if (count < minRolls)
                {
                    minRolls = count;
                }
                if (count > maxRols)
                {
                    maxRols = count;
                }
                if (minSlides == 0)
                {
                    minSlides = slides;
                }
                if (slides < minSlides)
                {
                    minSlides = slides;
                }
                if (slides > maxSlides)
                {
                    maxSlides = slides;
                }
                if (minClimbs == 0)
                {
                    minClimbs = climbs;
                }
                if (climbs < minClimbs)
                {
                    minClimbs = climbs;
                }
                if (climbs > maxClimbs)
                {
                    maxClimbs = climbs;
                }
                if (minUnLucky == 0)
                {
                    minUnLucky = unLuckyRolls;
                }
                if (unLuckyRolls < minUnLucky)
                {
                    minUnLucky = unLuckyRolls;
                }
                if (unLuckyRolls > maxUnLucky)
                {
                    maxUnLucky = unLuckyRolls;
                }
                if (minLucky == 0)
                {
                    minLucky = luckyRolls;
                }
                if (luckyRolls < minLucky)
                {
                    minLucky = luckyRolls;
                }
                if (luckyRolls > maxLucky)
                {
                    maxLucky = luckyRolls;
                }
            }
            avgRolls = (minRolls + maxRols) / 2;
            avgClimbs = (minClimbs + maxClimbs) / 2;
            avgSlides = (minSlides + maxSlides) / 2;
            avgUnLucky = (minUnLucky + maxUnLucky) / 2;
            avgLucky = (minLucky + maxLucky) / 2;
            string longest = "[";
            longestTurn.ForEach(x => longest += x.GetDiceValue().ToString() + ",");
            longest = longest.Remove(longest.Length - 1, 1) + "]";
            Console.WriteLine("Below are the Stats of Simulator Runs:");
            Console.WriteLine("Maximum number of rolls needed to win: " + maxRols);
            Console.WriteLine("Minimum number of rolls needed to win: " + minRolls);
            Console.WriteLine("Average number of rolls needed to win: " + avgRolls);
            Console.WriteLine("Maximum amount of climbs during the game: " + maxClimbs);
            Console.WriteLine("Minimum amount of climbs during the game: " + minClimbs);
            Console.WriteLine("Average amount of climbs during the game: " + avgClimbs);
            Console.WriteLine("Maximum amount of slides during the game: " + maxSlides);
            Console.WriteLine("Minimum amount of slides during the game: " + minSlides);
            Console.WriteLine("Average amount of slides during the game: " + avgSlides);
            Console.WriteLine("The biggest climb in a single turn: " + biggestClimb);
            Console.WriteLine("The biggest slide in a single turn: " + biggestSlide);
            Console.WriteLine("The longest turn is the highest streak of consecutive rolls due to rolling 6s: " + longest);
            Console.WriteLine("Maximum unlucky rolls during the game: " + maxUnLucky);
            Console.WriteLine("Minimum unlucky rolls during the game: " + minUnLucky);
            Console.WriteLine("Average unlucky rolls during the game: " + avgUnLucky);
            Console.WriteLine("Maximum lucky rolls during the game: " + maxLucky);
            Console.WriteLine("Minimum lucky rolls during the game: " + minLucky);
            Console.WriteLine("Average lucky rolls during the game: " + avgLucky);
            Console.ReadLine();
        }
    }
}
