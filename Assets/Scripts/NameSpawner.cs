using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class NameSpawner : MonoBehaviour {

    float gameDurationTimeInSeconds = 20f;
    float secondsBeforeStartOfGame = 3f;

    Timer startTimer;
    Timer gameTimer;

    bool playing = false;

    PersonName PersonToFind;


    // Start is called before the first frame update
    void Start() {
        startTimer = gameObject.AddComponent<Timer>();
        startTimer.Duration = secondsBeforeStartOfGame;
        startTimer.onTimerFinished += StartGame;

        gameTimer = gameObject.AddComponent<Timer>();
        gameTimer.Duration = gameDurationTimeInSeconds;
        gameTimer.onTimerFinished += EndGame;

        GameEvents.current.onCenterPersonClicked += HandleCenterPersonClicked;

        startTimer.Run();

    }

    void StartGame() {
        playing = true;
        gameTimer.Run();
    }

    void EndGame() {
        playing = false;
    }

    void HandleCenterPersonClicked(PersonName name) {
        print(name);
    }

    void SpawnName() {

    }

    // Update is called once per frame
    void Update() {
        while ( playing ) {

        }
    }

    private void OnDestroy() {

        startTimer.onTimerFinished -= StartGame;
        gameTimer.onTimerFinished -= EndGame;
    }
}
