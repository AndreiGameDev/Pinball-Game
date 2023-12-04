using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBoundary : MonoBehaviour
{
    GameObject Player;
    ResetManagerScript resetManager;
    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("PlayerCharacter");
    }
    private void Start() {
        resetManager = ResetManagerScript.Instance;
    }

    // When the ball enters reset the ball to the old position
    private void OnTriggerEnter(Collider other) {
        resetManager.ResetPlayerToOldPosition(Player);
    }
}
