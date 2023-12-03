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

    public void GameUISetActive(bool boolean) {
        GameUI.SetActive(boolean);
    }
    public void InfoUISetActive(bool boolean) {
        InfoUI.SetActive(boolean);
    }

    public void UpdateStrokeCounter(int StrokesAmount) {
        Transform StrokeCounter = InfoUI.transform.Find("StrokeCounter");
        StrokeCounter.GetComponent<TextMeshProUGUI>().text = "Strokes\n" + StrokesAmount.ToString();
    }
    
    public void EnableHoleEnterText(int StrokesAmount) {
        Transform HoleText = InfoUI.transform.Find("HoleText");
        if(StrokesAmount > 1) {
            HoleText.GetComponent<TextMeshProUGUI>().text = "Congratulations! \n You made it in " + StrokesAmount + "Amount!";
        } else {
            HoleText.GetComponent<TextMeshProUGUI>().text = "Hole in one!";
        }

        HoleText.gameObject.SetActive(true);
    }
    public void DisableHoleEnterText() {
        Transform HoleText = InfoUI.transform.Find("HoleText");
        HoleText.gameObject.SetActive(false);
    }
}
