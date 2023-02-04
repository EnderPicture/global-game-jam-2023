using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public BodyPart[] bodyParts;

    private int indexClick = 0;

    private float lastAxisR;
    private float lastAxisL;

    private RaycastHit _hit;
    private Ray _ray;

    private bool mouseDown = false;
    private bool mosueMoved = false;

    private BodyPart currentBodyPart;

    private Vector2 startMousePosition = new Vector2();

    private float rotation = 0;
    private float startRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
    }


    void Clicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = new Ray(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Camera.main.transform.forward);

            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                _hit.transform.gameObject.GetComponent<BodyPart>();
                int i = 0;
                foreach (BodyPart bp in bodyParts)
                {
                    if (_hit.transform.gameObject.GetComponent<BodyPart>() == bp)
                    {
                        indexClick = i;
                    }
                    i++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Clicked();


        foreach (BodyPart bp in bodyParts)
        {
            bp.selected = false;
        }
        bodyParts[indexClick].selected = true;
        currentBodyPart = bodyParts[indexClick];




        Vector2 currentMousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            mosueMoved = false;
            startMousePosition = Input.mousePosition;
            startRotation = currentBodyPart.rotation;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        if (mouseDown)
        {
            float delta = (startMousePosition - currentMousePosition).y;
            currentBodyPart.rotation = startRotation + delta;
        }
    }
}
