using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputReceiver : MonoBehaviour
{
    public PlayerInputValues playerInputScript;
    
    public void RotateRight(bool isHolding) {
        playerInputScript.isLookingLeft = isHolding;
    }

    public void RotateLeft(bool isHolding) {
        playerInputScript.isLookingRight = isHolding;
    }

    public void PowerValue(float powerValue) {
        playerInputScript.powerAmount = powerValue;
    }
}
