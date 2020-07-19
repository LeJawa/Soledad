using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    private void Start() {
        GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextFromKey("start_button");
    }

    public void HandleStartButtonClicked() {
        GameEvents.Instance.TriggerStartButtonClicked();
    }
}
