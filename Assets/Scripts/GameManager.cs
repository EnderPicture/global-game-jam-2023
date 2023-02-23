using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] levels;
    public Camera mainCamera;
    public Camera endCamera;
    public TMPro.TextMeshPro percent_text;

    public GameObject tut;
    public Grade grade;
    [HideInInspector]

    public bool end = false;
    private int levelIndex = 0;
    // Start is called before the first frame updategit 
    private GenerateShout shoutManager;
    private double sum = 0;

    public ProgressBar progressBar;
    public GameObject skipButton;

    private bool applaused = false;
    void Start()
    {
        DOTween.Init();
        endCamera.enabled = false;
    }

    public GameObject ParticleSystemLeft;
    public GameObject ParticleSystemRight;

    public AudioClip endingAudio;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Ray _ray = new Ray(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Camera.main.transform.forward);
            int layerMask = 1 << 5; //ui
            bool hit = Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, 1000f, layerMask); 
            if (hit) {
                levels[levelIndex].finishLevel();
            }
        }
        if (levels.Length <= levelIndex || end)
        {
            end = true;
            mainCamera.enabled = false;
            endCamera.enabled = true;
            progressBar.gameObject.SetActive(false);
            endCamera.GetComponent<Animator>().SetBool("Run", true);

            double finalScore = (sum / levels.Length);
            int percent = (int)(finalScore * 100);
            percent_text.text = percent + "%";
            grade.setGrade(finalScore*100);

            //Play Audio
            if (!applaused)
            {
                MusicManager.Instance.Play(endingAudio);
                applaused = true;
            }
        }
        else
        {
            Level currentLevel = levels[levelIndex];
            if (currentLevel.isNotInit())
            {
                progressBar.SetProgress(levelIndex);




                currentLevel.activate();
                GameObject[] shoutObject = GameObject.FindGameObjectsWithTag("shout");
                shoutManager = shoutObject[0].GetComponent<GenerateShout>();
                string name = levels[levelIndex].gameObject.name;




                shoutManager.setShoutOut("" + name[0]);
            }
            else if (currentLevel.isFinished())
            {
                tut.SetActive(false);
                ParticleSystemLeft.SetActive(false);
                ParticleSystemRight.SetActive(false);
                ParticleSystemLeft.SetActive(true);
                ParticleSystemRight.SetActive(true);
                sum += currentLevel.getScore();
                levelIndex++;
            }
        }
    }
}
