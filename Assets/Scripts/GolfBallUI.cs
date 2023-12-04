using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GolfBallUI : MonoBehaviour
{
    GameObject MasterUI;
    GameObject GameUI;
    GameObject InfoUI;
    private void Awake() {
        MasterUI = GameObject.FindGameObjectWithTag("PlayerUI");
        GameUI = MasterUI.transform.Find("GameplayElements").gameObject;
        InfoUI = MasterUI.transform.Find("InformationElements").gameObject;
    }

    // Toggles Gameplay UI Elements active or false
    public void GameUISetActive(bool boolean) {
        GameUI.SetActive(boolean);
    }

    // Toggles Informative UI Elements active or false
    public void InfoUISetActive(bool boolean) {
        InfoUI.SetActive(boolean);
    }

    // Updates the stroke counter text
    public void UpdateStrokeCounter(int StrokesAmount) {
        Transform StrokeCounter = InfoUI.transform.Find("StrokeCounter");
        StrokeCounter.GetComponent<TextMeshProUGUI>().text = "Strokes\n" + StrokesAmount.ToString();
    }
    
    // Update the Text based on the amount of strokes the player has and then sets it to active when called.
    public void EnableHoleEnterText(int StrokesAmount) {
        Transform HoleText = InfoUI.transform.Find("HoleText");
        if(StrokesAmount > 1) {
            HoleText.GetComponent<TextMeshProUGUI>().text = "Congratulations! \n You made it in " + StrokesAmount + " strokes!";
        } else {
            HoleText.GetComponent<TextMeshProUGUI>().text = "Hole in one!";
        }

        HoleText.gameObject.SetActive(true);
    }

    // Disables the text congratulating the player.
    public void DisableHoleEnterText() {
        Transform HoleText = InfoUI.transform.Find("HoleText");
        HoleText.gameObject.SetActive(false);
    }
}
