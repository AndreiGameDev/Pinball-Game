using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    AudioManager audioManager;

    private void Start() {
        audioManager = AudioManager.Instance;
    }
    public void ButtonClick() {
        audioManager.PlaySFX(audioManager.SFX_ClickButton);
    }
}
