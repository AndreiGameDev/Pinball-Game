using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] GameObject playerRoot;
    PlayerInputValues playerInput;
    [SerializeField] float sensitivity = 100f;
    private void Start() {
        playerInput = GetComponent<PlayerInputValues>();
    }
    private void Update() {
        // Rotates camera to right
        if(playerInput.isLookingRight) {
            playerRoot.transform.Rotate(Vector3.up, sensitivity * Time.deltaTime);
        }

        // Rotates camera to left
        if(playerInput.isLookingLeft) {
            playerRoot.transform.Rotate(Vector3.up, -sensitivity * Time.deltaTime);
        }
    }
}
