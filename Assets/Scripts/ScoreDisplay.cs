using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollsText;
    public Text[] framesText;
    // Use this for initialization
    void Start () {
        rollsText[0].text = "x";
        framesText[0].text = "0";
	}
	

	// Update is called once per frame
	void Update () {
		
	}

    public void FillRolls (List<int> rolls) {
        string rollsString = FormatRolls(rolls);
        for (int i = 0; i < rollsString.Length; i++) {
            rollsText[i].text = rollsString[i].ToString();
        } 

    }

    public void FillFrames (List<int> frames) {
        for(int i = 0; i < frames.Count; i++) {
            framesText[i].text = frames[i].ToString();
        }
    }

    //todo check string length for how many frames
    public static string FormatRolls(List<int> rolls) {
        
        string output = "";
        for (int i = 0; i < rolls.Count; i++) {
            if (rolls[i] == 0) {
                output += "-";
            } else if (((output.Length % 2 == 1)|| output.Length == 21) && (rolls[i] + rolls[i - 1] == 10)) {//Spare
                output += "/";
            } else if (rolls[i] >= 10) {//strike?
                if (output.Length >= 18) {
                    output += "X";
                } else {
                    output += "X ";//print strike, and fill second frame. 
                }
            } else {
                output += rolls[i].ToString();//regular roll
            }
        }
        return output;
    }
}
