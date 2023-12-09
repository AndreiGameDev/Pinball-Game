using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    AudioManager audioManager;
    private void Start() {
        audioManager = AudioManager.Instance;
        if(PlayerPrefs.HasKey("HighScore")) {
            highScoreText.text += ScoreKeeperScript.Instance.BestScore;
        } else {
            highScoreText.text = "No best score has been setled yet.";
        }
        
    }
    public void PlayEvent() {
        SceneManager.LoadScene(PlayerLevelScenes.instance.GetPlayerLevelScenes()[0], LoadSceneMode.Single);
    }

    public void PlayButtonSFX() {
        audioManager.PlaySFX(audioManager.SFX_ClickButton);
    }
    
}
