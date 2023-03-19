using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    private int HasHitBody = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger) {
            HasHitBody++;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.isTrigger) {
            HasHitBody--;
        }        
    }

    public bool HasCollided() {
        return HasHitBody > 0;
    }

}
