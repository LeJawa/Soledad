using System.Collections;
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

    const float InitialRoundDurationInSeconds = 50;
    float MinRoundDurationInSeconds = 20;
    float MaxRoundDurationInSeconds = 90;
    float roundDurationTimeInSeconds = InitialRoundDurationInSeconds;
    float secondsToRemoveAfterPerfectRound = 5f;
    float secondsBeforeStartOfGame = 1f;

    // Set but not really used
    float bestPerfectRoundTime = InitialRoundDurationInSeconds;

    float chanceThatSoledadForgetsDirectRelationship = 0.2f;
    float RelationshipsLostToPersonsLeftFactor = 3f;
    float AddingRelationshipsLostToPersonsLeftFactorPerRoundPlayed = 0.1f;
    float RelationshipsLostToRelationshipsLeftFactor = 50f;
    float RelationshipsLostToSecondsLostFactor = 5f;

    int totalNumberOfRounds = 0;

    Timer startTimer;
    Timer roundTimer;

    [SerializeField]
    Text gameTimerText;

    [SerializeField]
    GameObject prefabCenterPerson;

    [SerializeField]
    GameObject passNameButton;
    [SerializeField]
    GameObject startButton;

    bool playing = false;

    bool gameEnded = false;

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

    [SerializeField]
    GameObject prefabEndScreen;

    int totalRelationshipsLost = 0;
    int lastRoundRelationshipsLost = 0;
    int InitialNumberOfRelationships = 240;
    int currentNumberOfRelationships = 240;


    public int PersonsLeftToFind { get => arrayOfNameTokens.Length - currentNameTokenIndex + 1 + numberOfNamesPassed; }
    public bool Playing { get => playing; }
    public int TotalRelationshipsLost { get => totalRelationshipsLost; }
    public int LastRoundRelationshipsLost { get => lastRoundRelationshipsLost; }
    public int CurrentNumberOfRelationships { get => currentNumberOfRelationships; }

    private void Awake() {
        GameController.Instance.InitializeSceneAnimator();
    }

    // Start is called before the first frame update
    void Start() {

        if (  GameController.Instance.CurrentScene != "GamePlay" ) {
            return;
        }

        startTimer = gameObject.AddComponent<Timer>();
        startTimer.Duration = secondsBeforeStartOfGame;
        startTimer.onTimerFinished += StartRound;

        roundTimer = gameObject.AddComponent<Timer>();
        roundTimer.Duration = roundDurationTimeInSeconds;
        roundTimer.onTimerFinished += EndRound;

        GameEvents.Instance.onCenterPersonClicked += HandleCenterPersonClicked;
        GameEvents.Instance.onStartButtonClicked += HandleStartButtonClicked;

        InitializeArrayOfNameTokens();
        lastTokenPosition = InitialTokenPosition;

        passNameButton.SetActive(false);
        startButton.SetActive(false);


        UpdateGameTimerText();
    }

    void RestartRound() {

        if ( GameObject.FindGameObjectsWithTag("CenterPerson").Length == 0 ) {
            Instantiate(prefabCenterPerson);
        }

        ClearTokens();
        ShuffleArrayOfNameTokens();
        StartStartTimer();

        GameController.Instance.SetSoledadAsCenterPerson();

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

        if ( GameController.Instance.Language == Language.ES ) {
            listOfPersonTokens.Remove(PersonName.carlos);
            listOfPersonTokens.Remove(PersonName.pilar);
        }
        else {
            listOfPersonTokens.Remove(PersonName.luisNieto);
            listOfPersonTokens.Remove(PersonName.concha);
        }


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
        totalNumberOfRounds++;
        GameController.Instance.SetSoledadAsCenterPerson();

        playing = true;
        roundTimer.Run();
        SpawnNewName();

        passNameButton.SetActive(true);
        startButton.SetActive(false);
    }

    void EndRound() {
        playing = false;
        Time.timeScale = 0;

        passNameButton.SetActive(false);

        if ( PersonsLeftToFind == 0 ) {
            HandlePerfectRound();
        }
        else {
            HandleRoundWithPersonsLeft();
            if ( roundDurationTimeInSeconds < MaxRoundDurationInSeconds ) {
                roundDurationTimeInSeconds += lastRoundRelationshipsLost / RelationshipsLostToSecondsLostFactor;
                roundTimer.Stop();
                roundTimer.Duration = roundDurationTimeInSeconds;
            }
        }

        if ( !gameEnded ) {
            Instantiate(prefabFinishScreen);

            GameController.Instance.SetMusicVolume(currentNumberOfRelationships / 1000f);
        }
    }

    void HandlePerfectRound() {
        float roundTime = roundDurationTimeInSeconds - roundTimer.SecondsLeft;
        if ( roundTime < bestPerfectRoundTime ) {
            bestPerfectRoundTime = roundTime;
        }

        if ( roundDurationTimeInSeconds > MinRoundDurationInSeconds ) {
            if ( roundTimer.SecondsLeft < secondsToRemoveAfterPerfectRound ) {
                roundDurationTimeInSeconds -= secondsToRemoveAfterPerfectRound;
            }
            else {
                roundDurationTimeInSeconds -= roundTimer.SecondsLeft;
            }
            roundTimer.Stop();
            roundTimer.Duration = roundDurationTimeInSeconds;

        }
    }

    void HandleRoundWithPersonsLeft() {
        lastRoundRelationshipsLost = 0;
        System.Random rng = new System.Random();
        int index;
        Person currentPerson;

        float relationshipsLostThisRound = PersonsLeftToFind * 
            ( RelationshipsLostToPersonsLeftFactor + AddingRelationshipsLostToPersonsLeftFactorPerRoundPlayed * totalNumberOfRounds) *
            currentNumberOfRelationships / RelationshipsLostToRelationshipsLeftFactor;

        for ( int i = 0; i < relationshipsLostThisRound; i++ ) {

            currentPerson = GameController.Instance.Soledad;

            if ( currentNumberOfRelationships > 100 || rng.NextDouble() > chanceThatSoledadForgetsDirectRelationship ) {
                int tries = 0;
                do {
                    index = rng.Next(arrayOfNameTokens.Length);
                    currentPerson = GameController.Instance.GetPersonFromName(arrayOfNameTokens[index]);
                    tries++;
                }
                while ( currentPerson.Relationships.Count == 0 && tries < 20 );
            }
            if ( currentPerson.Relationships.Count == 0 ) {
                continue;
            }

            index = rng.Next(currentPerson.Relationships.Count);
            Relationship currentRelationship = Enumerable.ToList(currentPerson.Relationships)[index];
            List<Person> personList = currentPerson.GetPersonsFromRelationship(currentRelationship);
            index = rng.Next(personList.Count);
            currentPerson.RemoveRelationship(currentRelationship, personList[index]);

            lastRoundRelationshipsLost++;
            totalRelationshipsLost++;
            currentNumberOfRelationships--;
        }

        if ( GameController.Instance.Soledad.Relationships.Count == 0 ) {
            EndGame();
        }


    }

    void HandleCenterPersonClicked(PersonName name) {
        if ( playing && personToFind == name) {
            GameEvents.Instance.TriggerNameTokenFound();
            SpawnNewName();
        }

    }

    void EndGame() {
        gameEnded = true;
        Time.timeScale = 1;
        Instantiate(prefabEndScreen);

        GameController.Instance.FadeOutMusic();
    }

    void SpawnNewName() {
        if ( currentNameTokenIndex >= arrayOfNameTokens.Length ) {
            currentNameTokenIndex++;
            EndRound();
            return;
        }

        personToFind = arrayOfNameTokens[currentNameTokenIndex++];

        GameObject nameToken = Instantiate(prefabNameToken);
        SpriteRenderer spriteRenderer = nameToken.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SpriteManager.Instance.GetSpriteFromPerson(personToFind);
        spriteRenderer.color = SpriteManager.Instance.GetSpriteColorFromPersonName(personToFind);
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
        else {
            gameTimerText.text = roundDurationTimeInSeconds.ToString("0.0") + " ";
        }
        
    }

    public void HandlePassTokenName() {
        GameController.Instance.SetSoledadAsCenterPerson();
        numberOfNamesPassed++;
        SpawnNewName();
    }

    public void HandleTryAgain() {
        RestartRound();
    }

    public void HandleStartButtonClicked() {
        StartRound();
    }

    public void ActivateStartButton() {
        startButton.SetActive(true);
    }

    public void ActivateGameTimerText() {
        gameTimerText.gameObject.SetActive(true);
    }


    private void OnDestroy() {
        if ( GameController.Instance.CurrentScene == "GamePlay" ) {
            return;
        }

        startTimer.onTimerFinished -= StartRound;
        roundTimer.onTimerFinished -= EndRound;


        GameEvents.Instance.onCenterPersonClicked -= HandleCenterPersonClicked;
        GameEvents.Instance.onStartButtonClicked -= HandleStartButtonClicked;
    }

    

}
