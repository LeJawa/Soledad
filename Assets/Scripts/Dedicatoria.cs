using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dedicatoria : MonoBehaviour {

    Timer timer;

    // Start is called before the first frame update
    void Start() {

        string text = LanguageManager.GetTextFromKey("dedicatoria_1");
        text += "\n\n\n\n" + LanguageManager.GetTextFromKey("dedicatoria_2");

        FindObjectOfType<Text>().text = text;


        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3f;
        timer.onTimerFinished += HandleTimerEnd;

        timer.Run();
    }

    void HandleTimerEnd() {
        GameController.current.LoadMainMenu();
    }

    private void OnDestroy() {
        timer.onTimerFinished -= HandleTimerEnd;
    }
}
