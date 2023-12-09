using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeperScript : MonoBehaviour {
    public static ScoreKeeperScript Instance;
    public int ScoreThisSession = 0;
    public int BestScore = 0;
    
    // Setup instance and set high score
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        if(PlayerPrefs.HasKey("HighScore")) {
            BestScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Checks if better score or not
    public bool isBestScore() {
        if(ScoreThisSession < BestScore) {
            SetBestScore();
            return true;
        } else {
            return false;
        }
    }
    
    // Sets best score
    void SetBestScore() {
        PlayerPrefs.SetInt("HighScore", ScoreThisSession);
        BestScore = ScoreThisSession;
    }

    // Subscribes to event which checks if the next scene is a player level it resets the score of the session.
    private void Start() {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    void OnSceneChange(Scene currentScene, Scene nextScene) {
        foreach(int i in PlayerLevelScenes.instance.GetPlayerLevelScenes()) {
            if(nextScene.buildIndex == i) {
                ScoreThisSession = 0;
            } 
        }
    }

}
