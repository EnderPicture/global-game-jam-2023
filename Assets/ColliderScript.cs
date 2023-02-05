using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    private bool HasHitBody = false;
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
        HasHitBody = true;
    }

    private void OnTriggerExit(Collider other) {
        HasHitBody = false;
    }

    private void OnTriggerStay(Collider other)
    {
        HasHitBody = true;
    }

    public bool HasCollided() {
        return HasHitBody;
    }

}
