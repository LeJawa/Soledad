﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {


    #region SINGLETON PATTERN
    static RoundController current;
    public static RoundController Instance {
        get {
            if ( current == null ) {
                current = GameObject.FindObjectOfType<RoundController>();

                if ( current == null ) {
                    GameObject container = new GameObject("RoundController");
                    current = container.AddComponent<RoundController>();
                }
            }

            return current;
        }
    }
    #endregion

    float roundDurationTimeInSeconds = 30;
    float secondsToRemoveAfterPerfectRound = 10f;
    float secondsBeforeStartOfGame = 1f;

    float chanceToLoseOneRelationship = 0.5f;

    Timer startTimer;
    Timer roundTimer;

    [SerializeField]
    Text gameTimerText;

    [SerializeField]
    GameObject prefabCenterPerson;

    bool playing = true;

    PersonName personToFind;

    int currentNameTokenIndex = 0;
    PersonName[] arrayOfNameTokens;
    int numberOfNamesPassed = 0;

    Vector3 InitialTokenPosition = new Vector3(-6.5f, -5, 0);
    Vector3 lastTokenPosition;
    Vector3 tokenOffset = new Vector3(0.5f, 0, 0);
    int sortingOrderOfTokens = 0;

    [SerializeField]
    GameObject prefabNameToken;

    [SerializeField]
    GameObject prefabFinishScreen;

    public int PersonsLeftToFind { get => arrayOfNameTokens.Length - currentNameTokenIndex + numberOfNamesPassed; }


    // Start is called before the first frame update
    void Start() {
        startTimer = gameObject.AddComponent<Timer>();
        startTimer.Duration = secondsBeforeStartOfGame;
        startTimer.onTimerFinished += StartRound;

        roundTimer = gameObject.AddComponent<Timer>();
        roundTimer.Duration = roundDurationTimeInSeconds;
        roundTimer.onTimerFinished += EndRound;

        GameEvents.current.onCenterPersonClicked += HandleCenterPersonClicked;
        GameEvents.current.onTutorialEnd += StartStartTimer;

        InitializeArrayOfNameTokens();
        lastTokenPosition = InitialTokenPosition;
    }

    void RestartRound() {

        if ( GameObject.FindGameObjectsWithTag("CenterPerson").Length == 0 ) {
            Instantiate(prefabCenterPerson);
        }

        ClearTokens();
        ShuffleArrayOfNameTokens();
        StartStartTimer();

        GameController.current.SetSoledadAsCenterPerson();


        Time.timeScale = 1;
    }

    private void ClearTokens() {
        foreach ( GameObject gameObject in GameObject.FindGameObjectsWithTag("Token") ) {
            Destroy(gameObject);
        }
        lastTokenPosition = InitialTokenPosition;
        currentNameTokenIndex = 0;
        numberOfNamesPassed = 0;
    }

    private void InitializeArrayOfNameTokens() {
        List<PersonName> listOfPersonTokens = new List<PersonName>();
        foreach ( PersonName name in (PersonName[]) PersonName.GetValues(typeof(PersonName)) ) {
            listOfPersonTokens.Add(name);
        }
        listOfPersonTokens.Remove(PersonName.soledad);

        arrayOfNameTokens = new PersonName[listOfPersonTokens.Count];
        for ( int i = 0; i < listOfPersonTokens.Count; i++ ) {
            arrayOfNameTokens[i] = listOfPersonTokens[i];
        }
        ShuffleArrayOfNameTokens();

    }

    private void ShuffleArrayOfNameTokens() {
        var rng = new System.Random();
        rng.Shuffle(arrayOfNameTokens);
    }

    void StartStartTimer() {
        startTimer.Run();

    }

    void StartRound() {
        playing = true;
        roundTimer.Run();
        SpawnNewName();
    }

    void EndRound() {
        playing = false;
        Time.timeScale = 0;

        Instantiate(prefabFinishScreen);

        if ( PersonsLeftToFind == 0 ) {
            HandlePerfectRound();
        }
        else {
            HandleRoundWithPersonsLeft();
        }
    }

    void HandlePerfectRound() {
        roundDurationTimeInSeconds -= secondsToRemoveAfterPerfectRound;
        roundTimer.Stop();
        roundTimer.Duration = roundDurationTimeInSeconds;
    }

    void HandleRoundWithPersonsLeft() {
        System.Random rng = new System.Random();
        int index;
        for ( int i = 0; i < PersonsLeftToFind; i++ ) {
            bool relationshipLost = false;
            Person currentPerson = GameController.current.Soledad;
            while ( !relationshipLost ) {
                if ( currentPerson.Relationships.Count == 0 ) {
                    if ( currentPerson == GameController.current.Soledad ) {
                        EndGame();
                        return;
                    }
                    else {
                        index = rng.Next(arrayOfNameTokens.Length);
                        currentPerson = GameController.current.GetPersonFromName(arrayOfNameTokens[index]);
                        continue;
                    }
                }

                index = rng.Next(currentPerson.Relationships.Count);
                Relationship currentRelationship = Enumerable.ToList(currentPerson.Relationships)[index];

                if ( rng.NextDouble() < chanceToLoseOneRelationship ) {
                    List<Person> personList = currentPerson.GetPersonsFromRelationship(currentRelationship);
                    index = rng.Next(personList.Count);
                    currentPerson.RemoveRelationship(currentRelationship, personList[index]);
                    relationshipLost = true;

                    if ( currentPerson.Relationships.Count == 0 && currentPerson == GameController.current.Soledad ) {
                        EndGame();
                        return;
                    }
                }
                else {
                    index = rng.Next(arrayOfNameTokens.Length);
                    currentPerson = GameController.current.GetPersonFromName(arrayOfNameTokens[index]);
                }
            }
        }


    }

    void HandleCenterPersonClicked(PersonName name) {
        if ( personToFind == name) {
            GameEvents.current.TriggerNameTokenFound();
            SpawnNewName();
        }

    }

    void EndGame() {
        Debug.Log("End game");
    }

    void SpawnNewName() {
        if ( currentNameTokenIndex >= arrayOfNameTokens.Length ) {
            EndRound();
            return;
        }

        personToFind = arrayOfNameTokens[currentNameTokenIndex++];

        GameObject nameToken = Instantiate(prefabNameToken);
        SpriteRenderer spriteRenderer = nameToken.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SpriteManager.current.GetSpriteFromPerson(personToFind);
        spriteRenderer.color = SpriteManager.current.GetSpriteColorFromPersonName(personToFind);
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
        if ( roundTimer.Running ) {
            gameTimerText.text = roundTimer.SecondsLeft.ToString("0.0") + " ";
        }
        else if ( startTimer.Running ) {
            gameTimerText.text = startTimer.SecondsLeft.ToString("0.0") + " ";
        }
        
    }

    public void HandlePassTokenName() {
        numberOfNamesPassed++;
        currentNameTokenIndex++;
        SpawnNewName();
    }

    public void HandleTryAgain() {
        RestartRound();
    }


    private void OnDestroy() {

        startTimer.onTimerFinished -= StartRound;
        roundTimer.onTimerFinished -= EndRound;
    }

    

}