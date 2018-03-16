using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkerboard : MonoBehaviour {

    public string Word { get { return word; } private set { word = value; } }
    string word;

    public float moveMultiply = 1;

    public Image[] images;
    BoxCollider2D collider;
    Transform colliderObject;


    void Start() {
        if (images == null) {
            Debug.LogError("Puzzle Image components not Assigned");
            return;
        }


        collider = images[0].GetComponentInChildren<BoxCollider2D>();
        colliderObject = images[1].transform.GetChild(0);
    }


    void Update() {

        images[0].transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);



        if (Input.GetAxis("Submit") > 0) {
            if (CanSolve()) {

                images[0].transform.position = colliderObject.transform.position;

                Debug.Log("SOLVED!");
            }
            else
                Debug.Log("NOT solved");
        }
    }

    bool CanSolve() {

        if (collider.bounds.Contains(colliderObject.position))
            return true;

        return false;
    }

}
