using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnakeAndLadderSimulator;
using System;

namespace SnakeAndLadderSimulatorTest
{
    [TestClass]
    public class SnakeAndLadderSimulatorTests
    {
        int[] sl = new int[101];

        [TestInitialize]
        public void SetUp()
        {
            for (int i = 0; i <= 100; i++)
            {
                sl[i] = -1;
            }
            sl[99] = 41;
            sl[89] = 53;
            sl[76] = 58;
            sl[66] = 45;
            sl[54] = 31;
            sl[43] = 18;
            sl[40] = 3;
            sl[27] = 5;
            sl[4] = 25;
            sl[13] = 46;
            sl[33] = 49;
            sl[42] = 63;
            sl[50] = 69;
            sl[62] = 81;
            sl[74] = 92;
        }

        [TestMethod]
        public void TestPlayGameEndingValue()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            simulator.PlayGame();
            var turns = simulator.GetTurns();
            Assert.AreEqual(100, turns[turns.Count -1].GetEndingPosition());
            Assert.AreEqual(0, turns[0].GetStartingPosition());
        }

        [TestMethod]
        public void TestNextMoveLadder()
        {
            Mock<Random> Random = new Mock<Random>();
            Random.Setup(random => random.Next(It.IsAny<int>(),It.IsAny<int>())).Returns(5);
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Turn t = simulator.nextMove(8, Random.Object);
            Assert.AreEqual(46, t.GetEndingPosition());
        }

        [TestMethod]
        public void TestNextMoveSnake()
        {
            Mock<Random> Random = new Mock<Random>();
            Random.Setup(random => random.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(3);
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Turn t = simulator.nextMove(40, Random.Object);
            Assert.AreEqual(18, t.GetEndingPosition());
        }

        [TestMethod]
        public void TestNextMoveSix()
        {
            Mock<Random> Random = new Mock<Random>();
            Random.SetupSequence(random => random.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(6).Returns(6).Returns(2);
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Turn t = simulator.nextMove(40, Random.Object);
            Assert.AreEqual(31, t.GetEndingPosition());
            Assert.AreEqual(3, t.GetRolls().Count);
        }

        [TestMethod]
        public void TestNextMove94()
        {
            Mock<Random> Random = new Mock<Random>();
            Random.SetupSequence(random => random.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(6).Returns(6).Returns(4);
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Turn t = simulator.nextMove(96, Random.Object);
            Assert.AreEqual(100, t.GetEndingPosition());
            Assert.AreEqual(3, t.GetRolls().Count);
        }

        [TestMethod]
        public void TestIsRollUnLuckySnake()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 85);
            Assert.IsTrue(r.GetIsUnLuckyRoll());
            Assert.IsFalse(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollLuckyLadder()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 46);
            Assert.IsFalse(r.GetIsUnLuckyRoll());
            Assert.IsTrue(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollLuckySnakeMissBy1()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(2);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 26);
            Assert.IsFalse(r.GetIsUnLuckyRoll());
            Assert.IsTrue(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollLuckySnakeMissBy2()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(3);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 26);
            Assert.IsFalse(r.GetIsUnLuckyRoll());
            Assert.IsTrue(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollNotLuckySnakeMissBy3()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 26);
            Assert.IsFalse(r.GetIsUnLuckyRoll());
            Assert.IsFalse(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollLuckyPerfect100()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 96);
            Assert.IsFalse(r.GetIsUnLuckyRoll());
            Assert.IsTrue(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollNotLuckyNotPerfect100()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 94);
            Assert.IsFalse(r.GetIsUnLuckyRoll());
            Assert.IsFalse(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollUnLuckyNotPerfect100Snake()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsLuckyOrUnLucky(roll, 95);
            Assert.IsTrue(r.GetIsUnLuckyRoll());
            Assert.IsFalse(r.GetIsLuckyRoll());
        }

        [TestMethod]
        public void TestIsRollSlide()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsSlideOrClimb(roll, 95);
            Assert.IsTrue(r.GetIsSlide());
            Assert.IsFalse(r.GetIsClimb());
        }

        [TestMethod]
        public void TestIsRollNotSlide()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsSlideOrClimb(roll, 94);
            Assert.IsFalse(r.GetIsSlide());
            Assert.IsFalse(r.GetIsClimb());
        }

        [TestMethod]
        public void TestIsRollClimb()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsSlideOrClimb(roll, 0);
            Assert.IsFalse(r.GetIsSlide());
            Assert.IsTrue(r.GetIsClimb());
        }

        [TestMethod]
        public void TestIsRollNotClimb()
        {
            SnakeAndLadderSimulator.SnakeAndLadderSimulator simulator = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(sl);
            Roll roll = new Roll();
            roll.SetDiceValue(4);
            Roll r = simulator.checkRollIsSlideOrClimb(roll, 3);
            Assert.IsFalse(r.GetIsSlide());
            Assert.IsFalse(r.GetIsClimb());
        }
    }
}
