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
    [SerializeField] Transform rootTransform;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    Rigidbody rb;
    private void Start() {
        playerInput = GetComponent<PlayerInputValues>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    public void ShootBall() {
        rb.AddForce(rootTransform.forward * playerInput.powerAmount, ForceMode.Impulse);
    }
}
