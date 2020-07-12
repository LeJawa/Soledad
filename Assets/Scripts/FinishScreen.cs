using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour {

    [SerializeField]
    Text mainText;

    // Start is called before the first frame update
    void Start() {
        GenerateEndText();
    }


    void GenerateEndText() {
        string s = "";
        if ( RoundController.Instance.PersonsLeftToFind == 0 ) {
            s = "¡Felicidades!\nHas recordado a todo el mundo.";
        }
        else {
            s = "¡Oh oh!\nTu memoria ya no es tan rápida como antaño, esto te va a dejar algunas secuelas...";
            s += "\n\nHas olvidado " + RoundController.Instance.LastRoundRelationshipsLost + " parentescos entre los miembros de tu familia.";
        }
        s += "\n\nTodavía recuerdas " + RoundController.Instance.CurrentNumberOfRelationships + " parentescos.";

        mainText.text = s;

    }
}
