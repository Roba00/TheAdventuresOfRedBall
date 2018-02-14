using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform tf;
    public float sideScrollSpeed = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        tf.Translate(sideScrollSpeed * Time.deltaTime,0,0);
	}
}
