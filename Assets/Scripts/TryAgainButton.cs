using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainButton : MonoBehaviour {

    public void HandleTryAgainButtonClicked() {
        RoundController.Instance.HandleTryAgain();
        Destroy(GameObject.FindObjectOfType<FinishScreen>().gameObject);
    }
}
