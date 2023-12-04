using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ResetManagerScript : MonoBehaviour
{
    private static ResetManagerScript _instance;
    public static ResetManagerScript Instance {
        get {
            return _instance;
        }
    }
    private void Awake() {
        _instance = this;
    }
    public List<Transform> holes = new List<Transform>();
    public List<Transform> spawnPositions = new List<Transform>();
    public int HoleCurrentlyOn = 0;
    public Vector3 initialGolfballPosition;
    public Quaternion initialGolfballRotation;
    private void Start() {
        foreach(Transform hole in holes) {
            spawnPositions.Add(hole.Find("Spawnpos"));
        }
        DisableBoundaries();
    }

    public void DisableBoundaries() {
        for(int i = 0; i < spawnPositions.Count; i++) {
            if(i == HoleCurrentlyOn) {
                holes[i].transform.Find("ResetBoundary").gameObject.SetActive(true);
            } else {
                holes[i].transform.Find("ResetBoundary").gameObject.SetActive(false);
            }
        }
    }
    public void ResetPlayerToSpawn(GameObject gameObjectToReset) {
        gameObjectToReset.transform.position = spawnPositions[HoleCurrentlyOn].transform.position;
        gameObjectToReset.transform.rotation = spawnPositions[HoleCurrentlyOn].transform.rotation;
    }
    public void ResetPlayerToOldPosition(GameObject gameObjectToReset) {
        Rigidbody gameObjectRB = gameObjectToReset.GetComponent<Rigidbody>();
        gameObjectRB.velocity = Vector3.zero;
        gameObjectToReset.transform.position = initialGolfballPosition;
        gameObjectToReset.transform.rotation = initialGolfballRotation;
        
        
    }
}
