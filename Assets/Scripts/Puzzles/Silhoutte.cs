﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Silhoutte : MonoBehaviour {

    public Transform shadowObject;

    public Vector3 targetRotation;
    public float threshold = 5;
    public int wordIndex = 0;

    void Update() {
        shadowObject.Rotate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        if (Input.GetAxis("Submit") > 0) {
            if (CheckRotation())
                Debug.Log("SOLVED");
            else
                Debug.Log("Not Solved");
        }
            
    }

    bool CheckRotation() {

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
        }
        return false;
    }
}