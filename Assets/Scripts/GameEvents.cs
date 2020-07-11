using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour {

	public static GameEvents current;

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




    private void Awake() {
        if ( current != null ) {
            Destroy(gameObject);
        }
        else {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
    }


}

public class EventArguments<T> : EventArgs {
	T item;

	public EventArguments(T item) {
		this.item = item;
    }
}

