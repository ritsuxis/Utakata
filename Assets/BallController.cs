using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool needPush; // AddForceする必要があるかどうか
    float delta;
    float span;
    Vector3 angle;
    // Start is called before the first frame update
    void Start()
    {
        needPush = false;
        delta = 0.0f;
        span = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!needPush && (Input.GetMouseButtonDown(2) || Input.GetKeyDown("space"))) { // キーコンフィグできるようにしたい
            this.transform.parent = null; // 親子関係を解消することでChangeAngleで角度を変更しても影響がない
            needPush = true; // 撃たれるのは一度だけ
            angle = transform.forward;
        }else if (needPush) {
            this.delta += Time.deltaTime;
            if (this.delta > this.span) {
                this.delta = 0.0f;
                transform.position += angle;
                if (transform.position.x > 9 || transform.position.x < -9) {
                    angle = new Vector3(-angle.x, angle.y, angle.z);
                }
            }
        }
    }
}
