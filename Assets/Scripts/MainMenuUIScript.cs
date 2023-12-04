using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    private void Start() {
        if(ScoreKeeperScript.Instance.BestScore >= 0) {
            highScoreText.text += ScoreKeeperScript.Instance.BestScore;
        } else {
            highScoreText.text = "No best score has been setled yet.";
        }
        
    }
    public void PlayEvent() {
        SceneManager.LoadScene(PlayerLevelScenes.instance.GetPlayerLevelScenes()[0]);
    }
}
