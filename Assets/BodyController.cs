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


        if (lastAxisL < .01 && selectL >= .01)
        {
            indexL += 1;
        }
        if (lastAxisL < -.01 && selectL >= -.01)
        {
            indexL -= 1;
        }
        if (lastAxisR < .01 && selectR >= .01)
        {
            indexR += 1;
        }
        if (lastAxisR < -.01 && selectR >= -.01)
        {
            indexR -= 1;
        }


        if (indexR >= bodyPartsR.Length)
        {
            indexR = bodyPartsR.Length - 1;
        }
        if (indexR < 0)
        {
            indexR = 0;
        }
        if (indexL >= bodyPartsL.Length)
        {
            indexL = bodyPartsL.Length - 1;
        }
        if (indexL < 0)
        {
            indexL = 0;
        }

        foreach (BodyPart bp in bodyPartsL)
        {
            bp.selected = false;
        }
        foreach (BodyPart bp in bodyPartsR)
        {
            bp.selected = false;
        }

        bodyPartsL[indexL].selected = true;
        bodyPartsR[indexR].selected = true;


        lastAxisL = selectL;
        lastAxisR = selectR;
    }
}
