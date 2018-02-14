using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBoss : MonoBehaviour {

    
    public Transform MiniBossPosition;
    public Vector3 MiniBossVector;
    public Vector3 MiniBossTextVector;
    public Transform MiniBossTextPosition;
    public TextMesh MiniBossHealth;
    public Quaternion quat;

    public Sprite SwordAttack;
    public GameObject Sword;

    public Rigidbody rb;
    public float Ray_Distance = 5;
    public RaycastHit hitInfo;
    public bool hasAttacked;
    

    public int Health = 100;

    public void Update()
    {
        MiniBossHealth.text = "Health: " + Health.ToString() + "%";
        if (Health == 0)
        {
            Debug.Log("Dead.");
            Destroy(MiniBossHealth);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        MiniBossTextVector.x = MiniBossPosition.position.x - 4;
        MiniBossTextVector.y = MiniBossPosition.position.y + 4;
        MiniBossTextVector.z = MiniBossPosition.position.z;
        MiniBossTextPosition.SetPositionAndRotation(MiniBossTextVector, quat);

        MiniBossVector.x = MiniBossPosition.position.x;
        MiniBossVector.y = MiniBossPosition.position.y - 2f;
        MiniBossVector.z = MiniBossPosition.position.z;

        if (Physics.Raycast(MiniBossVector, Vector3.left * Ray_Distance, out hitInfo, Ray_Distance))
        {
            if (hitInfo.collider.name == "Player" && !hasAttacked)
            {
                Debug.Log("Raycast2");
                rb.AddForce(Vector3.up * 20000);
                rb.AddForce(Vector3.left * 8000);
                StartCoroutine((Wait(1)));
                rb.AddForce(Vector3.right * 3000);
                hasAttacked = true;
            }
        }

        Debug.DrawRay(MiniBossVector, Vector3.left * Ray_Distance, Color.red);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sword")
        {
            Debug.Log("Collided with the sword!");
            if (Sword.GetComponent<SpriteRenderer>().sprite == SwordAttack)
            {
                Health -= 20;
            }
        }
    }

    IEnumerator Wait(int wait)
    {
        yield return new WaitForSeconds(wait);
    }
}
