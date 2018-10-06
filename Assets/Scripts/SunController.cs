using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{

    public float sideScrollSpeed;
    public Transform tf;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tf.Translate(sideScrollSpeed * Time.deltaTime, 0, 0);
    }
}
