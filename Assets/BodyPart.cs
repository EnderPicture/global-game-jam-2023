using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    // Start is called before the first frame update
    float rotation = 0;

    public bool left;
    public bool right;

    public float speedMultiplier;

    public bool selected;

    void Start()
    {
        rotation = transform.localRotation.eulerAngles.z;
    }

    void FixedUpdate()
    {
        float rotateR = Input.GetAxis("HorizontalR");
        float rotateL = Input.GetAxis("HorizontalL");

        if (selected)
        {
            if (left)
            {
                rotation += rotateL * speedMultiplier;
            }
            if (right)
            {
                rotation += rotateR * speedMultiplier;
            }
        }
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
}
