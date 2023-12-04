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
    public int strokes = 1;
    public bool isInHole = false;
    ResetManagerScript resetManager;
    AudioManager audioManager;
    TrailRenderer trailRenderer;
    private void Awake() {
        // Creat an instance for other scripts to access 
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        uiScript = GetComponent<GolfBallUI>();
        playerInput = GetComponent<PlayerInputValues>();
        rb = GetComponentInChildren<Rigidbody>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }
    private void Start() {
        resetManager = ResetManagerScript.Instance;
        uiScript.UpdateStrokeCounter(strokes);
        audioManager = AudioManager.Instance;
    }

    // Coroutine to check if the player is moving
    // If the player stopped moving that means he should add another stroke and re-enable all the disabled elements
    // If he is still moving run the coroutine again
    IEnumerator isBallMoving() {
        yield return new WaitForFixedUpdate();
        if(rb.velocity.magnitude == 0) {
            StartCoroutine(CheckIfBallOnBoundaryGround());
            strokes++;
            uiScript.UpdateStrokeCounter(strokes);
            uiScript.GameUISetActive(true);
            trajectoryLine.SetActive(true);
        } else {
            StartCoroutine(isBallMoving());
        }
    }

    // Save the position in case the player falls
    // Disable elements to make it more immersive
    // Add force to the ball then run the coroutine to check if the ball is still moving
    public void ShootBall() {
        resetManager.initialGolfballPosition = transform.position;
        resetManager.initialGolfballRotation = transform.rotation;
        uiScript.GameUISetActive(false);
        trajectoryLine.SetActive(false);
        rb.AddForce(rootTransform.forward * playerInput.powerAmount, ForceMode.Impulse);
        StartCoroutine(isBallMoving());
    }

    // When the player stops moving htis coroutine will be run to check if the player is on a playable area
    IEnumerator CheckIfBallOnBoundaryGround() {
        if(Physics.CheckSphere(transform.position, transform.localScale.x, LayerMask.GetMask("PlayArea")) == false) {
            resetManager.ResetPlayerToOldPosition(gameObject);
        }
        yield return null;
    }


    // Function to call for when the golf ball enters the hole
    public void HoleEnterEvent() {
        StopAllCoroutines();
        StartCoroutine(HoleEnterEventCoroutine());
    }

    // Coroutine which sets variables when ball enters hole and moves the ball to the next hole
    IEnumerator HoleEnterEventCoroutine() {
        isInHole = true;
        audioManager.PlaySFX(audioManager.M_Win);
        uiScript.EnableHoleEnterText(strokes);
        resetManager.HoleCurrentlyOn++;
        yield return new WaitForSeconds(3f);
        trailRenderer.enabled = false;
        resetManager.ResetPlayerToSpawn(gameObject);
        trailRenderer.enabled = true;
        ScoreKeeperScript.Instance.ScoreThisSession += strokes;
        NewLevelReset();
    }

    // Function which resetse everything to default when loading in a new hole
    public void NewLevelReset() {
        isInHole = false;
        strokes = 1;
        resetManager.SetBoundaries();
        uiScript.DisableHoleEnterText();
        uiScript.UpdateStrokeCounter(strokes);
        uiScript.GameUISetActive(true);
        trajectoryLine.SetActive(true);
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(!isInHole && collision.collider.CompareTag("NoSFX") == false ) {
            audioManager.PlaySFX(audioManager.SFX_GolfballBump);
        }
    }
    
}
