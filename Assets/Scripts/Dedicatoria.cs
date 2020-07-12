using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dedicatoria : MonoBehaviour {

    Timer timer;

    // Start is called before the first frame update
    void Start() {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3f;
        timer.onTimerFinished += HandleTimerEnd;

        timer.Run();
    }

    void HandleTimerEnd() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy() {
        timer.onTimerFinished -= HandleTimerEnd;
    }
}
