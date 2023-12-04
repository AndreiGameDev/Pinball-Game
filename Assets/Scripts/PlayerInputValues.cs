using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputValues : MonoBehaviour
{
    public bool isLookingRight;
    public bool isLookingLeft;
    public float powerAmount;

    // Disables variables to make sure the camera doesn't spin when the UI Hides
    private void OnDisable() {
        isLookingLeft = false;
        isLookingRight = false;
    }
}
