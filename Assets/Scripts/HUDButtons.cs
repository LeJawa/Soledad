using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDButtons : MonoBehaviour {


    public void HandlePassNameButtonClicked() {
        RoundController.Instance.HandlePassTokenName();
    }

    public void HandleStartButtonClicked() {
        GameEvents.current.TriggerStartButtonClicked();
    }
}
