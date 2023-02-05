using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] levels;
    private int levelIndex = 0;
    // Start is called before the first frame update
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
            }
            else if (currentLevel.isFinished())
            {
                levelIndex++;
            }
        }
    }
}
