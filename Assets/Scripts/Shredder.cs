using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {


    private void OnTriggerExit(Collider thingLeft) {
        GameObject hitPin = thingLeft.gameObject;
        if (hitPin.GetComponent<Pin>()) {
            Destroy(hitPin);
        }
    }
}
