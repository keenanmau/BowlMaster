using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>();

    private PinSetter pinSetter;
    private BowlingBall ball;
    private ScoreDisplay scoreDisplay;
    //here

	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<BowlingBall>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
    public void Bowl(int pinFall) {
        try {
            rolls.Add(pinFall);
            ball.Reset();
            List<int> tempRolls = new List<int>(rolls);
            ActionMaster.Action nextAction = ActionMaster.NextAction(tempRolls);
            pinSetter.PerformAction(nextAction);

            print("Rolls: " + PrintRolls(rolls));
        } catch {
            Debug.LogWarning("Something went wrong in Game Manager");
        }
        try {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
            //print("Cumulative:" + PrintRolls(ScoreMaster.ScoreCumulative(rolls)));
        } catch {
            Debug.LogWarning("Something went wrong in Score Display");
        }

    }

    public string PrintRolls(List<int> r) {
        string s = "";
        foreach ( int a in r){
            s += a + ", ";
        }
        return s;
    }
}
