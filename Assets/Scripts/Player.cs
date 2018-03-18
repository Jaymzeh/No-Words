using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float walkSpeed = 0.1f;

    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveX = (float)Input.GetAxis("Horizontal");
        float moveZ = (float)Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, 0, moveZ)*walkSpeed);
        anim.SetFloat("Speed", moveX + moveZ);
	}
}
