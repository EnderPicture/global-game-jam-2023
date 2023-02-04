using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public BodyPart[] bodyPartsL;
    public BodyPart[] bodyPartsR;

    private int indexL = 0;
    private int indexR = 0;

    private float lastAxisR;
    private float lastAxisL;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float selectR = Input.GetAxis("VerticalR");
        float selectL = Input.GetAxis("VerticalL");

        if (lastAxisL != 1 && selectL == 1)
        {

        }
        if (lastAxisL != -1 && selectL == -1)
        {

        }
        if (lastAxisR != 0 && selectR == 1)
        {

        }
        if (lastAxisR != -0 && selectR == -1)
        {

        }


        lastAxisL = selectL;
        lastAxisR = selectR;
    }
}
