using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    bool _languageManagerLoaded = false;

    float timePassed = 0;


    void Awake() {
        GameEvents.Instance.onFinishedLoadingLanguageManager += HandleFinishedLoadingLanguageManagerEvent;
    }

    private void HandleFinishedLoadingLanguageManagerEvent() {
        _languageManagerLoaded = true;
    }

    private void OnDestroy() {
        GameEvents.Instance.onFinishedLoadingLanguageManager -= HandleFinishedLoadingLanguageManagerEvent;
    }


    private void Update() {
        if ( _languageManagerLoaded && timePassed > 1.5f) {
            SceneManager.LoadScene("MainMenu");
        }
        timePassed += Time.deltaTime;
    }

}
