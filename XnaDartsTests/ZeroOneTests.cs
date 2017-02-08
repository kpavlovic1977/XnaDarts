﻿using System.Linq;
using NUnit.Framework;
using XnaDarts.Gameplay.Modes.ZeroOne;

namespace XnaDartsTests
{
    [TestFixture]
    public class ZeroOneTests
    {
        [Test]
        public void ZeroOneBustIfBelowZero()
        {
            var zeroOne = new ZeroOne(1, 100);
            zeroOne.RegisterDart(25, 2);
            zeroOne.RegisterDart(20, 3);
            Assert.IsTrue(zeroOne.IsPlayerBustAtCurrentRound(zeroOne.CurrentPlayer));
        }

        [Test]
        public void ZeroOneNotBustIfCleared()
        {
            var zeroOne = new ZeroOne(1, 20);
            zeroOne.RegisterDart(20, 1);
            Assert.IsFalse(zeroOne.IsPlayerBustAtCurrentRound(zeroOne.CurrentPlayer));
        }

        [Test]
        public void ZeroOnePlayer1InLeadIfCleared()
        {
            var zeroOne = new ZeroOne(2, 20);
            zeroOne.RegisterDart(10, 2);
            Assert.IsFalse(zeroOne.IsPlayerBustAtCurrentRound(zeroOne.CurrentPlayer));
            Assert.AreEqual(zeroOne.GetLeaders().Count, 1);
            Assert.AreEqual(zeroOne.GetLeaders().First(), zeroOne.Players.First());
        }
    }
}
