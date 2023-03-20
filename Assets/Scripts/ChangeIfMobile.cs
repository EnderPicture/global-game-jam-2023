using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ChangeIfMobile : MonoBehaviour
{
    public Sprite mobileSprite;
    private SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren(typeof(SpriteRenderer)) as SpriteRenderer;
        if(isMobile()) {
            image.sprite = mobileSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [DllImport("__Internal")]
     private static extern bool IsMobile();
 
     public bool isMobile()
     {
         #if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
         #endif
         return false;
     }
}
