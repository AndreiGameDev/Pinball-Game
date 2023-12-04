using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputReceiver : MonoBehaviour
{
    public PlayerInputValues playerInputScript;
    
    //Sets the variable to turn Camera left
    public void RotateLeft(bool isHolding) {
        playerInputScript.isLookingLeft = isHolding;
    }

    // Set the variable to turn camera right
    public void RotateRight(bool isHolding) {
        playerInputScript.isLookingRight = isHolding;
    }

    // Set the power variable to whatever the slider the value is
    public void SetPowerValue(float powerValue) {
        playerInputScript.powerAmount = powerValue;
    }

    // Shoots the ball
    public void ShootBallEvent() {
        GolfBallManager.Instance.ShootBall();
        playerInputScript.powerAmount = 0;
    }
}
