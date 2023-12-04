using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    // When the player enters the hole, trigger the enter hole event
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerCharacter")) {
            GolfBallManager golfBall = other.GetComponent<GolfBallManager>();
            if(golfBall != null) {
                golfBall.HoleEnterEvent();
            }
        }
    }
}
