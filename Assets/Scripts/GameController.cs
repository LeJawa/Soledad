﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController current;

    Person soledad;

    Person maria;
    Person francisco;
    Person luisAbuelo;

    Person luisfrancisco;
    Person jorge;
    Person javier;

    Person socorro;
    Person concha;
    Person margarita;

    Person almudena;
    Person javi;
    Person david;
    Person jaime;
    Person ana;
    Person luisNieto;
    Person alberto;

    [SerializeField]
    GameObject prefabCursor;

#if UNITY_ANDROID || UNITY_IOS
    GameObject currentCursor;
    bool touchAlreadyRegistered = false;
#endif
    public CenterPerson centerPersonObject;

    [SerializeField]
    AudioSource musicSource;

    [SerializeField]
    Animator animationAnim;

    string currentScene = "MainMenu";


    public Person Soledad { get => soledad; }

    private void Awake() {

        if ( current != null ) {
            Destroy(gameObject);
        }
        else {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {

#if UNITY_EDITOR || UNITY_WEBGL || UNITY_STANDALONE
        DontDestroyOnLoad(Instantiate(prefabCursor));
#endif

    }

    private void InitializePersons() {
        soledad = new Person(PersonName.soledad, Sex.Female);

        maria = new Person(PersonName.maria, Sex.Female);
        soledad.AddRelationship(Relationship.Mother, maria);
        francisco = new Person(PersonName.francisco, Sex.Male);
        soledad.AddRelationship(Relationship.Father, francisco);
        maria.AddRelationship(Relationship.Husband, francisco);

        luisAbuelo = new Person(PersonName.luis, Sex.Male);
        soledad.AddRelationship(Relationship.Husband, luisAbuelo);
        luisAbuelo.AddRelationship(Relationship.MotherInLaw, maria);
        luisAbuelo.AddRelationship(Relationship.FatherInLaw, francisco);

        luisfrancisco = new Person(PersonName.luisfrancisco, Sex.Male);
        soledad.AddRelationship(Relationship.Son, luisfrancisco);
        luisfrancisco.AddRelationship(Relationship.Father, luisAbuelo);
        luisfrancisco.AddRelationship(Relationship.Grandmother, maria);
        luisfrancisco.AddRelationship(Relationship.Grandfather, francisco);
        jorge = new Person(PersonName.jorge, Sex.Male);
        soledad.AddRelationship(Relationship.Son, jorge);
        jorge.AddRelationship(Relationship.Father, luisAbuelo);
        jorge.AddRelationship(Relationship.Grandmother, maria);
        jorge.AddRelationship(Relationship.Grandfather, francisco);
        jorge.AddRelationship(Relationship.Brother, luisfrancisco);
        javier = new Person(PersonName.javier, Sex.Male);
        soledad.AddRelationship(Relationship.Son, javier);
        javier.AddRelationship(Relationship.Father, luisAbuelo);
        javier.AddRelationship(Relationship.Grandmother, maria);
        javier.AddRelationship(Relationship.Grandfather, francisco);
        javier.AddRelationship(Relationship.Brother, luisfrancisco);
        javier.AddRelationship(Relationship.Brother, jorge);


        socorro = new Person(PersonName.socorro, Sex.Female);
        soledad.AddRelationship(Relationship.DaughterInLaw, socorro);
        socorro.AddRelationship(Relationship.Husband, luisfrancisco);
        socorro.AddRelationship(Relationship.BrotherInLaw, jorge);
        socorro.AddRelationship(Relationship.BrotherInLaw, javier);
        socorro.AddRelationship(Relationship.FatherInLaw, luisAbuelo);
        concha = new Person(PersonName.concha, Sex.Female);
        soledad.AddRelationship(Relationship.DaughterInLaw, concha);
        concha.AddRelationship(Relationship.Husband, jorge);
        concha.AddRelationship(Relationship.BrotherInLaw, luisfrancisco);
        concha.AddRelationship(Relationship.BrotherInLaw, javier);
        concha.AddRelationship(Relationship.FatherInLaw, luisAbuelo);
        margarita = new Person(PersonName.margarita, Sex.Female);
        soledad.AddRelationship(Relationship.DaughterInLaw, margarita);
        margarita.AddRelationship(Relationship.Husband, javier);
        margarita.AddRelationship(Relationship.BrotherInLaw, jorge);
        margarita.AddRelationship(Relationship.BrotherInLaw, luisfrancisco);
        margarita.AddRelationship(Relationship.FatherInLaw, luisAbuelo);

        almudena = new Person(PersonName.almudena, Sex.Female);
        soledad.AddRelationship(Relationship.Grandchild_f, almudena);
        almudena.AddRelationship(Relationship.Father, luisfrancisco);
        almudena.AddRelationship(Relationship.Mother, socorro);
        almudena.AddRelationship(Relationship.Uncle, jorge);
        almudena.AddRelationship(Relationship.Aunt, concha);
        almudena.AddRelationship(Relationship.Uncle, javier);
        almudena.AddRelationship(Relationship.Aunt, margarita);
        almudena.AddRelationship(Relationship.Grandfather, luisAbuelo);
        javi = new Person(PersonName.javi, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild_m, javi);
        javi.AddRelationship(Relationship.Father, luisfrancisco);
        javi.AddRelationship(Relationship.Mother, socorro);
        javi.AddRelationship(Relationship.Uncle, jorge);
        javi.AddRelationship(Relationship.Aunt, concha);
        javi.AddRelationship(Relationship.Uncle, javier);
        javi.AddRelationship(Relationship.Aunt, margarita);
        javi.AddRelationship(Relationship.Grandfather, luisAbuelo);
        javi.AddRelationship(Relationship.Sister, almudena);
        david = new Person(PersonName.david, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild_m, david);
        david.AddRelationship(Relationship.Father, jorge);
        david.AddRelationship(Relationship.Mother, concha);
        david.AddRelationship(Relationship.Uncle, luisfrancisco);
        david.AddRelationship(Relationship.Aunt, socorro);
        david.AddRelationship(Relationship.Uncle, javier);
        david.AddRelationship(Relationship.Aunt, margarita);
        david.AddRelationship(Relationship.Grandfather, luisAbuelo);
        david.AddRelationship(Relationship.Cousin_f, almudena);
        david.AddRelationship(Relationship.Cousin_m, javi);
        jaime = new Person(PersonName.jaime, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild_m, jaime);
        jaime.AddRelationship(Relationship.Father, jorge);
        jaime.AddRelationship(Relationship.Mother, concha);
        jaime.AddRelationship(Relationship.Uncle, luisfrancisco);
        jaime.AddRelationship(Relationship.Aunt, socorro);
        jaime.AddRelationship(Relationship.Uncle, javier);
        jaime.AddRelationship(Relationship.Aunt, margarita);
        jaime.AddRelationship(Relationship.Grandfather, luisAbuelo);
        jaime.AddRelationship(Relationship.Cousin_f, almudena);
        jaime.AddRelationship(Relationship.Cousin_m, javi);
        jaime.AddRelationship(Relationship.Brother, david);
        ana = new Person(PersonName.ana, Sex.Female);
        soledad.AddRelationship(Relationship.Grandchild_f, ana);
        ana.AddRelationship(Relationship.Father, jorge);
        ana.AddRelationship(Relationship.Mother, concha);
        ana.AddRelationship(Relationship.Uncle, luisfrancisco);
        ana.AddRelationship(Relationship.Aunt, socorro);
        ana.AddRelationship(Relationship.Uncle, javier);
        ana.AddRelationship(Relationship.Aunt, margarita);
        ana.AddRelationship(Relationship.Grandfather, luisAbuelo);
        ana.AddRelationship(Relationship.Cousin_f, almudena);
        ana.AddRelationship(Relationship.Cousin_m, javi);
        ana.AddRelationship(Relationship.Brother, david);
        ana.AddRelationship(Relationship.Brother, jaime);
        luisNieto = new Person(PersonName.luisNieto, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild_m, luisNieto);
        luisNieto.AddRelationship(Relationship.Father, javier);
        luisNieto.AddRelationship(Relationship.Mother, margarita);
        luisNieto.AddRelationship(Relationship.Uncle, luisfrancisco);
        luisNieto.AddRelationship(Relationship.Aunt, socorro);
        luisNieto.AddRelationship(Relationship.Uncle, jorge);
        luisNieto.AddRelationship(Relationship.Aunt, concha);
        luisNieto.AddRelationship(Relationship.Grandfather, luisAbuelo);
        luisNieto.AddRelationship(Relationship.Cousin_f, almudena);
        luisNieto.AddRelationship(Relationship.Cousin_m, javi);
        luisNieto.AddRelationship(Relationship.Cousin_m, david);
        luisNieto.AddRelationship(Relationship.Cousin_m, jaime);
        luisNieto.AddRelationship(Relationship.Cousin_f, ana);
        alberto = new Person(PersonName.alberto, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild_m, alberto);
        alberto.AddRelationship(Relationship.Father, javier);
        alberto.AddRelationship(Relationship.Mother, margarita);
        alberto.AddRelationship(Relationship.Uncle, luisfrancisco);
        alberto.AddRelationship(Relationship.Aunt, socorro);
        alberto.AddRelationship(Relationship.Uncle, jorge);
        alberto.AddRelationship(Relationship.Aunt, concha);
        alberto.AddRelationship(Relationship.Grandfather, luisAbuelo);
        alberto.AddRelationship(Relationship.Cousin_f, almudena);
        alberto.AddRelationship(Relationship.Cousin_m, javi);
        alberto.AddRelationship(Relationship.Cousin_m, david);
        alberto.AddRelationship(Relationship.Cousin_m, jaime);
        alberto.AddRelationship(Relationship.Cousin_f, ana);
        alberto.AddRelationship(Relationship.Brother, luisNieto);
    }

    public void StartNewGame() {
        SetMusicVolume(0.240f);
        InitializePersons();
        LoadGamePlay();
    }

    void LoadGamePlay() {
        StartCoroutine(LoadSceneCoroutine("GamePlay"));
    }

    public void LoadDedicatoria() {
        StartCoroutine(LoadSceneCoroutine("Dedicatoria"));
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadSceneCoroutine("MainMenu"));
    }

    IEnumerator LoadSceneCoroutine(string scene) {
        Time.timeScale = 1;
        if ( animationAnim == null ) {
            InitializeSceneAnimator();
        }

        animationAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(scene);
        currentScene = scene;


        if ( scene == "MainMenu" ) {
            musicSource.volume = 0.24f;
            if ( !musicSource.isPlaying ) {
                musicSource.Play();
            }
        }
    }

    public void InitializeSceneAnimator() {
        animationAnim = GameObject.FindGameObjectWithTag("IOAnimation").GetComponent<Animator>();
    }

    public void FadeOutMusic() {
        StartCoroutine(AudioFadeOut.FadeOut(musicSource, 1.5f));
    }


    private void Update() {

#if UNITY_EDITOR || UNITY_WEBGL || UNITY_STANDALONE
        if ( Input.GetMouseButtonDown(0) ) {
            GameEvents.current.TriggerMouseClicked();
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        if ( Input.touchCount > 0 ) {
            Touch touch = Input.GetTouch(0);

            if ( touch.phase == TouchPhase.Began ) {
                currentCursor = Instantiate(prefabCursor, Camera.main.ScreenToWorldPoint(touch.position), Quaternion.identity);
            }
            if ( !touchAlreadyRegistered && touch.phase == TouchPhase.Stationary ) {
                GameEvents.current.TriggerMouseClicked();
                touchAlreadyRegistered = true;
            }
            if ( touch.phase == TouchPhase.Ended ) {
                Destroy(currentCursor);
                touchAlreadyRegistered = false;
            }
        }
#endif



    }

    public void SetSoledadAsCenterPerson() {
        centerPersonObject.SetPerson(Soledad);
    }

    public void SetCenterPerson(Person person) {
        centerPersonObject.SetPerson(person);
    }

    public void SetCenterPersonObject(CenterPerson centerPerson) {
        centerPersonObject = centerPerson;
    }

    public Person GetPersonFromName(PersonName name) {
        switch ( name ) {
            case PersonName.soledad:
                return soledad;
            case PersonName.javier:
                return javier;
            case PersonName.jorge:
                return jorge;
            case PersonName.luisfrancisco:
                return luisfrancisco;
            case PersonName.socorro:
                return socorro;
            case PersonName.margarita:
                return margarita;
            case PersonName.concha:
                return concha;
            case PersonName.almudena:
                return almudena;
            case PersonName.javi:
                return javi;
            case PersonName.david:
                return david;
            case PersonName.jaime:
                return jaime;
            case PersonName.ana:
                return ana;
            case PersonName.luisNieto:
                return luisNieto;
            case PersonName.alberto:
                return alberto;
            case PersonName.luis:
                return luisAbuelo;
            case PersonName.francisco:
                return francisco;
            case PersonName.maria:
                return maria;
            default:
                return null;
        }


    }

    public void SetMusicVolume(float volume) {
        musicSource.volume = volume;
    }

}
