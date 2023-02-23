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
    private bool fingerDrag = false;

    private BodyPart currentBodyPart;
    private float startAngle;
    private Quaternion startRotation;
    private float startMagnitude;
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
                fingerDrag = false;
                if (Input.GetMouseButtonDown(0))
                {

                    indexClick = indexHovered;
                    if(indexClick != -1) {
                        Vector2 target;
                        Vector3 bodyPart = Camera.main.WorldToScreenPoint(bodyParts[indexClick].transform.position);
                        target.x = Input.mousePosition.x - bodyPart.x;
                        target.y = Input.mousePosition.y - bodyPart.y;
                        startAngle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
                        startRotation = bodyParts[indexClick].transform.rotation;
                        startMagnitude = target.magnitude;
                    }

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
                if (!fingerDrag) {
                    oldMousePosition = Input.mousePosition;
                    oldPosition = transform.position;
                    fingerDrag = true; 
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
        // Debug.Log(hits);
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
        else if(fingerDrag && !disable) {
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
                Vector2 target;
                Vector3 bodyPart = Camera.main.WorldToScreenPoint(currentBodyPart.transform.position);
                target.x = Input.mousePosition.x - bodyPart.x;
                target.y = Input.mousePosition.y - bodyPart.y;
                float angle = (Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg);
                float diffAngle = angle - startAngle;
                float speedOfRotation = 700;
                if(target.magnitude > 10) {
                    
                    Quaternion diff = startRotation * Quaternion.Euler(new Vector3(0, 0, diffAngle));
                    Quaternion rope = Quaternion.Euler(new Vector3(0, 0, angle+90));

                    Quaternion goal = diff;
                    if(currentBodyPart.tautable) {
                        float taut = Mathf.Pow(Mathf.Clamp01((target.magnitude - startMagnitude)/120), 1.7f);
                        goal = Quaternion.Slerp(diff, rope , taut);
                    }
                    currentBodyPart.transform.rotation =  Quaternion.RotateTowards(currentBodyPart.transform.rotation, goal, speedOfRotation * Time.deltaTime);

                }
            }

            if (Input.GetMouseButtonUp(1))
            {
                if(MouseRHit) {
                    MusicManager.Instance.Play(click2, .3f);
                    MouseRHit = false;
                }
            }
        }
        

    }
}
