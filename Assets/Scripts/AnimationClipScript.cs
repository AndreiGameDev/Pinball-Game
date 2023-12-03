using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClipScript : MonoBehaviour
{
    [SerializeField]Animation animationComp;

    private void OnEnable() {
        animationComp.Play();
    }
}
