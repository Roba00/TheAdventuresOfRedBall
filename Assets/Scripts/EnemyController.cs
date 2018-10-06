using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Sprite SwordAttack;
    public GameObject Sword;
    public Ray ray;

    public Transform tf;
    public Vector3 tf_vector;
    public float Ray_Distance = 5;
    public Rigidbody rb;
    public RaycastHit hitInfo;
    public bool hasAttacked = false;
    public new string name;
    public int health = 1;
    public TextMesh healthText;
    public Vector3 healthTextPosition;
    public Quaternion quat;
    public GameObject player;

    public float RayY = 0.1f;

    void Update()
    {
        healthTextPosition.x = gameObject.transform.position.x;
        healthTextPosition.y = gameObject.transform.position.y + 2;
        healthTextPosition.z = gameObject.transform.position.z;

        healthText.transform.SetPositionAndRotation(healthTextPosition, quat);

        if (health == 0)
        {
            player.GetComponent<PlayerController>().score += 5;
            Destroy(gameObject);
            Destroy(healthText);
        }

        healthText.text = "Health = " + health.ToString();
    }

    void FixedUpdate()
    {
        if (name == "Yellow Ball Enemy")
        {
            tf_vector.x = tf.position.x;
            tf_vector.y = tf.position.y - RayY;
            tf_vector.z = tf.position.z;

            if (Physics.Raycast(tf_vector, Vector3.left * Ray_Distance, out hitInfo, Ray_Distance))
            {
                if (hitInfo.collider.name == "Player" && !hasAttacked)
                {
                    Debug.Log("Yellow Ball Enemy sees player!");
                    rb.AddForce(Vector3.up * 2000);
                    rb.AddForce(Vector3.left * 1000);
                    hasAttacked = true;
                }
            }
            Debug.DrawRay(tf_vector, Vector3.left * Ray_Distance, Color.red);
        }
        if (name == "Bird Enemy")
        {
            tf_vector.x = tf.position.x;
            tf_vector.y = tf.position.y  - 4;
            tf_vector.z = tf.position.z;

            if (Physics.Raycast(tf_vector, Vector3.left * Ray_Distance, out hitInfo, Ray_Distance))
            {
                if (hitInfo.collider.name == "Player" && !hasAttacked)
                {
                    Debug.Log("Bird Enemy sees player!");
                    rb.AddForce(Vector3.down * 100);
                    rb.AddForce(Vector3.left * 50);
                    hasAttacked = true;
                }
            }
            Debug.DrawRay(tf_vector, Vector3.left * Ray_Distance, Color.red);
        }
        if (name == "CyborgEnemy")
        {
            tf_vector.x = tf.position.x;
            tf_vector.y = tf.position.y - RayY;
            tf_vector.z = tf.position.z;

            if (Physics.Raycast(tf_vector, Vector3.left * Ray_Distance, out hitInfo, Ray_Distance))
            {
                if (hitInfo.collider.name == "Player" && !hasAttacked)
                {
                    Debug.Log("Yellow Ball Enemy sees player!");
                    rb.AddForce(Vector3.up * 2000);
                    rb.AddForce(Vector3.left * 1000);
                    hasAttacked = true;
                }
            }
            Debug.DrawRay(tf_vector, Vector3.left * Ray_Distance, Color.red);
        }
        if (name == "CreepyEnemy")
        {
            tf_vector.x = tf.position.x;
            tf_vector.y = tf.position.y - RayY;
            tf_vector.z = tf.position.z;

            if (Physics.Raycast(tf_vector, Vector3.left * Ray_Distance, out hitInfo, Ray_Distance))
            {
                if (hitInfo.collider.name == "Player" && !hasAttacked)
                {
                    Debug.Log("Creepy Enemy sees player!");
                    StartCoroutine(CreepyEnemyAttack());
                    hasAttacked = true;
                }
            }
            Debug.DrawRay(tf_vector, Vector3.left * Ray_Distance, Color.red);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "sword" && GameObject.Find("Sword").GetComponent<SwordController>().isAttacking)
        {
            health -= 1;

        }
    }

    IEnumerator CreepyEnemyAttack()
    {
        yield return new WaitForEndOfFrame();
        for (int l = 0; l < 5; l++)
        {
            for (int i = 0; i < 10; i++)
            {
                tf.Translate(-0.075f, 0.25f, 0);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(2);
        }
    }
}
