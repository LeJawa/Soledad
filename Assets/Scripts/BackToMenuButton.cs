using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour {

    public void HandleBackToMenuButton() {
        GameEvents.current.TriggerResetEverything();
        GameController.current.LoadMainMenu();
    }


    public void HandleBackToMenuButtonFromEnd() {
        GameController.current.LoadDedicatoria();
    }
}
