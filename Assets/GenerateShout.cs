using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GenerateShout : MonoBehaviour
{   
    public List<SpriteRenderer> ShoutOutList;
    public List<AudioClip> ReinaNoise;

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
        ShoutOutList[0].gameObject.SetActive(false);
        ShoutOutList[mode].gameObject.SetActive(false);
    }

    public void shout(int mode) {


        ShoutOutList[0].gameObject.SetActive(true);
        ShoutOutList[mode].gameObject.SetActive(true);
        ShoutOutList[0].DOFade(1.0f, 0.1f);
        ShoutOutList[mode].DOFade(1.0f, 0.1f);
        ShoutOutList[0].DOFade(0f, 1.0f).SetDelay(1);
        ShoutOutList[0].gameObject.transform.DOShakePosition(1.0f);
        ShoutOutList[mode].gameObject.transform.DOShakePosition(1.0f);
        ShoutOutList[mode].DOFade(0f, 1.0f).OnComplete(() => disable(mode)).SetDelay(1);
    }


    public void setShoutOut(string shoutOut) {
        MusicManager.Instance.EffectsSource.time = 0.7f;
        switch (shoutOut) {
            case ",":
                MusicManager.Instance.Play(ReinaNoise[2]);
                shout(1);
                break;
            case "G":
                MusicManager.Instance.Play(ReinaNoise[0]);
                shout(2);
                break;
            case "T":
                MusicManager.Instance.Play(ReinaNoise[10]);
                shout(3);
                break;
            case "W":
                MusicManager.Instance.Play(ReinaNoise[11]);
                shout(4);
                break;
            case "!":
                MusicManager.Instance.Play(ReinaNoise[1]);
                shout(5);
                break;
            case "F":
                MusicManager.Instance.Play(ReinaNoise[4]);
                shout(6);
                break;
            case "H":
                MusicManager.Instance.Play(ReinaNoise[6]);
                shout(7);
                break;
            case "N":
                MusicManager.Instance.Play(ReinaNoise[8]);
                shout(8);
                break;
            case "O":
                MusicManager.Instance.Play(ReinaNoise[9]);
                shout(9);
                break;
            case "I":
                MusicManager.Instance.Play(ReinaNoise[7]);
                shout(10);
                break;
            default:
                break;

        }
    }


}
