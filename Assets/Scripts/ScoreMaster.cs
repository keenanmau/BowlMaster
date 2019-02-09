using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {


    // returns list of cumulative scores, like a normal score card
    public static List<int> ScoreCumulative (List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int rollTotal = 0;
        foreach (int roll in ScoreFrames(rolls)) {
            rollTotal += roll;
            cumulativeScores.Add(rollTotal);
        }   
        return cumulativeScores;
    }

    //returns a list of individual frame scores
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frameList = new List<int>();//only records by frame. 
        for (int i = 0; i < rolls.Count - 1 && frameList.Count < 10; i++) { 

            if (rolls[i] == 10 && (i + 2 < rolls.Count)) {//if strike and 2 rolls ahead
                frameList.Add(rolls[i] + rolls[i + 1] + rolls[i + 2]);
            } else if (rolls[i] == 10 && (i + 2 >= rolls.Count)) {//strike, but not enough rolls
                return frameList;
            } else if (((rolls[i] + rolls[i + 1]) == 10 )) {//spare, and done
                if(i + 2 < rolls.Count) {
                    frameList.Add(rolls[i] + rolls[++i] + rolls[i + 1]);
                } else {
                    return frameList;
                } 
            } else {//regular roll, no strike or spare. 
                frameList.Add(rolls[i] + rolls[++i]);
            }

        }
        return frameList;
    }

}
