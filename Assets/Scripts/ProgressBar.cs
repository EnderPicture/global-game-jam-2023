using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update

    private List<Transform> progressBoxes = new List<Transform>();

    private int[] order = {
        5, 8, 7, 3, 4, 1, 2, 9, 11, 12, 6, 10, 13
    };

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            progressBoxes.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetProgress(int progress)
    {
        progressBoxes[order[progress] - 1].GetChild(0).gameObject.SetActive(true);
        progressBoxes[order[progress] - 1].GetComponent<Pulse>().enabled = true;
        if (progress - 1 >= 0)
        {
            progressBoxes[order[progress - 1] - 1].GetComponent<Pulse>().kill();
        }
    }
}
