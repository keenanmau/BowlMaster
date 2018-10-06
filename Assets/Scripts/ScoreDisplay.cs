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

    public void FillRollCard (List<int> rolls) {
        rolls[-1] = 1;
    }
}
