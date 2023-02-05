using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] levels;
    public Camera mainCamera;
    public Camera endCamera;
    [HideInInspector]

    public bool end = false;
    private int levelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        endCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (levels.Length <= levelIndex || end)
        {
            end = true;
            mainCamera.enabled = false;
            endCamera.enabled = true;

            // Sequence mySequence = DOTween.Sequence();
            // // mySequence.Append(endCamera.transform.DOMove(new Vector3(-72.8f, 10.2f, -10), 1))
            // // .Append(endCamera.transform.DOMove(new Vector3(-114.8f, 11.9f, -10), .4f))
            // // .Append(endCamera.transform.DOMove(new Vector3(-87.6f, 11.9f, -10), .8f))
            // // .Append(endCamera.transform.DOMove(new Vector3(-100f, -.07f, -10), .3f))
            // // .Append(DOTween.To(()=> endCamera.orthographicSize, x=> endCamera.orthographicSize = x, 20, .8f));
            // mySequence.Play();
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
