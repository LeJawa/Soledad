using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

    float timePassed = 0;

    float timeTutorial0 = 0.5f;
    bool tutorial0Triggered = false;

    float timeTutorial1 = 3f;
    bool tutorial1Triggered = false;

    float timeTutorial2 = 6f;
    bool tutorial2Triggered = false;

    float timeTutorial3 = 8f;
    bool tutorial3Triggered = false;

    float timeTutorial4 = 10f;
    bool tutorial4Triggered = false;

    float timeTutorial5 = 12f;
    bool tutorial5Triggered = false;

    float timeTutorial6 = 14f;
    bool tutorial6Triggered = false;

    float timeTutorial7 = 16f;
    bool tutorial7Triggered = false;

    float timeTutorial8 = 18f;
    bool tutorial8Triggered = false;

    float timeTutorial9 = 20f;
    bool tutorial9Triggered = false;

    float pauseAfterTutorial9 = 26f;
    bool pauseAfterTutorial9Triggered = false;

    float timeTutorial10 = 27f;
    bool tutorial10Triggered = false;

    float timeTutorial11 = 30f;
    bool tutorial11Triggered = false;

    float timeTutorial12 = 33f;
    bool tutorial12Triggered = false;

    float timeTutorial13 = 36f;
    bool tutorial13Triggered = false;

    float timeTutorial14 = 39f;
    bool tutorial14Triggered = false;

    float timeTutorialEnd = 45f;
    bool tutorialEndTriggered = false;

    [SerializeField]
    GameObject summary;
    [SerializeField]
    Text tutorial0;
    [SerializeField]
    Text tutorial1;
    [SerializeField]
    Text tutorial2;
    [SerializeField]
    Text tutorial3;
    [SerializeField]
    Text tutorial4;
    [SerializeField]
    Text tutorial5;
    [SerializeField]
    Text tutorial6;
    [SerializeField]
    Text tutorial7;
    [SerializeField]
    Text tutorial8;
    [SerializeField]
    Text tutorial9;
    [SerializeField]
    Text tutorial10;
    [SerializeField]
    Text tutorial11;
    [SerializeField]
    Text tutorial12;
    [SerializeField]
    Text tutorial13;
    [SerializeField]
    Text tutorial14;

    [SerializeField]
    TutorialSpawner tutorialSpawner;

    bool skipTutorial = false;


    // Start is called before the first frame update
    void Start() {

        if ( skipTutorial ) {
            timeTutorialEnd = 1;
        }

        GameEvents.current.onStartButtonClicked += FinishTutorial;

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update() {
        timePassed += Time.unscaledDeltaTime;
        if ( !tutorial0Triggered && timePassed > timeTutorial0 ) {
            tutorial0.gameObject.SetActive(true);
            tutorial0Triggered = true;
        }
        else if ( !tutorial1Triggered && timePassed > timeTutorial1 ) {
            tutorial1.gameObject.SetActive(true);
            tutorial0.gameObject.SetActive(false);
            tutorial1Triggered = true;
        }
        else if ( !tutorial2Triggered && timePassed > timeTutorial2 ) {
            tutorial1.gameObject.SetActive(false);
            tutorial2.gameObject.SetActive(true);
            tutorial2Triggered = true;
            tutorialSpawner.SpawnNextBatchOfNames();
        }
        else if ( !tutorial3Triggered && timePassed > timeTutorial3 ) {
            tutorial3.gameObject.SetActive(true);
            tutorial3Triggered = true;
            tutorialSpawner.SpawnNextBatchOfNames();
        }
        else if ( !tutorial4Triggered && timePassed > timeTutorial4 ) {
            tutorial4.gameObject.SetActive(true);
            tutorial4Triggered = true;
            tutorialSpawner.SpawnNextBatchOfNames();

        }
        else if ( !tutorial5Triggered && timePassed > timeTutorial5 ) {
            tutorial5.gameObject.SetActive(true);
            tutorial5Triggered = true;
            tutorialSpawner.SpawnNextBatchOfNames();

        }
        else if ( !tutorial6Triggered && timePassed > timeTutorial6 ) {
            tutorial6.gameObject.SetActive(true);
            tutorial6Triggered = true;

        }
        else if ( !tutorial7Triggered && timePassed > timeTutorial7 ) {
            tutorial7.gameObject.SetActive(true);
            tutorial7Triggered = true;
            tutorialSpawner.SpawnNextBatchOfNames();

        }
        else if ( !tutorial8Triggered && timePassed > timeTutorial8 ) {
            tutorial8.gameObject.SetActive(true);
            tutorial8Triggered = true;
            tutorialSpawner.SpawnNextBatchOfNames();

        }
        else if ( !tutorial9Triggered && timePassed > timeTutorial9 ) {
            tutorial9.gameObject.SetActive(true);
            tutorial9Triggered = true;
            tutorialSpawner.SpawnNextBatchOfNames();

        }
        else if ( !pauseAfterTutorial9Triggered && timePassed > pauseAfterTutorial9 ) {
            summary.gameObject.SetActive(false);
            pauseAfterTutorial9Triggered = true;
            tutorialSpawner.ClearAllTokens();

        }
        else if ( !tutorial10Triggered && timePassed > timeTutorial10 ) {
            tutorial10.gameObject.SetActive(true);
            tutorial10Triggered = true;
        }
        else if ( !tutorial11Triggered && timePassed > timeTutorial11 ) {
            tutorial10.gameObject.SetActive(false);
            tutorial11.gameObject.SetActive(true);
            tutorial11Triggered = true;
        }
        else if ( !tutorial12Triggered && timePassed > timeTutorial12 ) {
            // Trigger show relationships
            GameEvents.current.TriggerTutorial1();
            tutorial11.gameObject.SetActive(false);
            tutorial12.gameObject.SetActive(true);
            tutorial12Triggered = true;
        }
        else if ( !tutorial13Triggered && timePassed > timeTutorial13 ) {
            tutorial12.gameObject.SetActive(false);
            tutorial13.gameObject.SetActive(true);
            tutorial13Triggered = true;
        }
        else if ( !tutorial14Triggered && timePassed > timeTutorial14 ) {
            tutorial13.gameObject.SetActive(false);
            tutorial14.gameObject.SetActive(true);
            tutorial14Triggered = true;
            Time.timeScale = 1;
            RoundController.Instance.ActivateStartButton();
        }
        else if (!tutorialEndTriggered && timePassed > timeTutorialEnd) {

            // TO REMOVE!!!
            // Trigger show relationships
            if ( skipTutorial ) {
                Time.timeScale = 1;
                GameEvents.current.TriggerTutorial1();
                RoundController.Instance.ActivateStartButton();
            }


            FinishTutorial();

        }



    }

    void FinishTutorial() {
        GameEvents.current.TriggerTutorialEnd();
        Destroy(gameObject);

    }

    private void OnDestroy() {

        GameEvents.current.onStartButtonClicked -= FinishTutorial;
    }
}
