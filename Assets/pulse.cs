using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pulse : MonoBehaviour
{
    public Vector3 toVec = new Vector3(.35f,.35f,.35f);
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(toVec, speed).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
