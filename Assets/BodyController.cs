using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public BodyPart[] bodyParts;

    private int indexClick = -1;
    private int indexHovered = -1;

    private float lastAxisR;
    private float lastAxisL;

    private RaycastHit _hit;
    private Ray _ray;

    private bool mouseLDown = false;
    private bool mouseMoved = false;
    private bool MouseRHit = false;

    private BodyPart currentBodyPart;

    private Vector2 startMousePosition = new Vector2();
    private Vector2 realMouse = new Vector3();


    private float rotation = 0;
    private float startRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
    }


    void Clicked()
    {
        Vector2 realMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            indexClick = indexHovered;

        }

        else if (Input.GetMouseButtonDown(1))
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
                        MouseRHit = true;
                    }
                    i++;
                }
            }
        }
    }

    void Hover()
    {
        indexHovered = -1;
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
                    indexHovered = i;
                }
                i++;
            }
        }
    }

    void handleDrag()
    {
        if (MouseRHit)
        {
            Vector3 NewPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 FinalPosition = new Vector3(NewPosition.x, NewPosition.y, this.transform.position.z);
            this.transform.position = FinalPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Hover();
        Clicked();
        handleDrag();
        foreach (BodyPart bp in bodyParts)
        {
            bp.selected = false;
            bp.hovered = false;
        }
        if (indexHovered != -1)
        {
            bodyParts[indexHovered].hovered = true;
        }
        if (indexClick != -1)
        {
            bodyParts[indexClick].selected = true;
            currentBodyPart = bodyParts[indexClick];
        }
        else
        {
            currentBodyPart = null;
        }

        Vector2 currentMousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            mouseLDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            indexClick = -1;
            currentBodyPart = null;
            mouseLDown = false;
        }

        if (mouseLDown && currentBodyPart)
        {
            Vector3 target;
            // mouse_pos.z = 5.23; //The distance between the camera and object
            Vector3 bodyPart = Camera.main.WorldToScreenPoint(currentBodyPart.transform.position);
            target.x = Input.mousePosition.x - bodyPart.x;
            target.y = Input.mousePosition.y - bodyPart.y;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            // currentBodyPart.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
            currentBodyPart.transform.rotation = Quaternion.RotateTowards(currentBodyPart.transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle + 90)), 500 * Time.deltaTime);

            // var direction = (Input.mousePosition - currentBodyPart.transform.position).normalized;
            // direction = new Vector3(direction.x, direction.y, 0);
            // var targetRotation = Quaternion.LookRotation(direction);
            // currentBodyPart.transform.rotation = Quaternion.RotateTowards(currentBodyPart.transform.rotation, targetRotation, 50 * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(1))
        {
            MouseRHit = false;
        }

    }
}
