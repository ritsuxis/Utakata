using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAngle : MonoBehaviour
{
    // Start is calld before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {
        // キーコンフィグできるようにしたい
        if (Input.GetMouseButton(0)) {
            this.transform.Rotate(0f, 0f, 1f, Space.Self);
            if (!NowAngleis()) this.transform.Rotate(0f, 0f, -1f, Space.Self);
        } else if (Input.GetMouseButton(1)) {
            this.transform.Rotate(0f, 0f, -1f, Space.Self);
            if (!NowAngleis()) this.transform.Rotate(0f, 0f, 1f, Space.Self);
        }
        Debug.Log(this.transform.localEulerAngles.z);
    }

    bool NowAngleis() {
        var angle = this.transform.localEulerAngles.z; // 0~360の値で得られる
        if (angle < 90f || 270f < angle) return true;
        else return false;
    }
}
