using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public GameObject Sword;
    public Transform tf;
    public bool isGrounded = false;
    public Text health_text;
    public Text score_text;
    public int health = 100;
    public int score = 0;
    public bool Level2Loaded = false;
	
    // Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        health_text.text = "Health: " + health.ToString() + "%";
        score_text.text  = "Score: "   + score.ToString();

        if (health == 0)
        {
            SceneManager.LoadScene(2);
        }
	}

    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            rb.AddForce(Vector3.left * 10);
            //tf.Translate(-5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            rb.AddForce(Vector3.right * 10);
            //tf.Translate(5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown("up") && isGrounded)
        {
             rb.AddForce(Vector3.up * 500);
            //tf.Translate(0, 5f, 0);
        }
        if (Input.GetKey("down"))
        {
            rb.AddForce(Vector3.up * -25);
        }
        if (tf.position.y < -4.93)
        {
            Debug.Log("You Dead.");
            Destroy(gameObject);
            Destroy(Sword);
            SceneManager.LoadScene(2);
        }
    }
    void OnCollisionEnter(Collision CollisionEnter)
    {
        if (CollisionEnter.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
        if (CollisionEnter.gameObject.tag == "Enemy")
        {
            health -= 5;
        }
        if (CollisionEnter.gameObject.name == "pipe1")
        {
            SceneManager.LoadScene(4);
            Level2Loaded = true;
        }
        if (CollisionEnter.gameObject.tag == "1 coin"  || 
            CollisionEnter.gameObject.tag == "5 coin"  || 
            CollisionEnter.gameObject.tag == "10 coin" || 
            CollisionEnter.gameObject.tag == "25 coin" || 
            CollisionEnter.gameObject.tag == "50 coin" || 
            CollisionEnter.gameObject.tag == "100 coin" )
        {
            switch (CollisionEnter.gameObject.tag)
            {
                case ("1 coin"):
                    score += 1;
                    Destroy(CollisionEnter.gameObject);
                    break;
                case ("5 coin"):
                    score += 5;
                    Destroy(CollisionEnter.gameObject);
                    break;
                case ("10 coin"):
                    score += 10;
                    Destroy(CollisionEnter.gameObject);
                    break;
                case ("25 coin"):
                    score += 25;
                    Destroy(CollisionEnter.gameObject);
                    break;
                case ("50 coin"):
                    score += 50;
                    Destroy(CollisionEnter.gameObject);
                    break;
                case ("100 coin"):
                    score += 100;
                    Destroy(CollisionEnter.gameObject);
                    break;
            }
        }
    }


    void OnCollisionExit(Collision CollisionExit)
    {
        if (CollisionExit.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
}