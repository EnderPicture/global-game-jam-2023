using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{  
    public List<ColliderScript> GigaBadColliderList;
    public List<ColliderScript> ColliderList;
    public List<ColliderScript> BadCollidersList;
    public List<ColliderScript> MinorColliders;
    public Transform ParentCollider;
    public Transform ParentBadCollider;
    public Transform ParentMinorCollider;
    public Transform ParentGigaBadCollidser;
    private float NumberOfHitColliders = 0;
    private float NumberOfGigaBadColliders = 0;
    private float NumberOfBadColliders = 0;
    private float NumberOfMinorColliders = 0;
    private float Score = 0;
    private float old = 0;
    // Start is called before the first frame update
    void Start()
    {
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
            MinorColliders.Add(child.GetComponent<ColliderScript>());
        };
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfHitColliders = 0;
        NumberOfGigaBadColliders = 0;
        NumberOfBadColliders = 0;
        NumberOfMinorColliders = 0;
        foreach (ColliderScript Collider in ColliderList) {
            if(Collider.HasCollided()) {
                NumberOfHitColliders = NumberOfHitColliders + 1;
            }
        }
        foreach (ColliderScript Collider in GigaBadColliderList) {
            if(Collider.HasCollided()) {
                NumberOfGigaBadColliders = NumberOfGigaBadColliders + 1;
            }
        }
        
        foreach (ColliderScript Collider in BadCollidersList) {
            if(Collider.HasCollided()) {
                NumberOfBadColliders = NumberOfBadColliders + 1;
            }
        }
        
        foreach (ColliderScript Collider in MinorColliders) {
            if(Collider.HasCollided()) {
                NumberOfMinorColliders = NumberOfMinorColliders + 1;
            }
        }
        // Core nodes/total core nodes * 70% + 
        // minorNodes/total minor nodes * 30% +
        // Massive penalty (-25%) + 
        // minor penalty (-2%)
        old = Score;
        Score = (NumberOfHitColliders/ColliderList.Count * 0.70f) 
                + (NumberOfMinorColliders/MinorColliders.Count * 0.30f) 
                - (NumberOfGigaBadColliders * 0.25f)
                - (NumberOfBadColliders * 0.02f);
        Score = Mathf.Max(Score,0);
    }

    public float getScore() {
        return Score;
    }
}
