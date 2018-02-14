using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Button retry;
	// Use this for initialization
	void Start () {
        retry.onClick.AddListener(OnClick);
	}
	
	void OnClick()
    {
        SceneManager.LoadScene(1);
    }

}
