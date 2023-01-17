namespace SnakeAndLadderSimulator
{
    public class Roll
    {
        private int diceValue;
        private bool isClimb;
        private bool isSlide;
        private bool isLuckyRoll;
        private bool isUnLuckyRoll;

        public int GetDiceValue()
        {
            return diceValue;
        }
        public bool GetIsUnLuckyRoll()
        {
            return isUnLuckyRoll;
        }
        public bool GetIsLuckyRoll()
        {
            return isLuckyRoll;
        }
        public bool GetIsSlide()
        {
            return isSlide;
        }
        public bool GetIsClimb()
        {
            return isClimb;
        }

        public void SetDiceValue(int value)
        {
            diceValue = value;
        }
        public void SetIsUnLuckyRoll(bool value)
        {
            isUnLuckyRoll = value;
        }
        public void SetIsLuckyRoll(bool value)
        {
            isLuckyRoll = value;
        }
        public void SetIsSlide(bool value)
        {
            isSlide = value;
        }
        public void SetIsClimb(bool value)
        {
            isClimb = value;
        }
    }
}
