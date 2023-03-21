using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PerfectPopup : MonoBehaviour
{
    public SpriteRenderer speechBubble;
    public TMPro.TextMeshPro text;
    private bool shown = false;
    // Start is called before the first frame update
    void Start()
    {
        speechBubble = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TMPro.TextMeshPro>();
        speechBubble.DOFade(0,0);
        text.DOFade(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isShown() {
        return shown;
    }
    private void killTween() {
        speechBubble.DOKill();
        text.DOKill();
    }
    public void fade() {
        shown = false;
        killTween();
        speechBubble.DOFade(0,2);
        text.DOFade(0,2);
    }
    public void appear() {
        shown = true;
        killTween();
        speechBubble.DOFade(1,.1f);
        text.DOFade(1,.1f);
    }
}
