using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float ballSpeed = 30f;
    private Rigidbody rb;
    private bool needPush; // AddForceする必要があるかどうか
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        needPush = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!needPush && (Input.GetMouseButtonDown(2) || Input.GetKeyDown("space"))) { // キーコンフィグできるようにしたい
            rb.AddForce(transform.forward * ballSpeed, ForceMode.Impulse); // Push
            this.transform.parent = null; // 親子関係を解消することでChangeAngleで角度を変更しても影響がない
            needPush = true; // 一度だけAddForceする
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "UpperWall") {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
