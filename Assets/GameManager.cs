using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] levels;
    private int levelIndex = 0;
    // Start is called before the first frame update
    private GenerateShout shoutManager;
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (levels.Length <= levelIndex)
        {
            //change scene
        }
        else
        {
            Level currentLevel = levels[levelIndex];
            if (currentLevel.isNotInit())
            {
                currentLevel.activate();
                GameObject[] shoutObject = GameObject.FindGameObjectsWithTag("shout");
                shoutManager = shoutObject[0].GetComponent<GenerateShout>();
                string name = levels[levelIndex].gameObject.name;
                shoutManager.setShoutOut("" + name[0]);
            }
            else if (currentLevel.isFinished())
            {
                levelIndex++;
            }
        }
    }
}
