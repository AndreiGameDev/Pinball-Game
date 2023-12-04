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
    // Grabs every spawn position of the holes
    private void Start() {
        foreach(Transform hole in holes) {
            spawnPositions.Add(hole.Find("Spawnpos"));
        }
        SetBoundaries();
    }

    // Enables the boundaries of the current hole, and disables the ones that are not being used
    public void SetBoundaries() {
        for(int i = 0; i < spawnPositions.Count; i++) {
            if(i == HoleCurrentlyOn) {
                holes[i].transform.Find("ResetBoundary").gameObject.SetActive(true);
            } else {
                holes[i].transform.Find("ResetBoundary").gameObject.SetActive(false);
            }
        }
    }

    //Resets the player to the hole it's currently at
    public void ResetPlayerToSpawn(GameObject gameObjectToReset) {
        gameObjectToReset.transform.position = spawnPositions[HoleCurrentlyOn].transform.position;
        gameObjectToReset.transform.rotation = spawnPositions[HoleCurrentlyOn].transform.rotation;
    }

    //Resets the player to the old position stored
    public void ResetPlayerToOldPosition(GameObject gameObjectToReset) {
        Rigidbody gameObjectRB = gameObjectToReset.GetComponent<Rigidbody>();
        gameObjectRB.velocity = Vector3.zero;
        gameObjectToReset.transform.position = initialGolfballPosition;
        gameObjectToReset.transform.rotation = initialGolfballRotation;
        
        
    }
}
