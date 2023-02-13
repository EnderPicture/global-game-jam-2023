using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bob : MonoBehaviour
{
    private Tween t = null;
    public float y_move;
    public float speed = 1;
    public bool followBeat = false;
    // Start is called before the first frame update
    void Start()
    {
        if (followBeat) {
           Invoke("animate", 1.05f); 
        } else {
            animate();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void animate() {
        t = transform.DOMoveY(y_move, speed).SetLoops(-1, LoopType.Yoyo);
    }
    public void kill()
    {
        if(t != null) {
            t.Kill();
        }
        transform.DOScale(1f, speed);
    }
}
