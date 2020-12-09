using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPusher : MonoBehaviour
{
    private float ballSpeed = 30f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown("space")) { // キーコンフィグできるようにしたい
            rb.AddForce(transform.forward * ballSpeed, ForceMode.Impulse);
        }
    }
}
