using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    // Start is called before the first frame update
    float rotation = 0;

    public bool right;
    public bool left;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rotateR = Input.GetAxis("HorizontalR");
        float rotateL = Input.GetAxis("HorizontalL");

        if (right) {
            rotation += rotateR;
        }
        if (left) {
            rotation += rotateL;
        }

        gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
