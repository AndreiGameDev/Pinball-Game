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
    private void OnTriggerEnter(Collider other) {
        resetManager.ResetPlayer(Player);
    }
}
