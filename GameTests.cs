using GuessNumberGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumberGame.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void Game_StartTest_RegularNumber()
        {
            Game game = new Game();
            IUserInput fakeUserInput_RegularNumber = new FakeUserInput("2");
            bool gameFinishedSuccessfully;
            gameFinishedSuccessfully = game.Start(fakeUserInput_RegularNumber);
            Assert.IsTrue(gameFinishedSuccessfully);  
        }

        [TestMethod()]
        public void Game_start_NumberOutOfRange()
        {
            Game game = new Game();
            IUserInput fakeUserInput_NumberAboveRange = new FakeUserInput("101");
            bool gameFinishedSuccessfully;
            gameFinishedSuccessfully = game.Start(fakeUserInput_NumberAboveRange);
            Assert.IsFalse(gameFinishedSuccessfully);
        }

        [TestMethod()]
        public void Game_start_NumberBelowRange()
        {
            Game game = new Game();
            IUserInput fakeUserInput_NumberBelowRange = new FakeUserInput("-1");
            bool gameFinishedSuccessfully;
            gameFinishedSuccessfully = game.Start(fakeUserInput_NumberBelowRange);
            Assert.IsFalse(gameFinishedSuccessfully);
        }

        [TestMethod()]
        public void Game_start_NoNumber()
        {
            Game game = new Game();
            IUserInput fakeUserInput_NoNumber = new FakeUserInput("a");
            bool gameFinishedSuccessfully;
            gameFinishedSuccessfully = game.Start(fakeUserInput_NoNumber);
            Assert.IsFalse(gameFinishedSuccessfully);
        }

        [TestMethod()]
        public void Game_IsValid()
        {
            Game game = new Game();

            string inputNumberInRange = "1";
            bool resultNumberInRange;
            resultNumberInRange = game.IsValidInput(inputNumberInRange);
            Assert.IsTrue(resultNumberInRange);

            string inputNumberAboveRange = "101";
            bool resultNumberAboveRange;
            resultNumberAboveRange = game.IsValidInput(inputNumberAboveRange);
            Assert.IsFalse(resultNumberAboveRange);

            string inputNumberBelowRange = "-1";
            bool resultNumberBelowRange;
            resultNumberBelowRange = game.IsValidInput(inputNumberBelowRange);
            Assert.IsFalse(resultNumberBelowRange);

            string inputNoNumber = "a";
            bool resultNoNumber;
            resultNoNumber = game.IsValidInput(inputNoNumber);
            Assert.IsFalse(resultNoNumber);
        }
    }
}