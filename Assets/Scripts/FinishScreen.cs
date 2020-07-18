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
            s = LanguageManager.GetTextFromKey("finish_congrats_1");
            s += '\n' + LanguageManager.GetTextFromKey("finish_congrats_2");
        }
        else {
            s = LanguageManager.GetTextFromKey("finish_lost_memories1");
            s += '\n' + LanguageManager.GetTextFromKey("finish_lost_memories2");
            s += "\n\n" + LanguageManager.GetTextFromKey("finish_lost_memories3");
            s += RoundController.Instance.LastRoundRelationshipsLost 
                + LanguageManager.GetTextFromKey("finish_lost_memories4");
        }
        s += "\n\n" + LanguageManager.GetTextFromKey("finish_ending1") + RoundController.Instance.CurrentNumberOfRelationships + LanguageManager.GetTextFromKey("finish_ending2");

        mainText.text = s;

    }
}
