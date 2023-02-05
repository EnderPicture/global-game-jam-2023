using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level : MonoBehaviour
{
    [HideInInspector]
    public BodyController body;
    private LetterManager letter;
    public Image timerPie;
    public float timerLength = 30;
    private float timePassed = 0;
    private bool finished = false;
    private bool active = false;

    public float lastX = 500;
    public float lastY = 500;
    // Start is called before the first frame update
    void Start() {
        body = GetComponentInChildren(typeof(BodyController)) as BodyController;
        letter = GetComponentInChildren(typeof(LetterManager)) as LetterManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            timePassed += Time.deltaTime;
            timerPie.fillAmount = timePassed / timerLength;
            if(timePassed > timerLength || Input.GetKeyDown("space")) {
                active = false;
                finished = true;
                transform.DOMove(new Vector3(-100,0,0), 1);
                Invoke("setupEnd", 1);
                // transform.position = new Vector3(-100,0,0);
            }
        }
    }

    public bool isNotInit() {
        return !active && !finished;
    }
    public bool isFinished() {
        return finished;
    }
    
    public void setupEnd() {
        transform.position = new Vector3(lastX, lastY, 0);
    }

    public void activate() {
        active = true;
        transform.DOMove(new Vector3(0,0,0), 1);
        // transform.position = new Vector3(0,0,0);
    }
}
