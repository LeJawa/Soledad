using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class NameSpawner : MonoBehaviour {

    float gameDurationTimeInSeconds = 20f;
    float secondsBeforeStartOfGame = 5f;

    Timer startTimer;
    Timer gameTimer;

    [SerializeField]
    Text gameTimerText;

    bool playing = true;

    PersonName personToFind;
    int NumberOfPersonNames = System.Enum.GetValues(typeof(PersonName)).Length;
    Vector3 lastTokenPosition = new Vector3(-6.5f, -5, 0);
    Vector3 tokenOffset = new Vector3(0.5f, 0, 0);
    int sortingOrderOfTokens = 0;

    [SerializeField]
    GameObject prefabNameToken;

    [SerializeField]
    GameObject prefabFinishScreen;


    // Start is called before the first frame update
    void Start() {
        startTimer = gameObject.AddComponent<Timer>();
        startTimer.Duration = secondsBeforeStartOfGame;
        startTimer.onTimerFinished += StartGame;

        gameTimer = gameObject.AddComponent<Timer>();
        gameTimer.Duration = gameDurationTimeInSeconds;
        gameTimer.onTimerFinished += EndGame;

        GameEvents.current.onCenterPersonClicked += HandleCenterPersonClicked;
        GameEvents.current.onTutorialEnd += StartStartTimer;


    }

    void StartStartTimer() {
        startTimer.Run();

    }

    void StartGame() {
        gameTimer.Run();
        SpawnNewName();
    }

    void EndGame() {
        playing = false;
        Time.timeScale = 0;

        Instantiate(prefabFinishScreen);
    }

    void HandleCenterPersonClicked(PersonName name) {
        if ( personToFind == name) {
            GameEvents.current.TriggerNameTokenFound();
            SpawnNewName();
        }

    }

    void SpawnNewName() {
        int nameInt = Random.Range(0, NumberOfPersonNames);
        personToFind = (PersonName) nameInt;

        GameObject nameToken = Instantiate(prefabNameToken);
        SpriteRenderer spriteRenderer = nameToken.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SpriteManager.current.GetSpriteFromPerson(personToFind);
        //spriteRenderer.color = SpriteManager.current.GetSpriteColorFromPersonName(personToFind);
        spriteRenderer.sortingOrder = sortingOrderOfTokens++;

        nameToken.transform.position = lastTokenPosition + tokenOffset;
        lastTokenPosition = nameToken.transform.position;

    }


    // Update is called once per frame
    void Update() {
        if ( playing ) {
            UpdateGameTimerText();
        }
    }

    void UpdateGameTimerText() {
        if ( gameTimer.Running ) {
            gameTimerText.text = gameTimer.SecondsLeft.ToString("0.0") + " ";
        }
        else if ( startTimer.Running ) {
            gameTimerText.text = startTimer.SecondsLeft.ToString("0.0") + " ";
        }
        
    }

    private void OnDestroy() {

        startTimer.onTimerFinished -= StartGame;
        gameTimer.onTimerFinished -= EndGame;
    }
}
