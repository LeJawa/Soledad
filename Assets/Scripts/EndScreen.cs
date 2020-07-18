using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    [SerializeField]
    public Text endText;

    [SerializeField]
    public Text endButtonText;

    // Start is called before the first frame update
    void Start() {

        endText.text = LanguageManager.GetTextFromKey("end_text");
        endButtonText.text = LanguageManager.GetTextFromKey("end_button");

    }

    public void HandleBackToMenuButtonFromEnd() {
        GameController.current.LoadDedicatoria();
    }
}