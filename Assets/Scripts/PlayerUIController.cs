using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    private static PlayerUIController _instance;
    public static PlayerUIController Instance {
        get {
            return _instance;
        }
    }

    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    [SerializeField] Slider powerSlider;
    public float powerValue;
    [SerializeField] GameObject golfBall;
    Rigidbody rbGolfBall;
    
    public void SetPowerValue() {
        powerSlider.value = powerValue;
    }

    public void ShootBall() {
        if(rbGolfBall == null) {
            rbGolfBall = golfBall.GetComponent<Rigidbody>();
        }
        Vector3 ShootDir = golfBall.transform.forward * powerValue;
        rbGolfBall.AddForceAtPosition(ShootDir, golfBall.transform.position, ForceMode.Impulse);
    }
}
