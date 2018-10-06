using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public Transform camera_tf;
    public Transform plr_tf;
    public Vector3 camera_vector;
    public Quaternion camera_quat;


    public float sideScrollSpeed = 1f;
    public bool SideScroll = false;
    public bool cameraFreeze = false;
    

    void Start()
    {
       
    }

    void FixedUpdate()
    {
        if (!cameraFreeze)
        {
            if (SideScroll)
            {
                if (SceneManager.GetActiveScene().name == "BossLevel")
                {
                    camera_vector.y = plr_tf.position.y;
                }
                camera_tf.Translate(sideScrollSpeed * Time.deltaTime, 0, 0);
            }

            if (!SideScroll)
            {
                camera_vector.x = plr_tf.position.x;
                if (SceneManager.GetActiveScene().name == "BossLevel")
                {
                    camera_vector.y = plr_tf.position.y;
                }
                camera_vector.z = plr_tf.position.z - 10;
                camera_tf.SetPositionAndRotation(camera_vector, camera_quat);
            }
        }
    }
}
