using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolfBallManager : MonoBehaviour
{
    PlayerInputValues playerInput;
    private static GolfBallManager instance;
    public static GolfBallManager Instance {
        get {
            return instance;
        }
    }
    [SerializeField] Transform boundaryTransform;
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
            StartCoroutine(CheckIfBallOnBoundaryGround());
            UI.SetActive(true);
            trajectoryLine.SetActive(true);
        } else {
            StartCoroutine(CheckIfBallOnBoundaryAir());
            StartCoroutine(isBallMoving());
        }
    }

    public void ShootBall() {
        UI.SetActive(false);
        trajectoryLine.SetActive(true);
        rb.AddForce(rootTransform.forward * playerInput.powerAmount, ForceMode.Impulse);
        StartCoroutine(isBallMoving());
    }

    IEnumerator CheckIfBallOnBoundaryAir() {
        if(transform.position.y <= boundaryTransform.position.y) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        yield return null;
    }
    IEnumerator CheckIfBallOnBoundaryGround() {
        if(Physics.CheckSphere(transform.position, transform.localScale.x, LayerMask.GetMask("PlayArea")) == false){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        yield return null;
    }
}
