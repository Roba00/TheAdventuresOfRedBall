using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniBossController : MonoBehaviour
{
    public Transform MiniBossTf;
    public Vector3 MiniBossVector;
    public Vector3 MiniBossTextVector;
    public Transform MiniBossTextPosition;
    public TextMesh MiniBossHealth;
    public Quaternion quat;
    public int Health = 100;

    public Transform plrTf;
    public Vector3 plrVector;

    public Sprite SwordAttack;
    public GameObject Sword;
    public Camera Camera;

    public Rigidbody rb;
    public float Ray_Distance = 5;
    public bool hasAttacked;
    public new string name;
    public RaycastHit hitInfo;
    public GameObject FlameDiamond;
    public Vector3 FlameDiamondVector;
    public GameObject CloudWall1;
    public GameObject CloudWall2;

    public Sprite BossStandby;
    public Sprite BossAttack;
    public Sprite BossJumpAttack;

    public GameObject pipe;
    public GameObject player;
    public GameObject fireballPrefab;

    public void Update()
    {
        MiniBossHealth.text = name + System.Environment.NewLine + "Health: " + Health.ToString() + "%";
        if (Health == 0)
        {
            Debug.Log("Dead.");
            player.GetComponent<PlayerController>().score += 10;
            if (SceneManager.GetActiveScene().name == "Level3" || SceneManager.GetActiveScene().name == "BossLevel")
            {
                pipe.SetActive(true);
            }
            GameObject.Find("Main Camera").GetComponent<CameraController>().cameraFreeze = false;
            Destroy(CloudWall1);
            Destroy(CloudWall2);
            Destroy(MiniBossHealth);
            Destroy(FlameDiamond);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        plrVector.x = plrTf.position.x;
        plrVector.y = plrTf.position.y;
        plrVector.z = plrTf.position.z;

        if (name == "Royal Knight")
        {
            MiniBossTextVector.x = MiniBossTf.position.x - 4;
            MiniBossTextVector.y = MiniBossTf.position.y + 4.3f;
            MiniBossTextVector.z = MiniBossTf.position.z;
            MiniBossTextPosition.SetPositionAndRotation(MiniBossTextVector, quat);

            MiniBossVector.x = MiniBossTf.position.x;
            MiniBossVector.y = MiniBossTf.position.y - 2;
            MiniBossVector.z = MiniBossTf.position.z;

            if (Physics.Raycast(MiniBossVector, Vector3.left * Ray_Distance, out hitInfo, Ray_Distance))
            {
                if (hitInfo.collider.name == "Player" && !hasAttacked)
                {
                    Debug.Log("Royal Knight sees player!");
                    rb.AddForce(Vector3.up * 20000);
                    rb.AddForce(Vector3.left * 8000);
                    StartCoroutine((Wait(1)));
                    rb.AddForce(Vector3.right * 3000);
                    hasAttacked = true;
                }
            }
            Debug.DrawRay(MiniBossVector, Vector3.left * Ray_Distance, Color.red);
        }

        if (name == "Flame Bird")
        {
            MiniBossTextVector.x = MiniBossTf.position.x - 4;
            MiniBossTextVector.y = MiniBossTf.position.y + 3;
            MiniBossTextVector.z = MiniBossTf.position.z;
            MiniBossTextPosition.SetPositionAndRotation(MiniBossTextVector, quat);

            MiniBossVector.x = MiniBossTf.position.x;
            MiniBossVector.y = MiniBossTf.position.y - 4.5f;
            MiniBossVector.z = MiniBossTf.position.z;

            if (GameObject.Find("Main Camera").transform.position.x >= 60.94f && !hasAttacked)
            {
                    hasAttacked = true;
                    Debug.Log("Flame Bird sees player!");
                    GameObject.Find("Main Camera").GetComponent<CameraController>().cameraFreeze = true;
                    SpriteRenderer[] sprites = CloudWall1.GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer sprite in sprites)
                    {
                        sprite.enabled = true;
                    }
                    StartCoroutine(FlameBirdAttack());
                    hasAttacked = true;
            }
            Debug.DrawRay(MiniBossVector, Vector3.left * Ray_Distance, Color.red);
        }

        if (name == "Dark Knight")
        {
            BoxCollider collider = GetComponent<BoxCollider>();
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            if (renderer.sprite.name == "BossStandy")
            {
                collider.center = new Vector3(-0.5f, 0.07f, 0f);
                collider.size = new Vector3(3f, 5.6f, 0.2f);
            }
            if (renderer.sprite.name == "BossAttack")
            {
                collider.center = new Vector3(-1.25f, -0.1f, 0f);
                collider.size = new Vector3(4.75f, 5.2f, 0.2f);
            }
            if (renderer.sprite.name == "BossJumpAttack")
            {
                collider.center = new Vector3(-0.35f, 0f, 0f);
                collider.size = new Vector3(1.8f, 4.9f, 0.2f);
            }

            MiniBossTextVector.x = MiniBossTf.position.x;
            MiniBossTextVector.y = MiniBossTf.position.y + 2.5f;
            MiniBossTextVector.z = MiniBossTf.position.z;
            MiniBossTextPosition.SetPositionAndRotation(MiniBossTextVector, quat);

            MiniBossVector.x = MiniBossTf.position.x;
            MiniBossVector.y = MiniBossTf.position.y - 1.85f;
            MiniBossVector.z = MiniBossTf.position.z;

            if (GameObject.Find("Main Camera").transform.position.x >= 75.7f && !hasAttacked)
            {
                    hasAttacked = true;
                    Debug.Log("Dark Knight sees player!");
                    GameObject.Find("Main Camera").GetComponent<CameraController>().cameraFreeze = true;
                    StartCoroutine(DarkKnightAttack());
                    hasAttacked = true;
            }
            Debug.DrawRay(MiniBossVector, Vector3.left * Ray_Distance, Color.red);
        }

        if (name == "King Yellow")
        {
            BoxCollider collider = GetComponent<BoxCollider>();
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            if (renderer.sprite.name == "FinalBoss")
            {
                collider.center = new Vector3(-0.2f, 0.35f, 0);
                collider.size = new Vector3(4.3f, 4.2f, 0.2f);
            }
            if (renderer.sprite.name == "FinalBossAttack")
            {
                collider.center = new Vector3(-0.7f, 0.35f, 0);
                collider.size = new Vector3(5f, 4.2f, 0.2f);
            }

            MiniBossTextVector.x = MiniBossTf.position.x;
            MiniBossTextVector.y = MiniBossTf.position.y + 2.5f;
            MiniBossTextVector.z = MiniBossTf.position.z;
            MiniBossTextPosition.SetPositionAndRotation(MiniBossTextVector, quat);

            MiniBossVector.x = MiniBossTf.position.x;
            MiniBossVector.y = MiniBossTf.position.y - 1.85f;
            MiniBossVector.z = MiniBossTf.position.z;

            if (GameObject.Find("Main Camera").transform.position.x >= 66.4f && !hasAttacked)
            {
                    hasAttacked = true;
                    Debug.Log("King Yellow sees player!");
                    GameObject.Find("Main Camera").GetComponent<CameraController>().cameraFreeze = true;
                    StartCoroutine(FinalBossAttack());
                    hasAttacked = true;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Sword")
        {
            Debug.Log("Collided with the sword!");
            if (Sword.GetComponent<SpriteRenderer>().sprite == SwordAttack)
            {
                if (name == "Royal Knight")
                {
                    Health -= 20;
                }
                if (name == "Flame Bird")
                {
                    Health -= 5;
                }
                if (name == "Dark Knight")
                {
                    Health -= 5;
                }

                if (name == "King Yellow")
                {
                    Health -= 5;
                }
            }
        }
    }

    IEnumerator FlameDiamondDrop()
    {
        FlameDiamond.GetComponent<CapsuleCollider>().enabled = true;
        FlameDiamond.GetComponent<SpriteRenderer>().enabled = true;
        FlameDiamond.GetComponent<Rigidbody>().useGravity = true;
        FlameDiamondVector.x = MiniBossTf.position.x;
        FlameDiamondVector.y = MiniBossTf.position.y - 2;
        FlameDiamondVector.z = MiniBossTf.position.z;
        FlameDiamond.GetComponent<Transform>().SetPositionAndRotation(FlameDiamondVector, quat);
        yield return new WaitForSeconds(1f);
        FlameDiamond.GetComponent<CapsuleCollider>().enabled = false;
        FlameDiamond.GetComponent<SpriteRenderer>().enabled = false;
        FlameDiamond.GetComponent<Rigidbody>().useGravity = false;
    }

    IEnumerator Wait(int wait)
    {
        yield return new WaitForSeconds(wait);
    }

    IEnumerator FlameBirdAttack()
    {
        CloudWall1.GetComponent<BoxCollider>().enabled = true;

        for (int l = 0; l < 100; l++)
        {
            for (int i = 0; i < 140; i++)
            {
                MiniBossTf.Translate(Vector3.down * Time.deltaTime);
                yield return new WaitForEndOfFrame();
                if (i == 70 || i == 140)
                {
                    StartCoroutine(FlameDiamondDrop());
                }
            }

            for (int i = 0; i < 510; i++)
            {
                MiniBossTf.Translate(Vector3.left * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            for (int i = 0; i < 140; i++)
            {
                MiniBossTf.Translate(Vector3.up * Time.deltaTime);
                yield return new WaitForEndOfFrame();
                if (i == 70 || i == 140)
                {
                    StartCoroutine(FlameDiamondDrop());
                }
            }

            for (int i = 0; i < 510; i++)
            {
                MiniBossTf.Translate(Vector3.right * Time.deltaTime);
                yield return new WaitForEndOfFrame();
                if (i == 100 || i == 200 || i == 300 || i == 400 || i == 500 || i == 600 || i == 700 || i == 800 || i == 890)
                {
                    StartCoroutine(FlameDiamondDrop());
                }
            }
        }
    }

    IEnumerator DarkKnightAttack()
    {
        while (Health != 0)
        {
            //Attack
            for (int i = 0; i < 90; i++)
            {
                MiniBossTf.Translate(-0.04f, 0.01f, 0);
                yield return new WaitForEndOfFrame();
            }
            GetComponent<SpriteRenderer>().sprite = BossAttack;
            for (int i = 0; i < 100; i++)
            {
                MiniBossTf.Translate(0, -0.01f, 0);
            }

            //Move Back
            yield return new WaitForSeconds(2);
            GetComponent<SpriteRenderer>().sprite = BossStandby;
            for (int i = 0; i < 90; i++)
            {
                MiniBossTf.Translate(0.04f, 0, 0);
                yield return new WaitForEndOfFrame();
            }

            //Jump Attack
            GetComponent<SpriteRenderer>().sprite = BossJumpAttack;
            for (int l = 0; l < 4; l++)
            {
                for (int i = 0; i < 50; i++)
                {
                    MiniBossTf.Translate(-0.04f, 0.1f, 0);
                    yield return new WaitForEndOfFrame();
                }
                for (int i = 0; i < 50; i++)
                {
                    MiniBossTf.Translate(0, -0.1f, 0);
                    yield return new WaitForEndOfFrame();
                }
            }

            //Go Back
            GetComponent<SpriteRenderer>().sprite = BossStandby;
            for (int i = 0; i < 190; i++)
            {
                MiniBossTf.Translate(0.04f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator FinalBossAttack()
    {
        while (Health != 0)
        {
            GetComponent<SpriteRenderer>().sprite = BossStandby;
            //Jump on Cage
            for (int i = 0; i < 28; i++)
            {
                MiniBossTf.Translate(0.25f, 0.125f, 0);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(2);
            
            //Shoot Fireballs
            for (int i = 0; i < 1; i++)
            {
                var fireball1 = (GameObject)Instantiate(fireballPrefab);
                fireball1.transform.position = new Vector3(70,25,0);
                var fireball2 = (GameObject)Instantiate(fireballPrefab);
                fireball2.transform.position = new Vector3(65, 25, 0);
                var fireball3 = (GameObject)Instantiate(fireballPrefab);
                fireball3.transform.position = new Vector3(60, 25, 0);
                var fireball4 = (GameObject)Instantiate(fireballPrefab);
                fireball4.transform.position = new Vector3(55, 25, 0);
                var fireball5 = (GameObject)Instantiate(fireballPrefab);
                fireball5.transform.position = new Vector3(50, 25, 0);
                yield return new WaitForSeconds(3);
                Destroy(fireball1);
                Destroy(fireball2);
                Destroy(fireball3);
                Destroy(fireball4);
                Destroy(fireball5);
            }
            yield return new WaitForSeconds(3);

            //Land on Player
            for (int i = 0; i < 30; i++)
            {
                MiniBossTf.Translate(-0.2f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, -0.2f, 0);
                yield return new WaitForEndOfFrame();
            }
            GetComponent<AudioSource>().Play();
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, 0.2f, 0);
                yield return new WaitForEndOfFrame();
            }

            for (int i = 0; i < 30; i++)
            {
                MiniBossTf.Translate(-0.2f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, -0.2f, 0);
                yield return new WaitForEndOfFrame();
            }
            GetComponent<AudioSource>().Play();
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, 0.2f, 0);
                yield return new WaitForEndOfFrame();
            }

            for (int i = 0; i < 30; i++)
            {
                MiniBossTf.Translate(-0.2f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, -0.2f, 0);
                yield return new WaitForEndOfFrame();
            }
            GetComponent<AudioSource>().Play();
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, 0.2f, 0);
                yield return new WaitForEndOfFrame();
            }

            for (int i = 0; i < 30; i++)
            {
                MiniBossTf.Translate(-0.2f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, -0.2f, 0);
                yield return new WaitForEndOfFrame();
            }
            GetComponent<AudioSource>().Play();
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, 0.2f, 0);
                yield return new WaitForEndOfFrame();
            }

            for (int i = 0; i < 80; i++)
            {
                MiniBossTf.Translate(0.2f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < 17; i++)
            {
                MiniBossTf.Translate(0, -0.2f, 0);
                yield return new WaitForEndOfFrame();
            }

            //Attack With Cane
            yield return new WaitForSeconds(2);
            for(int i = 0; i < 70; i++)
            {
                MiniBossTf.Translate(-0.2f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
            GetComponent<SpriteRenderer>().sprite = BossAttack;
            yield return new WaitForSeconds(2);
            GetComponent<SpriteRenderer>().sprite = BossStandby;
            for (int i = 0; i < 70; i++)
            {
                MiniBossTf.Translate(0.2f, 0, 0);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(3);
        }
    }
}