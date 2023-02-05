using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotation = 0;
    
    public float speedMultiplier;

    public bool selected;

    public SpriteRenderer sprite;

    public int index;

    void Start()
    {
        rotation = transform.localRotation.eulerAngles.z;
    }


    void FixedUpdate()
    {
        // float rotateR = Input.GetAxis("HorizontalR");
        // float rotateL = Input.GetAxis("HorizontalL");

        // if (selected)
        // {
        //     sprite.color = new Color(1, 0, 0, 1);
        //     rotation += rotateL * speedMultiplier;
        // }
        // else
        // {
        //     sprite.color = new Color(1, 1, 1, 1);
        // }
        // transform.localRotation = Quaternion.Euler(0, 0, rotation);

    }
}
