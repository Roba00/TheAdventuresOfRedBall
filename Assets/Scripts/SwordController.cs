using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordController : MonoBehaviour {

    public Transform tf;
    public Transform plrtf;
    public Vector3 plrpos;
    public Quaternion quat;
    public GameObject player;

    public Sprite SwordIdle;
    public Sprite SwordAttack;
    public SpriteRenderer SwordRenderer;
    public BoxCollider SwordBox;

    public bool isAttacking = false;
    public bool isLevel2 = false;

    void Start()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Level2")
        {
            isLevel2 = true;
        }
        else
        {
            isLevel2 = false;
        }
    }

    void FixedUpdate () {
        if (isLevel2)
        {
            plrpos.x = plrtf.position.x + 0.5f;
            plrpos.y = plrtf.position.y + 0.5f;
            plrpos.z = plrtf.position.z;
            tf.SetPositionAndRotation(plrpos, quat);
        }
        else
        {
            plrpos.x = plrtf.position.x + 1;
            plrpos.y = plrtf.position.y + 1;
            plrpos.z = plrtf.position.z;
            tf.SetPositionAndRotation(plrpos, quat);
        }
	}

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown("space") && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        if (isAttacking == true)
        {
            Debug.Log("Is Attacking!");
            //SwordBox.size.Set(3.7f, 3.8f, 0.2f);
            //SwordBox.center.Set(0, 0, 0);
            SwordBox.size = new Vector3(3.7f, 3.8f, 0.2f);
            SwordBox.center = new Vector3(0, 0, 0);
        }
        else
        {
            //SwordBox.size.Set(1.4f, 4.4f, 0.2f);
            //SwordBox.center.Set(-0.1f, 0, 0);
            SwordBox.size = new Vector3(1.4f, 4.4f, 0.2f);
            SwordBox.center = new Vector3(-0.1f, 0, 0);
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        SwordRenderer.sprite = SwordAttack;
        yield return new WaitForSeconds(0.5f);
        SwordRenderer.sprite = SwordIdle;
        isAttacking = false;
        yield return new WaitForSeconds(0.5f);
    }
}