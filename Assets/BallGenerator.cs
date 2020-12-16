using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject prefabBall;
    public Transform parentObject;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a")) {
            Instantiate(prefabBall, parentObject);
        }
    }
}
