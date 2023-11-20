using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;
    [SerializeField] CinemachineVirtualCamera cameraSettings;

    private void Update() {
        
    }
}
