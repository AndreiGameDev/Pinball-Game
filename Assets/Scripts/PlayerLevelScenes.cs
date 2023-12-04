using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelScenes : MonoBehaviour {
    // This script is used as an instance to keep track in which scnene the player is in.
    public static PlayerLevelScenes instance;
    [SerializeField] int[] playerLevelSceneIndexes;
    [SerializeField] int playerWinLevelSceneIndex;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public int[] GetPlayerLevelScenes() {
        return playerLevelSceneIndexes;
    }

    public int GetPlayerWinSceneIndex() {
        return playerWinLevelSceneIndex;
    }
}
