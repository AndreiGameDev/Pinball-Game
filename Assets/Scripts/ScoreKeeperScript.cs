using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperScript : MonoBehaviour
{
    public static ScoreKeeperScript Instance;
    public int ScoreThisSession = 0;
    public int BestScore = 0;
    private void Awake() {
        if(Instance == null) {
            Instance = this;
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
            SetHighscore();
            return true;
        } else {
            return false;
        }
    }
    void SetHighscore() {
        PlayerPrefs.SetInt("HighScore", ScoreThisSession);
    }

    
}
