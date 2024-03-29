using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GenerateShout : MonoBehaviour
{   
    public List<SpriteRenderer> ShoutOutList;
    public List<AudioClip> ReinaNoise;
    private int modePrev = -1;

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
        ShoutOutList[mode].gameObject.SetActive(false);
    }

    public void shout(int mode) {
        ShoutOutList[0].DOKill();
        if(modePrev != -1) {
            ShoutOutList[modePrev].gameObject.SetActive(false);
        }

        ShoutOutList[0].gameObject.SetActive(true);
        ShoutOutList[mode].gameObject.SetActive(true);
        ShoutOutList[0].DOFade(1.0f, 0.1f);
        ShoutOutList[mode].DOFade(1.0f, 0.1f);
        ShoutOutList[0].DOFade(0f, 1.0f).SetDelay(1);
        ShoutOutList[0].gameObject.transform.DOShakePosition(1.0f);
        ShoutOutList[mode].gameObject.transform.DOShakePosition(1.0f);
        ShoutOutList[mode].DOFade(0f, 1.0f).OnComplete(() => disable(mode)).SetDelay(1);
        
        modePrev = mode;
    }


    public void setShoutOut(string shoutOut) {
        MusicManager.Instance.ShoutSource.time = 0.7f;
        switch (shoutOut) {
            case ",":
                MusicManager.Instance.Shout(ReinaNoise[2]);
                shout(1);
                break;
            case "G":
                MusicManager.Instance.Shout(ReinaNoise[0]);
                shout(2);
                break;
            case "T":
                MusicManager.Instance.Shout(ReinaNoise[10]);
                shout(3);
                break;
            case "W":
                MusicManager.Instance.Shout(ReinaNoise[11]);
                shout(4);
                break;
            case "!":
                MusicManager.Instance.Shout(ReinaNoise[1]);
                shout(5);
                break;
            case "F":
                MusicManager.Instance.Shout(ReinaNoise[4]);
                shout(6);
                break;
            case "H":
                MusicManager.Instance.Shout(ReinaNoise[6]);
                shout(7);
                break;
            case "N":
                MusicManager.Instance.Shout(ReinaNoise[8]);
                shout(8);
                break;
            case "O":
                MusicManager.Instance.Shout(ReinaNoise[9]);
                shout(9);
                break;
            case "I":
                MusicManager.Instance.Shout(ReinaNoise[7]);
                shout(10);
                break;
            default:
                break;

        }
    }


}
