using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolfBallManager : MonoBehaviour {
    PlayerInputValues playerInput;
    private static GolfBallManager instance;
    public static GolfBallManager Instance {
        get {
            return instance;
        }
    }
    [SerializeField] Transform boundaryTransform;
    [SerializeField] Transform rootTransform;
    [SerializeField] GameObject trajectoryLine;
    Rigidbody rb;
    GolfBallUI uiScript;
    public int Strokes = 1;
    public bool isInHole = false;
    ResetManagerScript resetManager;
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        uiScript = GetComponent<GolfBallUI>();
        playerInput = GetComponent<PlayerInputValues>();
        rb = GetComponentInChildren<Rigidbody>();
    }
    private void Start() {
        resetManager = ResetManagerScript.Instance;
        uiScript.UpdateStrokeCounter(Strokes);
    }


    IEnumerator isBallMoving() {
        yield return new WaitForFixedUpdate();
        if(rb.velocity.magnitude == 0) {
            StartCoroutine(CheckIfBallOnBoundaryGround());
            Strokes++;
            uiScript.UpdateStrokeCounter(Strokes);
            uiScript.GameUISetActive(true);
            trajectoryLine.SetActive(true);
        } else {
            StartCoroutine(isBallMoving());
        }
    }

    public void ShootBall() {
        uiScript.GameUISetActive(false);
        trajectoryLine.SetActive(false);
        rb.AddForce(rootTransform.forward * playerInput.powerAmount, ForceMode.Impulse);
        StartCoroutine(isBallMoving());
    }
    IEnumerator CheckIfBallOnBoundaryGround() {
        if(Physics.CheckSphere(transform.position, transform.localScale.x, LayerMask.GetMask("PlayArea")) == false) {
            resetManager.ResetPlayer(gameObject);
        }
        yield return null;
    }

    public void HoleEnterEvent() {
        StopAllCoroutines();
        StartCoroutine(HoleEnterEventCoroutine());
    }

    IEnumerator HoleEnterEventCoroutine() {
        isInHole = true;
        uiScript.EnableHoleEnterText(Strokes);
        resetManager.HoleCurrentlyOn++;
        yield return new WaitForSeconds(3f);
        resetManager.ResetPlayer(gameObject);
        NewLevelReset();
    }

    public void NewLevelReset() {
        isInHole = false;
        Strokes = 1;
        resetManager.DisableBoundaries();
        uiScript.DisableHoleEnterText();
        uiScript.UpdateStrokeCounter(Strokes);
        uiScript.GameUISetActive(true);
        trajectoryLine.SetActive(true);
        
    }
}
