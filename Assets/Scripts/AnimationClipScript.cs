using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClipScript : MonoBehaviour
{
    [SerializeField]Animation animationComp;

    // Plays animation when enabled
    private void OnEnable() {
        animationComp.Play();
    }
}
