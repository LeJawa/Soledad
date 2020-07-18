using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgainButton : MonoBehaviour {

    private void Start() {
        GetComponentInChildren<Text>().text = LanguageManager.GetTextFromKey("try_again_button");
    }


    public void HandleTryAgainButtonClicked() {
        RoundController.Instance.HandleTryAgain();
        Destroy(GameObject.FindObjectOfType<FinishScreen>().gameObject);
    }
}
