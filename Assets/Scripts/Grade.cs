using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grade : MonoBehaviour
{
    public Sprite A_Grade;
    public Sprite B_Grade;
    public Sprite C_Grade;
    public Sprite D_Grade;
    public Sprite F_Grade;
    private SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren(typeof(SpriteRenderer)) as SpriteRenderer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGrade(double percent) {
        if(percent < 50) {
            image.sprite = F_Grade;
        } else if(percent < 55) {
            image.sprite = D_Grade;
        } else if(percent < 67) {
            image.sprite = C_Grade;
        } else if(percent < 80) {
            image.sprite = B_Grade;
        } else {
            image.sprite = A_Grade;
        }
    }

    void animateGrade() {

    }
}
