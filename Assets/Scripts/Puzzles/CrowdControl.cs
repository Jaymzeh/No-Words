using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdControl : MonoBehaviour {

    public Transform player;
    public Transform[] group;
    public Transform[] wheel;
    public int[] range;
    public int threshold = 10;
    public float rotationSpeed = 1;

    void Update() {
        for (int i = 0; i < 2; i++) {
            if (Vector3.Distance(player.position, wheel[i].position) <= 2) {
                if (Input.GetAxis("Submit") >= 0)
                    wheel[i].Rotate(0, 0, rotationSpeed);
            }
        }
    }

    bool InRange(int index) {
        if (wheel[index].eulerAngles.z >= range[index] - threshold && wheel[index].eulerAngles.z <= range[index] + threshold)
            return true;
        return false;
    }
}
