using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{   
    private GameObject[] BadColliderList;
    public ColliderScript[] ColliderList;
    private float NumberOfHitColliders = 0;
    private float Score = 0;
    private bool IsLetterComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfHitColliders = 0;
        int index = 0;
        ColliderList = new ColliderScript[transform.childCount];
        foreach (Transform collider in transform) {
            ColliderList[index] = (collider.GetComponent<ColliderScript>());
            index = index + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score = NumberOfHitColliders / ColliderList.Length;
        NumberOfHitColliders = 0;   
        foreach (ColliderScript Collider in ColliderList) {
            if(Collider.HasCollided()) {
                NumberOfHitColliders = NumberOfHitColliders + 1;
            }
        }
        if(NumberOfHitColliders == ColliderList.Length) { 
            //Insert Whatever
            Debug.Log("YOU WIN!");
        }
        
    }

    
}
