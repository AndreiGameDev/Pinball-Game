using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallManager : MonoBehaviour
{
    PlayerInputValues playerInput;
    private static GolfBallManager instance;
    public static GolfBallManager Instance {
        get {
            return instance;
        }
    }
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    [SerializeField] Transform rootTransform;
    [SerializeField] GameObject trajectoryLine;
    Rigidbody rb;
    GameObject UI;
    private void Start() {
        UI = GameObject.FindGameObjectWithTag("PlayerUI");
        playerInput = GetComponent<PlayerInputValues>();
        rb = GetComponentInChildren<Rigidbody>();
    }


    IEnumerator isBallMoving() {
        yield return new WaitForFixedUpdate();
        if(rb.velocity.magnitude == 0) {
            UI.SetActive(true);
            trajectoryLine.SetActive(true);
        } else {
            StartCoroutine(isBallMoving());
        }
    }

    public void ShootBall() {
        UI.SetActive(false);
        trajectoryLine.SetActive(true);
        rb.AddForce(rootTransform.forward * playerInput.powerAmount, ForceMode.Impulse);
        StartCoroutine(isBallMoving());
    }
}
