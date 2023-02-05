using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [HideInInspector]
    public BodyController body;
    private LetterManager letter;
    public Image timerPie;
    private GenerateShout shoutload;
    public float timerLength = 30;
    private float timePassed = 0;
    private bool finished = false;
    private bool active = false;

    public float lastX = 500;
    public float lastY = 500;
    // Start is called before the first frame update
    void Start() {
        GameObject s = GameObject.FindGameObjectWithTag("shout");
        shoutload = s.GetComponent<GenerateShout>();
        shoutload.setShoutOut("G");
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
                transform.position = new Vector3(-100,0,0);
            }
        }
    }

    public bool isNotInit() {
        return !active && !finished;
    }
    public bool isFinished() {
        return finished;
    }

    public void activate() {
        active = true;
        transform.position = new Vector3(0,0,0);
    }
}
