﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{
    private void Start() {
        GetComponentInChildren<Text>().text = LanguageManager.GetTextFromKey("new_game_button");
    }

    public void HandleNewGameButtonClicked() {
        GameController.current.StartNewGame();
    }
}
