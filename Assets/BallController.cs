using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool needPush; // AddForceする必要があるかどうか
    private bool stop;
    private float delta;
    private float span;
    Vector3 angle; // 移動方向
    // Start is called before the first frame update
    void Start()
    {
        needPush = false;
        stop = false;
        delta = 0.0f;
        span = 0.015f; // 0.015sに一回移動
    }

    // Update is called once per frame
    void Update() {

        if (!needPush && (Input.GetMouseButtonDown(2) || Input.GetKeyDown("space"))) { // キーコンフィグできるようにしたい
            this.transform.parent = null; // 親子関係を解消することでChangeAngleで角度を変更しても影響がない
            needPush = true; // 撃たれるのは一度だけ
            angle = transform.forward; // 矢印の向き
        } else if (needPush && transform.position.y < 20.5) { // 21.5は壁の高さ
            this.delta += Time.deltaTime;
            if (this.delta > this.span) {
                this.delta = 0.0f;
                transform.position += angle;

                if (transform.position.x > 9 || transform.position.x < -9) {
                    angle = new Vector3(-angle.x, angle.y, angle.z);
                }
            }
        } else if (!stop) {

            stop = true;
        } else {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        }
        

    }
}
