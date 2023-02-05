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

    private void disable(int mode) {
        ShoutOutList[0].enabled = false;
        ShoutOutList[mode].enabled = false;
    }

    public void shout(int mode) {
        ShoutOutList[0].gameObject.SetActive(true);
        ShoutOutList[mode].gameObject.SetActive(true);
        ShoutOutList[0].DOFade(0f, 1.0f).SetDelay(1);
        ShoutOutList[0].gameObject.transform.DOShakePosition(1.0f);
        ShoutOutList[mode].gameObject.transform.DOShakePosition(1.0f);
        ShoutOutList[mode].DOFade(.0f, 1.0f).OnComplete(() => disable(mode)).SetDelay(1);
    }


    public void setShoutOut(string shoutOut) {
        switch (shoutOut) {
            case ",":
                shout(1);
                break;
            case "G":
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
