using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour {

    public void HandleBackToMenuButton() {
        GameEvents.current.TriggerResetEverything();
        SceneManager.LoadScene("MainMenu");
    }


    public void HandleBackToMenuButtonFromEnd() {
        GameEvents.current.TriggerResetEverything();
        Time.timeScale = 1;
        SceneManager.LoadScene("Dedicatoria");
    }
}
