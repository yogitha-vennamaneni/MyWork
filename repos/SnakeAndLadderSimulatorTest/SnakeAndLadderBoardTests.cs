using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeAndLadderSimulator;
using System;
using System.IO;
using System.Text;

namespace SnakeAndLadderSimulatorTest
{
    [TestClass]
    public class SnakeAndLadderBoardTests
    {
        [TestInitialize]
        public void DataReader()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5");
            stringBuilder.AppendLine("77,54");
            stringBuilder.AppendLine("35,7");
            stringBuilder.AppendLine("16,4");
            stringBuilder.AppendLine("45,88");
            stringBuilder.AppendLine("3,46");
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);
        }

        [TestMethod]
        public void TestSnakesAndLaddersCount()
        {          
            SnakeAndLadderBoard snakeAndLadderBoard = new SnakeAndLadderBoard();
            Assert.AreEqual(5, Array.FindAll(snakeAndLadderBoard.GetSnakesAndLadderArray(), x => x != -1).Length);
        }

        [TestMethod]
        public void TestSnakesAndLadderValues()
        {
            SnakeAndLadderBoard snakeAndLadderBoard = new SnakeAndLadderBoard();
            var array = snakeAndLadderBoard.GetSnakesAndLadderArray();
            Assert.AreEqual(54, array[77]);
            Assert.AreEqual(7, array[35]);
            Assert.AreEqual(4, array[16]);
            Assert.AreEqual(88, array[45]);
            Assert.AreEqual(46, array[3]);
        }
    }
}
