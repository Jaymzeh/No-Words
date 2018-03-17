using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkerboard : PuzzleBase {

    public string Word { get { return word; } private set { word = value; } }
    string word;

    public float moveMultiply = 1;

    public Image[] images;
    BoxCollider2D collider;
    public Transform colliderObject;


    void Start() {
        if (images == null) {
            Debug.LogError("Puzzle Image components not Assigned");
            return;
        }


        collider = images[0].GetComponentInChildren<BoxCollider2D>();
    }


    void Update() {

        images[0].transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);



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

        if (collider.bounds.Contains(colliderObject.position))
            return true;

        return false;
    }

}
