using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassNameButton : MonoBehaviour {


    public void HandlePassNameButtonClicked() {
        RoundController.Instance.HandlePassTokenName();
    }
}
