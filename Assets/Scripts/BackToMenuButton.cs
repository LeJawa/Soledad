using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenuButton : MonoBehaviour {

    private void Start() {
        GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextFromKey("back_to_menu_button");
    }

    public void HandleBackToMenuButton() {
        GameEvents.Instance.TriggerResetEverything();
        GameController.Instance.LoadMainMenu();
    }
}
