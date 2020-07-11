using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassNameButton : MonoBehaviour {


    public void HandlePassNameButtonClicked() {
        RoundController.current.HandlePassTokenName();
    }
}
