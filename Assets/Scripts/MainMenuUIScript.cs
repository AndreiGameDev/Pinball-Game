using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI highScoreText;

    // Updates text to highscore
    private void Start() {
        if(PlayerPrefs.HasKey("HighScore")) {
            highScoreText.text += ScoreKeeperScript.Instance.BestScore;
        } else {
            highScoreText.text = "No best score has been setled yet.";
        }
    }

    // Play button function
    public void PlayEvent() {
        SceneManager.LoadScene(PlayerLevelScenes.instance.GetPlayerLevelScenes()[0], LoadSceneMode.Single);
    }
}
