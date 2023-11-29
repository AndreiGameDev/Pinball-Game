using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {
    [SerializeField] GameObject playerRoot;
    PlayerInputValues playerInput;
    [SerializeField] float sensitivity = 100f;
    private void Start() {
        playerInput = GetComponent<PlayerInputValues>();
    }
    private void Update() {
        if(playerInput.isLookingRight) {
            playerRoot.transform.Rotate(Vector3.up, -sensitivity * Time.deltaTime);
        }

        if(playerInput.isLookingLeft) {
            playerRoot.transform.Rotate(Vector3.up, sensitivity * Time.deltaTime);
        }
    }
}
