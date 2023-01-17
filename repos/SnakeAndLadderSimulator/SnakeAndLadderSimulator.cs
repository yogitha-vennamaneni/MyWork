using System;
using System.Collections.Generic;

namespace SnakeAndLadderSimulator
{
    public class SnakeAndLadderSimulator
    {
        private List<Turn> turns = new List<Turn>();
        private int[] snakesAndLadders = new int[101];
        private Random dice = new Random();
        public SnakeAndLadderSimulator(int[] sl)
        {
            snakesAndLadders = sl;
        }

        public List<Turn> GetTurns()
        {
            return turns;
        }
        public void SetTurns(List<Turn> value)
        {
            turns = value;
        }

        public void PlayGame()
        {
            int currentPosition = 0;
            do
            {
                Turn turn = nextMove(currentPosition, dice);
                turns.Add(turn);
                currentPosition = turn.GetEndingPosition();
            } while (currentPosition < 100);
        }

        public Turn nextMove(int currentPosition, Random dice)
        {
            Turn turn = new Turn();
            turn.SetStartingPosition(currentPosition);
            List<Roll> rolls = new List<Roll>();
            int nextPosition = currentPosition;
            int diceValue;
            do
            {
                diceValue = dice.Next(1, 7);
                Roll roll = new Roll();
                roll.SetDiceValue(diceValue);
                if (currentPosition < 94)
                {
                    nextPosition = currentPosition + diceValue;
                    if (snakesAndLadders[nextPosition] != -1)
                    {
                        nextPosition = snakesAndLadders[nextPosition];
                    }
                }
                else
                {
                    if (currentPosition + diceValue <= 100)
                    {
                        nextPosition = currentPosition + diceValue;
                    }
                }
                roll = checkRollIsLuckyOrUnLucky(roll, currentPosition);
                roll = checkRollIsSlideOrClimb(roll, currentPosition);
                currentPosition = nextPosition;
                rolls.Add(roll);
            } while (diceValue == 6);
            turn.SetRolls(rolls);
            turn.SetEndingPosition(nextPosition);
            return turn;
        }

        public Roll checkRollIsLuckyOrUnLucky(Roll roll, int currentPosition)
        {
            int diceValue = roll.GetDiceValue();
            if (currentPosition + diceValue <= 100)
            {
                int nextPosition = snakesAndLadders[currentPosition + diceValue];
                if (nextPosition != -1 & currentPosition > nextPosition)
                {
                    roll.SetIsUnLuckyRoll(true);
                }
                if ((currentPosition + diceValue) <= 100 &&
                        ((nextPosition != -1 & currentPosition < nextPosition) |
                        (1 < (currentPosition + diceValue) &&
                            snakesAndLadders[currentPosition + diceValue - 1] != -1 &&
                            snakesAndLadders[currentPosition + diceValue - 1] < currentPosition) |
                        (2 < (currentPosition + diceValue) &&
                            snakesAndLadders[currentPosition + diceValue - 2] != -1 &&
                            snakesAndLadders[currentPosition + diceValue - 2] < currentPosition) |
                        (currentPosition >= 94 && currentPosition + diceValue == 100)))
                {
                    roll.SetIsLuckyRoll(true);
                }
            }
            return roll;            
        }

        public Roll checkRollIsSlideOrClimb(Roll roll, int currentPosition)
        {
            int diceValue = roll.GetDiceValue();
            if (currentPosition + diceValue <= 100)
            {
                int nextPosition = snakesAndLadders[currentPosition + diceValue];
                if (nextPosition != -1 & currentPosition > nextPosition)
                {
                    roll.SetIsSlide(true);
                }
                if (nextPosition != -1 & currentPosition < nextPosition)
                {
                    roll.SetIsClimb(true);
                }
            }
            return roll;
        }
    }
}
