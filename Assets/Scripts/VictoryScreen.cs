using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI textElement;
    ScoreKeeperScript scoreKeeperScript;
    private void Awake() {
        scoreKeeperScript = ScoreKeeperScript.Instance;
    }
    public void Start() {
        if(scoreKeeperScript.BestScore > 0) {
            if(scoreKeeperScript.isHighScore()) {
                textElement.text = HigherScore();
            } else {
                textElement.text = LowerScore();
            }
        } else {
            textElement.text = "You have obtained your first best score.\n Strokes: " + scoreKeeperScript.ScoreThisSession;
        }
        
    }

    string HigherScore() {
        return "Congratulations! You have obtained new a best score!\n Strokes: " + scoreKeeperScript.ScoreThisSession;
    }

    string LowerScore() {
        return "Congratsulations! You have completed the level but you have not surpassed your best score." +
            "\n Strokes: " + scoreKeeperScript.ScoreThisSession + 
            "\n You need to get at least " + (scoreKeeperScript.ScoreThisSession - scoreKeeperScript.BestScore + 1) + " less strokes for a new best score.";
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void RetryLevel() {
        SceneManager.LoadScene(PlayerLevelScenes.instance.GetPlayerLevelScenes()[0]);
    }
}
