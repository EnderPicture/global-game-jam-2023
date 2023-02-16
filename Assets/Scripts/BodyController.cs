using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    [Range(0, 10)]
    public int style;
    public SpriteRenderer[] sprites;

    public BodyPart[] bodyParts;

    private int indexClick = -1;
    private int indexHovered = -1;

    private float lastAxisR;
    private float lastAxisL;

    private RaycastHit _hit;
    private Ray _ray;

    private bool mouseLDown = false;
    private bool MouseRHit = false;

    private BodyPart currentBodyPart;
    private Vector3 oldMousePosition;
    private Vector3 oldPosition;
    private bool disable = false;

    public AudioClip click;
    public AudioClip click2;
    // Start is called before the first frame update
    void Start()
    {
        SetStyle();
    }

    public void disabled() {
        foreach (BodyPart b in bodyParts) {
            b.hovered = false;
            b.selected = false;
        }

        disable = true;
        indexClick = -1;
        currentBodyPart = null;
        mouseLDown = false;
        MouseRHit = false;
    }


    void Clicked()
    {
        if(!disable) {
            Vector2 realMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.touchCount < 2) {

                if (Input.GetMouseButtonDown(0))
                {

                    indexClick = indexHovered;

                }

                else if (Input.GetMouseButtonDown(1))
                {
                    if(indexHovered != -1) {
                        MouseRHit = true;
                        oldMousePosition = Input.mousePosition;
                        oldPosition = transform.position;
                    } 
                    
                }
            } else {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began) {
                    MouseRHit = true;
                    oldMousePosition = Input.mousePosition;
                    oldPosition = transform.position;
                }

                if (touch.phase == TouchPhase.Moved && MouseRHit)
                {
                    Vector3 oldMouse = Camera.main.ScreenToWorldPoint(oldMousePosition);
                    Vector3 newMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 delta = newMouse - oldMouse;
                    this.transform.position = oldPosition + delta;
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }     
                if (touch.phase == TouchPhase.Ended) {
                    MouseRHit = false;
                    oldMousePosition = Input.mousePosition;
                    oldPosition = transform.position;
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
        int layerMask = 1 << 7;
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, 1000f, layerMask);
        Debug.Log(hits);
        if (hits.Length > 0) 
        {
           
            int highestSortingLayer = -999;
            BodyPart mostVisibleBodyPart = null;
            foreach(RaycastHit rayHit in hits) {
                BodyPart bphit = rayHit.transform.gameObject.GetComponent<BodyPart>();
                if(bphit.getSortingOrder() > highestSortingLayer) {
                    highestSortingLayer = bphit.getSortingOrder();
                    mostVisibleBodyPart = bphit;
                }
                
            }
            int i = 0;
            foreach (BodyPart bp in bodyParts)
            {
                if (mostVisibleBodyPart == bp)
                {
                    indexHovered = i;
                    
                }
                i++;
            }
            
        }
    }

    void handleDrag()
    {
        if (MouseRHit && !disable)
        {
            Vector3 oldMouse = Camera.main.ScreenToWorldPoint(oldMousePosition);
            Vector3 newMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 delta = newMouse - oldMouse;
            this.transform.position = oldPosition + delta;
        }
    }

    void SetStyle()
    {
        foreach (SpriteRenderer spriteRenderer in sprites)
        {
            string fileName = "character/" + spriteRenderer.sprite.name;
            if (style != 10)
            {
                fileName += "_";
                fileName += 36 * style;
            }
            // Debug.Log(fileName);
            spriteRenderer.sprite = Resources.Load(fileName, typeof(Sprite)) as Sprite;
            // Debug.Log(Resources.Load(fileName, typeof(Sprite)) as Sprite);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Hover();
        if(!disable) {
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
                if(currentBodyPart != null) {
                    MusicManager.Instance.Play(click,.5f);
                }
                
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
                if(MouseRHit) {
                    MusicManager.Instance.Play(click2, .3f);
                    MouseRHit = false;
                }
            }
            // if ()
        }
        

    }
}
