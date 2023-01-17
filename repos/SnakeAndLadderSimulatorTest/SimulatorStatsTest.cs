using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeAndLadderSimulator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnakeAndLadderSimulatorTest
{
    [TestClass]
    public class SimulatorStatsTest
    {
        List<SnakeAndLadderSimulator.SnakeAndLadderSimulator> simulators = new List<SnakeAndLadderSimulator.SnakeAndLadderSimulator>();
        string[] outputLines = new string[1];

        [TestInitialize]
        public void SetUp()
        {
            var simulator1 = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(new int[1] { 22 });
            var turns1 = new List<Turn>();
            turns1.Add(BuildTurn(0, 1, new List<Roll>() { BuildRoll(1, false, false, false, false) }));
            turns1.Add(BuildTurn(1, 19, new List<Roll>() { BuildRoll(5, true, false, true, false) }));
            turns1.Add(BuildTurn(19, 23, new List<Roll>() { BuildRoll(4, false, false, true, false) }));
            turns1.Add(BuildTurn(23, 57, new List<Roll>() { BuildRoll(3, true, false, true, false) }));
            turns1.Add(BuildTurn(57, 45, new List<Roll>() { BuildRoll(6, false, false, false, false), BuildRoll(5, false, true, false, true) }));
            turns1.Add(BuildTurn(45, 95, new List<Roll>() { BuildRoll(6, true, false, true, false), BuildRoll(5, false, false, false, false) }));
            turns1.Add(BuildTurn(95, 100, new List<Roll>() { BuildRoll(5, false, false, true, false) }));
            simulator1.SetTurns(turns1);
            simulators.Add(simulator1);
            var simulator2 = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(new int[1] { 22 });
            var turns2 = new List<Turn>();
            turns2.Add(BuildTurn(0, 25, new List<Roll>() { BuildRoll(4, true, false, true, false) }));
            turns2.Add(BuildTurn(25, 28, new List<Roll>() { BuildRoll(3, true, false, true, false) }));
            turns2.Add(BuildTurn(28, 67, new List<Roll>() { BuildRoll(6, true, false, true, false), BuildRoll(4, false, true, false, true) }));
            turns2.Add(BuildTurn(67, 72, new List<Roll>() { BuildRoll(5, true, false, true, false) })); 
            turns2.Add(BuildTurn(72, 57, new List<Roll>() { BuildRoll(1, false, true, false, true) }));
            turns2.Add(BuildTurn(57, 58, new List<Roll>() { BuildRoll(1, false, false, false, false) }));
            turns2.Add(BuildTurn(58, 61, new List<Roll>() { BuildRoll(3, false, false, true, false) }));
            turns2.Add(BuildTurn(61, 100, new List<Roll>() { BuildRoll(6, true, false, true, false), BuildRoll(6, true, false, true, false) }));
            simulator2.SetTurns(turns2);
            simulators.Add(simulator2);
            var simulator3 = new SnakeAndLadderSimulator.SnakeAndLadderSimulator(new int[1] { 22 });
            var turns3 = new List<Turn>();
            turns3.Add(BuildTurn(0, 1, new List<Roll>() { BuildRoll(1, false, false, false, false) }));
            turns3.Add(BuildTurn(1, 55, new List<Roll>() { BuildRoll(6, true, false, true, false), BuildRoll(6, false, false, false, false), BuildRoll(6, false, false, true, false), BuildRoll(5, true, false, true, false) }));
            turns3.Add(BuildTurn(55, 56, new List<Roll>() { BuildRoll(1, false, false, false, false) }));
            turns3.Add(BuildTurn(56, 57, new List<Roll>() { BuildRoll(1, false, false, false, false) }));
            turns3.Add(BuildTurn(57, 93, new List<Roll>() { BuildRoll(6, false, true, false, true), BuildRoll(1, true, false, true, false) }));
            turns3.Add(BuildTurn(93, 96, new List<Roll>() { BuildRoll(3, true, false, true, false) }));
            turns3.Add(BuildTurn(96, 96, new List<Roll>() { BuildRoll(5, true, false, true, false) }));
            turns3.Add(BuildTurn(96, 96, new List<Roll>() { BuildRoll(6, true, false, true, false), BuildRoll(5, true, false, true, false) }));
            turns3.Add(BuildTurn(96, 100, new List<Roll>() { BuildRoll(4, false, false, true, false) }));
            simulator3.SetTurns(turns3);
            simulators.Add(simulator3);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\n");
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);
            Program.CalculateStats(simulators);
            outputLines = stringWriter.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        }

        public Turn BuildTurn(int startingValue, int endingvalue, List<Roll> rolls)
        {
            var turn = new Turn();
            turn.SetStartingPosition(startingValue);
            turn.SetRolls(rolls);
            turn.SetEndingPosition(endingvalue);
            return turn;
        }

        public Roll BuildRoll(int diceValue, bool isClimb, bool isSlide, bool isLuckyRoll, bool isUnLuckyRoll)
        {
            var roll = new Roll();
            roll.SetDiceValue(diceValue);
            roll.SetIsClimb(isClimb);
            roll.SetIsLuckyRoll(isLuckyRoll);
            roll.SetIsSlide(isSlide);
            roll.SetIsUnLuckyRoll(isUnLuckyRoll);
            return roll;
        }

        [TestMethod]
        public void TestSimulatorStats()
        {
            Assert.AreEqual(outputLines.Length, 19);
        }

        [TestMethod]
        public void TestSimulatorRollStats()
        {
            Assert.AreEqual(outputLines[1], "Maximum number of rolls needed to win: 14");
            Assert.AreEqual(outputLines[2], "Minimum number of rolls needed to win: 9");
            Assert.AreEqual(outputLines[3], "Average number of rolls needed to win: 11");
        }

        [TestMethod]
        public void TestSimulatorClimbsStats()
        {
            Assert.AreEqual(outputLines[4], "Maximum amount of climbs during the game: 7");
            Assert.AreEqual(outputLines[5], "Minimum amount of climbs during the game: 3");
            Assert.AreEqual(outputLines[6], "Average amount of climbs during the game: 5");
        }

        [TestMethod]
        public void TestSimulatorSlidesStats()
        {
            Assert.AreEqual(outputLines[7], "Maximum amount of slides during the game: 2");
            Assert.AreEqual(outputLines[8], "Minimum amount of slides during the game: 1");
            Assert.AreEqual(outputLines[9], "Average amount of slides during the game: 1");
        }

        [TestMethod]
        public void TestSimulatorBiggestSlide()
        {
            Assert.AreEqual(outputLines[10], "The biggest climb in a single turn: 54");
        }

        [TestMethod]
        public void TestSimulatorBiggestClimb()
        {
            Assert.AreEqual(outputLines[11], "The biggest slide in a single turn: 15");
        }

        [TestMethod]
        public void TestSimulatorLongestTurn()
        {
            Assert.AreEqual(outputLines[12], "The longest turn is the highest streak of consecutive rolls due to rolling 6s: [6,6,6,5]");
        }

        [TestMethod]
        public void TestSimulatorUnLuckyRollsStats()
        {
            Assert.AreEqual(outputLines[13], "Maximum unlucky rolls during the game: 2");
            Assert.AreEqual(outputLines[14], "Minimum unlucky rolls during the game: 1");
            Assert.AreEqual(outputLines[15], "Average unlucky rolls during the game: 1");
        }

        [TestMethod]
        public void TestSimulatorLuckyRollsStats()
        {
            Assert.AreEqual(outputLines[16], "Maximum lucky rolls during the game: 9");
            Assert.AreEqual(outputLines[17], "Minimum lucky rolls during the game: 5");
            Assert.AreEqual(outputLines[18], "Average lucky rolls during the game: 7");
        }
    }
}
