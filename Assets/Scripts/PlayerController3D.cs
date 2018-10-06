using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour {

    public Rigidbody player_rb;
    public Rigidbody camera_rb;

    public Transform player_tf;
    public Transform camera_tf;

    public Quaternion quat;

    void Update()
    {
        //quat.x = 0;
        //quat.y = player_tf.rotation.y;
        //quat.z = 0;
        //quat.w = player_tf.rotation.w;
        //camera_tf.SetPositionAndRotation(player_tf.position, quat);
    }

    void FixedUpdate()
    {
        if (Input.GetKey("up"))
        {
            player_rb.AddForce(transform.forward * 3);
            camera_rb.AddForce(transform.forward * 3);
        }

        if (Input.GetKey("left"))
        {
            player_tf.Rotate(Vector3.down);
            camera_tf.Rotate(Vector3.down);

        }

        if (Input.GetKey("right"))
        {
            player_tf.Rotate(Vector3.up);
            camera_tf.Rotate(Vector3.up);
        }

        if (Input.GetKey("down"))
        {
            player_rb.AddForce(-transform.forward * 3);
            camera_rb.AddForce(-transform.forward * 3);
        }
    }
}
