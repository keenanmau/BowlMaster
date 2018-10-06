using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endgame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup() {
        pinFalls = new List<int>();
    }

    //[Test]
    //public void PassingTest() {
    //    Assert.AreEqual(1, 1);
    //}

    //[Test]
    //public void T01FirstStrikeReturnsEndTurn() {
    //    pinFalls.Add(10);
    //    Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    //}

    //[Test]
    //public void T02Bowl8ReturnsTidy() {
    //    pinFalls.Add(8);
    //    Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    //}

    //[Test]
    //public void T03BowlSpareReturnsEndTurn() {
    //    int[] rolls = { 2, 8 };
    //    Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    //    }



    //[Test]
    //public void T04ResetAtStrikeAtLastFrame() {
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
 
    //    Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T05ResetAtSpareAtLastFrame() {
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7,3 };
        
    //    Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T06YoutubeRollsEndInEndgame() {
    //    int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        
    //    Assert.AreEqual(endgame, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T07BowlEndsAtBowl20() {
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1  };

    //    Assert.AreEqual(endgame, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T08Bowl20StrikeFailReturnTidy() {
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 3 };

    //    Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T09Bowl19StrikeReturnReset() {
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };

    //    Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T10Bowl20StrikeFailReturnTidy() {
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 , 0};

    //    Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T11BowlStrikeOnSecondReturnSingleIncrement() {
    //    int[] rolls = { 0, 10, 2 };

    //    Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T12Dondi10thFrameTurkey() {
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
    //    List<int> rollsList = rolls.ToList();
    //    Assert.AreEqual(reset, ActionMaster.NextAction(rollsList));
    //    rollsList.Add(10);
    //    Assert.AreEqual(reset, ActionMaster.NextAction(rollsList));
    //    rollsList.Add(10);
    //    Assert.AreEqual(endgame, ActionMaster.NextAction(rollsList));
    //}

    //[Test]
    //public void T13Bowl0and1ReturnEndTurn() {
    //    int[] rolls = {0,1};
 
    //    Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    //}

    //   [Test]
    //   public void T13ScoreTest4FramesAddCheck() {
    //       //setup start
    //       int[] bowls = { 3, 4, 2, 8,};
    //       foreach (int num in bowls) {
    //           rolls.Add(num);
    //       }
    //       List<int> expected = new List<int>();
    //       expected.Add(7);
    //       expected.Add(10);
    //       //setup finish
    //       List<int> result = ScoreMaster.ScoreFrames(rolls);


    //       CollectionAssert.AreEqual(expected, result);


    //   }


}