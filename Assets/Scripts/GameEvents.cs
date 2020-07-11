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

