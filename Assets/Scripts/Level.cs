using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level : MonoBehaviour
{
    private LetterManager letter;
    public Image timerPie;
    public TimerAnimation timerAnimation;
    public PerfectPopup perfectPopup;
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
            Debug.Log(score);
            if(score >= .999f && !perfectPopup.isShown()) {
                perfectPopup.appear();
            } 
            else if (score <= .999f && perfectPopup.isShown()){
                perfectPopup.fade();
            }
            // Debug.Log(score);
            if(timePassed > timerLength || ((Input.GetKeyDown("space") ||(Input.GetKeyDown(KeyCode.Space))) && timePassed > .5f)) {
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
            if(timerAnimation) {
                timerAnimation.animate();
            }
            letter.enabled = false;
            active = false;
            finished = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DOMove(new Vector3(-100,-1.5f,0), 1.5f));
            seq.Append(transform.DOMove(new Vector3(lastX, lastY, 0), .1f));
        }
    }

    public BodyController closestBody() {
        BodyController[] body = GetComponentsInChildren<BodyController>();
        BodyController closest = null;
        float closestDistance = float.MaxValue;
        foreach (BodyController b in body)
        {
            float distance = Vector3.Distance(Input.mousePosition, Camera.main.WorldToScreenPoint(b.transform.position));
            if(closestDistance > distance) {
                closest = b;
                closestDistance = distance;
            }
        }
        return closest;
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
        BodyController[] body = GetComponentsInChildren<BodyController>();
        foreach (BodyController b in body)
        {
            b.active();
        }
        letter.active();
        transform.DOMove(new Vector3(0,-1.5f,0), 1);
    }
}
