using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }


    [Test]
    public void T01Bowl1() {
        int[] rolls = { 1 };
        string rollsString = "1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02Bowl10() {
        int[] rolls = { 10 };
        string rollsString = "X ";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03Bowl5spare() {
        int[] rolls = { 5, 5 };
        string rollsString = "5/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04BowlAllXSpare() {
        int[] rolls = { 10, 5, 5 };
        string rollsString = "X 5/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
    [Test]
    public void T05BowlMultiStrike() {
        int[] rolls = { 10, 10, 10 };
        string rollsString = "X X X ";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }


    [Test]
    public void T06BowlMultiSpares() {
        int[] rolls = { 5,5, 6, 4, 1, 9, 2, 8 };
        string rollsString = "5/6/1/2/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T07BowlMixedX() {
        int[] rolls = { 1, 1, 10, 2, 8, 4, 4, 0, 10 };
        string rollsString = "11X 2/44-/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T08BowlLast3() {
        int[] rolls = { 1,1, 2,2, 1,1, 3,3, 1,1, 4,4, 1,1, 5,2, 1,1, 10, 10, 10 };
        string rollsString = "112211331144115211XXX";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
    [Test]
    public void T09BowlLast3Spare() {
        int[] rolls = { 1, 1, 2, 2, 1, 1, 3, 3, 1, 1, 4, 4, 1, 1, 5, 2, 1, 1, 5, 5, 5 };
        string rollsString = "1122113311441152115/5";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T10BowlStrikeLastCheck() {
        int[] rolls = { 1,1, 2,2, 1,1, 3,3, 1,1, 4,4, 1,1, 5,2, 10, 3, 4 };
        string rollsString = "1122113311441152X 34";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T11BowlStrikeFrameChangeCheck() {
        int[] rolls = { 1, 1, 2, 2, 1, 1, 3, 3, 1, 1, 4, 4, 1, 1, 5, 2, 10, 10, 10, 10 };
        string rollsString = "1122113311441152X XXX";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
}
