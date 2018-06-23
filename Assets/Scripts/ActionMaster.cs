using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int[] bowls = new int[21];//scoreboard array
    private int bowl = 1;

    public Action Bowl(int pins) {
        //regular setup
        if (pins > 10 || pins < 0) {
            throw new UnityException("Pin count error");
        }
        bowls[bowl - 1] = pins;
        
        //return actions
        if(bowl == 21) {
            return Action.EndGame;
        }
        if(bowl == 20 && (bowls[19 - 1] + bowls[20 - 1] == 10)) {
            if(pins == 0) {
                bowl++;
                return Action.Tidy;
            }
            bowl++;
            return Action.Reset;
        }
        if (bowl == 20 && Bowl20Tidy()) {
            if (Bowl21Awarded()) {
                bowl++;
                return Action.Tidy;
            }else {
                bowl++;
                return Action.EndGame;
            }

        }

        if (bowl >= 19 && Bowl21Awarded()) {//extra roll
            bowl += 1;
            return Action.Reset;
        }else if(bowl == 20 && !Bowl21Awarded()) {
            return Action.EndGame;
        }
  
        if(bowl %2 != 0) { //began here
            if (pins == 10) {//strike, regular 
                bowl += 2;
                return Action.EndTurn;
            } else {
                bowl += 1;
                return Action.Tidy;
            }
        }else if (bowl %2 == 0) {
            bowl += 1;
            return Action.EndTurn;
        }
        throw new UnityException("Not Sure what action to expect");
    }

    private bool Bowl21Awarded() {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10); // check score
    }

    private bool Bowl20Tidy() {
        return (bowls[19 - 1] + bowls[20 - 1]) % 10 != 0;
    }

}
