using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DisableIfMobile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!isMobile()) {
            this.gameObject.SetActive(false);
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
