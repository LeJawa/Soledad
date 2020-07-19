using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassNameButton : MonoBehaviour {

    private void Start() {
        GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextFromKey("pass_name_button");
    }

    public void HandlePassNameButtonClicked() {
        RoundController.Instance.HandlePassTokenName();
    }
}
