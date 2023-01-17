using System.Collections.Generic;

namespace SnakeAndLadderSimulator
{
    public class Turn
    {
        private int startingPosition;
        private int endingPosition;
        private List<Roll> rolls = new List<Roll>();

        public int GetStartingPosition()
        {
            return startingPosition;
        }
        public int GetEndingPosition()
        {
            return endingPosition;
        }
        public List<Roll> GetRolls()
        {
            return rolls;
        }

        public void SetStartingPosition(int value)
        {
            startingPosition = value;
        }
        public void SetEndingPosition(int value)
        {
            endingPosition = value;
        }
        public void SetRolls(List<Roll> value)
        {
            rolls = value;
        }
    }
}
