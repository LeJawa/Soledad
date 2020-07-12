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
            s = "Congratulations!\nYou have remembered everyone.";
        }
        else {
            s = "Uh oh!\nYour memory is not as fast as it once was, this will probably leave some lasting effects...";
        }
        s += "\n\nDo you want to try again?";

        mainText.text = s;

    }
}
