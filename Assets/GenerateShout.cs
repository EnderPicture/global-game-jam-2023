using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GenerateShout : MonoBehaviour
{   
    public List<SpriteRenderer> ShoutOutList;

    //Index 0 is the big speech bubble
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shout(int mode) {
        ShoutOutList[0].enabled = true;
        ShoutOutList[mode].enabled = true;
        ShoutOutList[0].DOFade(1.0f, 2.0f);
        ShoutOutList[mode].DOFade(.0f, 2.0f);
        ShoutOutList[0].enabled = false;
        ShoutOutList[mode].enabled = false;
    }


    public void setShoutOut(string shoutOut) {
        switch (shoutOut) {
            case ",":
                shout(1);
                break;
            case "G":
                Debug.Log("G CALLED");
                shout(2);
                break;
            case "T":
                shout(3);
                break;
            case "W":
                shout(4);
                break;
            case "!":
                shout(5);
                break;
            case "F":
                shout(6);
                break;
            case "H":
                shout(7);
                break;
            case "N":
                shout(8);
                break;
            case "O":
                shout(9);
                break;
            default:
                break;

        }
    }


}
