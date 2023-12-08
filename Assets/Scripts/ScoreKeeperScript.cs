using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeperScript : MonoBehaviour
{
    public static ScoreKeeperScript Instance;
    public int ScoreThisSession = 0;
    public int BestScore = 0;
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        int highscore = PlayerPrefs.GetInt("HighScore");
        if(highscore != 0) {
            BestScore = highscore;
        }
    }
    public bool isHighScore() {
        if(ScoreThisSession > BestScore) {
            return true;
        } else {
            return false;
        }
    }
    void SetHighscore() {
        PlayerPrefs.SetInt("HighScore", ScoreThisSession);
    }

    private void Start() {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    void OnSceneChange(Scene currentScene, Scene nextScene) {
        foreach(int i in PlayerLevelScenes.instance.GetPlayerLevelScenes()) {
            if(nextScene.buildIndex == i) {
                ScoreThisSession = 0;
            } else if(nextScene.buildIndex == PlayerLevelScenes.instance.GetPlayerWinSceneIndex()) {
                if(ScoreThisSession > BestScore) {
                    SetHighscore();
                }
                }
        }
    }

}
