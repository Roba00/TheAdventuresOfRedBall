using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    public Button play;

	// Use this for initialization
	void Start () {
        play.onClick.AddListener(OnClick);
    }
	
    void OnClick ()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Loaded Level 1");
    }
}
