using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour {

    #region SINGLETON PATTERN
    static GameEvents current;
    public static GameEvents Instance {
        get {
            if ( current == null ) {
                current = GameObject.FindObjectOfType<GameEvents>();

                if ( current == null ) {
                    GameObject container = new GameObject("GameEvents");
                    current = container.AddComponent<GameEvents>();
                    DontDestroyOnLoad(current.gameObject);
                }
            }

            return current;
        }
    }
    #endregion

    #region onMouseClicked
    public event Action onMouseClicked;
    public void TriggerMouseClicked() {
        onMouseClicked?.Invoke();
    }
    #endregion


    #region onCenterPersonClicked
    public event Action<PersonName> onCenterPersonClicked;
    public void TriggerCenterPersonClicked(PersonName name) {
        onCenterPersonClicked?.Invoke(name);
    }
    #endregion


    #region onTutorial1
    public event Action onTutorial1;
    public void TriggerTutorial1() {
        onTutorial1?.Invoke();
    }
    #endregion


    #region onTutorialEnd
    public event Action onTutorialEnd;
    public void TriggerTutorialEnd() {
        onTutorialEnd?.Invoke();
    }
    #endregion

    #region onNameTokenFound
    public event Action onNameTokenFound;
    public void TriggerNameTokenFound() {
        onNameTokenFound?.Invoke();
    }
    #endregion

    #region onResetEverything
    public event Action onResetEverything;
    public void TriggerResetEverything() {
        onResetEverything?.Invoke();
    }
    #endregion

    #region onStartButtonClicked
    public event Action onStartButtonClicked;
    public void TriggerStartButtonClicked() {
        onStartButtonClicked?.Invoke();
    }
    #endregion

    #region onFinishedLoadingLanguageManager
    public event Action onFinishedLoadingLanguageManager;
    public void TriggerFinishedLoadingLanguageManager() {
        onFinishedLoadingLanguageManager?.Invoke();
    }
    #endregion



}

public class EventArguments<T> : EventArgs {
	T item;

	public EventArguments(T item) {
		this.item = item;
    }
}

