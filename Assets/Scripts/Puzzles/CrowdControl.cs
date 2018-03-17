using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdControl : PuzzleBase {

    public Transform player;
    public Image[] group;
    public Image[] wordImages;
    public Transform wheel;
    public int target;
    public int threshold = 10;
    public float rotationSpeed = 1;
    public int delta = 0;

    void Update() {

        if (Vector3.Distance(player.position, wheel.position) <= 2) {
            int move = (int)Input.GetAxis("Horizontal");
            if (move != 0) {
                wheel.Rotate(0, 0, rotationSpeed);

                delta += 1 * move;

                wordImages[0].transform.Translate(-1*move, 0, 0);
                wordImages[1].transform.Translate(1*move, 0, 0);

            }
        }

        if (Input.GetAxis("Submit") > 0){
            if (CanSolve()) {
                Debug.Log("SOLVED");
                UpdateGameManager();
            }
            else
                Debug.Log("Not Solved");
        }
    }

    protected override bool CanSolve() {
        if (delta >= target - threshold && delta <= target + threshold)
            return true;
        return false;
    }
    
}
