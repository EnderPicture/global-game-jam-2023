using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{  
    private List<ColliderScript> GigaBadColliderList = new List<ColliderScript>();
    private List<ColliderScript> ColliderList = new List<ColliderScript>();
    private List<ColliderScript> BadCollidersList = new List<ColliderScript>();
    private List<ColliderScript> MinorColliders = new List<ColliderScript>();
    public Transform ParentCollider;
    public Transform ParentBadCollider;
    public Transform ParentMinorCollider;
    public Transform ParentGigaBadCollider;
    public TMPro.TextMeshPro text; 
    private float NumberOfHitColliders = 0;
    private float NumberOfGigaBadColliders = 0;
    private float NumberOfBadColliders = 0;
    private float NumberOfMinorColliders = 0;
    private float score = 0;
    private float old = 0;
    private bool disabled = true;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in ParentCollider) {
            ColliderScript collider = child.GetComponent<ColliderScript>();
            ColliderList.Add(collider);
            collider.enabled = false;
        };
        foreach(Transform child in ParentGigaBadCollider) {
            ColliderScript collider = child.GetComponent<ColliderScript>();
            GigaBadColliderList.Add(collider);
            collider.enabled = false;
        };
        foreach(Transform child in ParentBadCollider) {
            ColliderScript collider = child.GetComponent<ColliderScript>();
            BadCollidersList.Add(collider);
            collider.enabled = false;
        };
        foreach(Transform child in ParentMinorCollider) {
            ColliderScript collider = child.GetComponent<ColliderScript>();
            MinorColliders.Add(collider);
            collider.enabled = false;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(!disabled) {
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
            old = score;
            score = (NumberOfHitColliders/ColliderList.Count * 0.70f) 
                    + (NumberOfMinorColliders/MinorColliders.Count * 0.30f) 
                    - (NumberOfGigaBadColliders * 0.25f)
                    - (NumberOfBadColliders * 0.02f);
            score = Mathf.Max(score,0);
            if(score == 1) {
                text.color = new Color32(37, 255, 0, 181);
            }
            // Debug.Log(score);
            text.color = Color.Lerp(new Color32(221, 32, 9, 181), new Color32(130, 222, 116, 181), score);
        }
    }

    public void active() {
        disabled = false;
        foreach(ColliderScript child in ColliderList) {
            child.enabled = true;
        };
        foreach(ColliderScript child in GigaBadColliderList) {
            child.enabled = true;
        };
        foreach(ColliderScript child in BadCollidersList) {
            child.enabled = true;
        };
        foreach(ColliderScript child in MinorColliders) {
            child.enabled = true;
        };
    }
    
    public float getScore() {
        return score;
    }
}
