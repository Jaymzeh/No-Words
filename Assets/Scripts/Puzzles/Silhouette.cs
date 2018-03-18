using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Silhouette : PuzzleBase {

    public Transform shadowObject;

    public Vector3 targetRotation;
    
    public float threshold = 5;
    public int wordIndex = 0;

    void Start() {
        
    }

    void Update() {
        //shadowObject.Rotate(new Vector3(Input.GetAxis("Horizontal"),
        //    Input.GetAxis("Horizontal") * Input.GetAxis("Vertical"),
        //    Input.GetAxis("Vertical")),Space.World);

        shadowObject.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
        shadowObject.Rotate(Camera.main.transform.right, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Submit") > 0) {
            if (CanSolve()) {
                Debug.Log("SOLVED");
                UpdateGameManager();
            }
            else
                Debug.Log("Not Solved");
        }
            
    }

    protected override bool CanSolve() {

        if (targetRotation.x < 0)
            targetRotation.x += 360;

        if (targetRotation.y < 0)
            targetRotation.y += 360;

        if (shadowObject.localEulerAngles.x >= targetRotation.x - threshold &&
            shadowObject.localEulerAngles.x <= targetRotation.x + threshold) {

            if (shadowObject.localEulerAngles.y >= targetRotation.y - threshold &&
            shadowObject.localEulerAngles.y <= targetRotation.y + threshold) {
                return true;
            }
            else
                if (shadowObject.localEulerAngles.y >= targetRotation.y - threshold &&
            shadowObject.localEulerAngles.y <= targetRotation.y + threshold) {
                return true;
            }
        }
        return false;
    }
}