using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSkip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("0"))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey("1"))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey("2"))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey("3"))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKey("4"))
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKey("5"))
        {
            SceneManager.LoadScene(5);
        }
        if (Input.GetKey("6"))
        {
            SceneManager.LoadScene(6);
        }
        if (Input.GetKey("7"))
        {
            SceneManager.LoadScene(7);
        }
    }
}
