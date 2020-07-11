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

    [SerializeField]
    Text tutorial0;
    [SerializeField]
    Text tutorial1;


    // Start is called before the first frame update
    void Start() {
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
            GameEvents.current.TriggerTutorial1();
            tutorial1.gameObject.SetActive(true);
            tutorial0.gameObject.SetActive(false);
            tutorial1Triggered = true;
        }

        else if ( !tutorial2Triggered && timePassed > timeTutorial2 ) {
            GameEvents.current.TriggerTutorialEnd();
            tutorial1.gameObject.SetActive(false);
            tutorial2Triggered = true;
            Time.timeScale = 1;
        }



    }
}
