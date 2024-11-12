using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualTrader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace VirtualTrader.Tests
{
    [TestClass()]
    public class TradeProcessorTests
    {
        private int CountRecords(Stream tradeStream)
        {
            int count = 0;
            string line;
            using (var reader = new StreamReader(tradeStream))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                }
                reader.Close();
                tradeStream.Close();    
            }
            return count;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoTestFile()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("");
            var tradeProcessor = new TradeProcessor();

            //Act
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert

        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void EmptyTestFile()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VirtualTraderTests.tradesEmpty.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert

        }
        [TestMethod]
        public void Test4tradesInFile()
        {
            // Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VirtualTraderTests.trades4.txt");
            var tradeProcessor = new TradeProcessor();
            // Act
            tradeProcessor.ProcessTrades(tradeStream);
            int count = CountRecords(tradeStream);

            // Assert
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void TestWronglyFormattedTrades()
        {
            // Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VirtualTraderTests.tradesBadFormats.txt");
            var tradeProcessor = new TradeProcessor();
            int startCount = CountRecords(tradeStream);
            // Act
            tradeProcessor.ProcessTrades(tradeStream);
            int endCount = CountRecords(tradeStream);
            // Assert
            Assert.AreEqual(endCount - startCount, 0);
        }

        [TestMethod]
        public void TestTradeAmountBoounds()
        {
            // Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VirtualTraderTests.tradesBounds.txt");
            var tradeProcessor = new TradeProcessor();
            int startCount = CountRecords(tradeStream);
            // Act
            tradeProcessor.ProcessTrades(tradeStream);
            int endCount = CountRecords(tradeStream);
            // Assert
            Assert.AreEqual(endCount - startCount, 2);
        }

    
    }
}