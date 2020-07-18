using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInFadeOut : MonoBehaviour {

    Text textComponent;
    Animator animationAnim;

    // Start is called before the first frame update
    void Start() {
        textComponent = GetComponent<Text>();
        animationAnim = GetComponent<Animator>();
    }


    void FadeOut() {
        animationAnim.SetTrigger("end");
    }



}
