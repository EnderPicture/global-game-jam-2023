using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level : MonoBehaviour
{
    private LetterManager letter;
    public Image timerPie;
    public GameObject timerRotate;
    public float timerLength = 30;
    private float timePassed = 0;
    private bool finished = false;
    private bool active = false;

    public float lastX = 500;
    public float lastY = 500;
    private float score = 0;
    // Start is called before the first frame update
    void Start() {
        letter = GetComponentInChildren(typeof(LetterManager)) as LetterManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            
            timePassed += Time.deltaTime;
            timerPie.fillAmount = timePassed / timerLength;
            score = letter.getScore();
            // Debug.Log(score);
            if(timePassed > timerLength || (Input.GetKeyDown("space") && timePassed > .5f)) {
                finishLevel();
            }
        }
    }

    public void finishLevel() {
        if(active){
            BodyController[] body = GetComponentsInChildren<BodyController>();
            foreach (BodyController b in body)
            {
                b.disabled();
            }
            letter.enabled = false;
            active = false;
            finished = true;
            transform.DOMove(new Vector3(-100,-1.5f,0), 1);
            Invoke("setupEnd", 1.05f);
        }
    }

    public float getScore() {
        return score;
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
        transform.DOMove(new Vector3(0,-1.5f,0), 1);
        // transform.position = new Vector3(0,0,0);
    }
}
