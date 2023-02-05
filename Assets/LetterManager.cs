using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{  
    private List<ColliderScript> GigaBadColliderList;
    public List<ColliderScript> ColliderList;
    public List<ColliderScript> BadCollidersList;
    public List<ColliderScript> MiniorColliders;
    public Transform ParentCollider;
    public Transform ParentBadCollider;
    public Transform ParentMinorCollider;
    public Transform ParentGigaBadCollidser;
    private float NumberOfHitColliders = 0;
    private float Score = 0;
    private bool IsLetterComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfHitColliders = 0;
        foreach(Transform child in ParentCollider) {

            ColliderList.Add(child.GetComponent<ColliderScript>());
        };
        foreach(Transform child in ParentGigaBadCollidser) {
            GigaBadColliderList.Add(child.GetComponent<ColliderScript>());
        };
        foreach(Transform child in ParentBadCollider) {
            BadCollidersList.Add(child.GetComponent<ColliderScript>());
        };
        foreach(Transform child in ParentMinorCollider) {
            MiniorColliders.Add(child.GetComponent<ColliderScript>());
        };
    }

    // Update is called once per frame
    void Update()
    {
        Score = NumberOfHitColliders / ColliderList.Count;
        NumberOfHitColliders = 0;   
        foreach (ColliderScript Collider in ColliderList) {
            if(Collider.HasCollided()) {
                NumberOfHitColliders = NumberOfHitColliders + 1;
            }
        }
        if(NumberOfHitColliders == ColliderList.Count) { 
            //Insert Whatever
            Debug.Log("YOU WIN!");
        }
        
    }

    
}
