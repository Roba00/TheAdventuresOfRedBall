using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Sprite SwordAttack;
    public GameObject Sword;
    public Ray ray;

    public Transform tf;
    public Vector3 tf_vector;
    public float Ray_Distance = 5;
    public Rigidbody rb;
    public RaycastHit hitInfo;
    public bool hasAttacked = false;

    void FixedUpdate()
    {
        tf_vector.x = tf.position.x;
        tf_vector.y = tf.position.y;
        tf_vector.z = tf.position.z;

        if (Physics.Raycast(tf_vector, Vector3.left * Ray_Distance, out hitInfo, Ray_Distance))
        {
            if (hitInfo.collider.name == "Player" && !hasAttacked)
            {
                Debug.Log("Raycast2");
                rb.AddForce(Vector3.up * 1000);
                rb.AddForce(Vector3.left * 1000);
                hasAttacked = true;
            }
        }
        Debug.DrawRay(tf_vector, Vector3.left * Ray_Distance, Color.red);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sword")
        {
            Debug.Log("Collided with the sword!");
            if (Sword.GetComponent<SpriteRenderer>().sprite == SwordAttack)
            {
                Debug.Log("Killed enemy.");
                Destroy(gameObject);
            }
        }
    }
}
