using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimerAnimation : MonoBehaviour
{
    private Sequence animationSequence;
    // Start is called before the first frame update
    void Start()
    {
        animate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void animate() {
        animationSequence = DOTween.Sequence();
        animationSequence.Append(transform.DORotate(new Vector3(0,0,20), .13f));
        animationSequence.Append(transform.DORotate(new Vector3(0,0, -5), .08f));
        animationSequence.Append(transform.DORotate(new Vector3(0,0, 0), .06f));
    }
}
