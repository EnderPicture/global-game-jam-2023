using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationOffset = 0;
    public float speedMultiplier;

    public bool selected;
    public bool hovered;
    public bool tautable = true;

    public SpriteRenderer sprite;
    private Renderer r;

    public int index;

    void Start()
    {
        // rotationOffset = transform.localRotation.eulerAngles.z;
        r = sprite.GetComponent<Renderer>();
    }


    void FixedUpdate()
    {
        // float rotateR = Input.GetAxis("HorizontalR");
        // float rotateL = Input.GetAxis("HorizontalL");

        if (hovered)
        {
            sprite.material.SetFloat("_Size", .05f);
        }
        else
        {
            sprite.material.SetFloat("_Size", 0f);
        }
        // else
        // {
        //     sprite.color = new Color(1, 1, 1, 1);
        // }
        // transform.localRotation = Quaternion.Euler(0, 0, rotation);

    }
    public int getSortingOrder() {
        return r.sortingOrder;
    }
}
