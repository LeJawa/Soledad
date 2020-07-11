using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {

    public static RoundController current;

    float roundDurationTimeInSeconds = 5;
    float secondsToRemoveAfterPerfectRound = 10f;
    float secondsBeforeStartOfGame = 5f;

    float chanceToLoseOneRelationship = 0.5f;

    Timer startTimer;
    Timer gameTimer;

    [SerializeField]
    Text gameTimerText;

    bool playing = true;

    PersonName personToFind;

    int currentNameTokenIndex = 0;
    PersonName[] arrayOfNameTokens;

    Vector3 lastTokenPosition = new Vector3(-6.5f, -5, 0);
    Vector3 tokenOffset = new Vector3(0.5f, 0, 0);
    int sortingOrderOfTokens = 0;

    [SerializeField]
    GameObject prefabNameToken;

    [SerializeField]
    GameObject prefabFinishScreen;

    public int PersonsLeftToFind { get => arrayOfNameTokens.Length - currentNameTokenIndex; }

    private void Awake() {

        if ( current != null ) {
            Destroy(gameObject);
        }
        else {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        startTimer = gameObject.AddComponent<Timer>();
        startTimer.Duration = secondsBeforeStartOfGame;
        startTimer.onTimerFinished += StartGame;

        gameTimer = gameObject.AddComponent<Timer>();
        gameTimer.Duration = roundDurationTimeInSeconds;
        gameTimer.onTimerFinished += EndGame;

        GameEvents.current.onCenterPersonClicked += HandleCenterPersonClicked;
        GameEvents.current.onTutorialEnd += StartStartTimer;

        InitializeArrayOfNameTokens();

    }

    void RestartRound() {
        Time.timeScale = 1;
        ClearTokens();
        StartStartTimer();
    }

    private static void ClearTokens() {
        foreach ( GameObject gameObject in GameObject.FindGameObjectsWithTag("Token") ) {
            Destroy(gameObject);
        }
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

    void StartGame() {
        playing = true;
        gameTimer.Run();
        SpawnNewName();
    }

    void EndGame() {
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
        gameTimer.Stop();
        gameTimer.Duration = roundDurationTimeInSeconds;
    }

    void HandleRoundWithPersonsLeft() {
        for ( int i = 0; i < PersonsLeftToFind; i++ ) {
            bool relationshipLost = false;
            Person currentPerson = GameController.current.Soledad;
            System.Random rng = new System.Random();
            while ( !relationshipLost ) {
                Relationship currentRelationship = Enumerable.ToList(currentPerson.Relationships)[rng.Next(currentPerson.Relationships.Count)];

                if ( rng.NextDouble() < chanceToLoseOneRelationship ) {
                    List<Person> personList = currentPerson.GetPersonsFromRelationship(currentRelationship);
                    currentPerson.RemoveRelationship(currentRelationship, personList[rng.Next(personList.Count)]);
                    relationshipLost = true;
                }
                else {
                    List<Person> personList = currentPerson.GetPersonsFromRelationship(currentRelationship);
                    currentPerson = personList[rng.Next(personList.Count)];
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

    void SpawnNewName() {
        if ( currentNameTokenIndex == arrayOfNameTokens.Length ) {
            EndGame();
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
        if ( gameTimer.Running ) {
            gameTimerText.text = gameTimer.SecondsLeft.ToString("0.0") + " ";
        }
        else if ( startTimer.Running ) {
            gameTimerText.text = startTimer.SecondsLeft.ToString("0.0") + " ";
        }
        
    }

    public void HandlePassTokenName() {
        print("Pass name");
    }

    public void HandleTryAgain() {
        print("try again");
    }


    private void OnDestroy() {

        startTimer.onTimerFinished -= StartGame;
        gameTimer.onTimerFinished -= EndGame;
    }

    

}
