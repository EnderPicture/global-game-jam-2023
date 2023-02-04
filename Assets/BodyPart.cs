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

    public SpriteRenderer sprite;

    public BodyController bodyController;

    void Start()
    {
        rotation = transform.localRotation.eulerAngles.z;
    }

    private Ray _ray;

    // void Clicked()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         _ray = new Ray(
    //             Camera.main.ScreenToWorldPoint(Input.mousePosition),
    //             Camera.main.transform.forward);
    //         // or:
    //         //_ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

    //         if (Physics.Raycast(_ray, out _hit, 1000f))
    //         {
    //             if (_hit.transform == transform)
    //             {
    //                 Debug.Log("Click");
    //                 _renderer.material.color =
    //                     _renderer.material.color == Color.red ? Color.blue : Color.red;
    //             }
    //         }
    //     }
    // }

    void FixedUpdate()
    {
        float rotateR = Input.GetAxis("HorizontalR");
        float rotateL = Input.GetAxis("HorizontalL");

        if (selected)
        {
            sprite.color = new Color(1, 0, 0, 1);
            if (left)
            {
                rotation += rotateL * speedMultiplier;
            }
            if (right)
            {
                rotation += rotateR * speedMultiplier;
            }
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
}
