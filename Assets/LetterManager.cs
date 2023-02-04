using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{   
    private GameObject[] BadColliderList;
    public ColliderScript[] ColliderList;
    private float NumberOfHitColliders;
    private float Score;
    private bool IsLetterComplete;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfHitColliders = 0;
        GameObject[] CollideGameComponent = GameObject.FindGameObjectsWithTag("collider");
        int index = 0;
        foreach (GameObject Collider in CollideGameComponent) {
            ColliderList[index] = (Collider.GetComponent<ColliderScript>());
            index = index + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score = NumberOfHitColliders / ColliderList.Length;
        NumberOfHitColliders = 0;   
        if(NumberOfHitColliders == ColliderList.Length) { 
            //Insert Whatever
            Debug.Log("YOU WIN!");
        }
        foreach (ColliderScript Collider in ColliderList) {
            // if(Collider.HasCollided()) {
            //     NumberOfHitColliders = NumberOfHitColliders + 1;
            // }
        }
    }

    
}
