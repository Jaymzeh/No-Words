using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkerboard : PuzzleBase {

    public string Word { get { return word; } private set { word = value; } }
    string word;

    public float moveMultiply = 1;

    public Image[] images;
    BoxCollider2D colliderBox;
    public Transform colliderObject;
    public Transform wheel;


    void Start() {
        if (images == null) {
            Debug.LogError("Puzzle Image components not Assigned");
            return;
        }


        colliderBox = images[0].GetComponentInChildren<BoxCollider2D>();
    }


    void Update() {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        images[0].transform.position += new Vector3(moveX, moveY, 0);

        if (moveX != 0 || moveY != 0)
            wheel.Rotate(Vector3.forward, 1);


        if (Input.GetAxis("Submit") > 0) {
            if (CanSolve()) {

                images[0].transform.position = colliderObject.transform.position;

                Debug.Log("SOLVED!");
                UpdateGameManager();
            }
            else
                Debug.Log("NOT solved");
        }
    }

    protected override bool CanSolve() {

        if (colliderBox.bounds.Contains(colliderObject.position))
            return true;

        return false;
    }

}
