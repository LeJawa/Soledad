using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soledad : MonoBehaviour {

    public static Soledad current;

    Person soledad;

    [SerializeField]
    public CenterPerson centerPerson;

    public Person Abuela { get => soledad; }

    private void Awake() {

        if ( current != null ) {
            Destroy(gameObject);
        }
        else {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
        

        InitializePersons();
    }

    private void Start() {

    }

    private void InitializePersons() {
        soledad = new Person(PersonName.soledad, Sex.Female);

        Person maria = new Person(PersonName.maria, Sex.Female); 
        soledad.AddRelationship(Relationship.Mother, maria);
        Person francisco = new Person(PersonName.francisco, Sex.Male);
        soledad.AddRelationship(Relationship.Father, francisco);
        maria.AddRelationship(Relationship.Husband, francisco);

        Person pilar = new Person(PersonName.pilar, Sex.Female);
        soledad.AddRelationship(Relationship.Sister, pilar);
        pilar.AddRelationship(Relationship.Mother, maria);
        pilar.AddRelationship(Relationship.Father, francisco);

        Person luisAbuelo = new Person(PersonName.luis, Sex.Male);
        soledad.AddRelationship(Relationship.Husband, luisAbuelo);
        luisAbuelo.AddRelationship(Relationship.SisterInLaw, pilar);
        luisAbuelo.AddRelationship(Relationship.MotherInLaw, maria);
        luisAbuelo.AddRelationship(Relationship.FatherInLaw, francisco);

        Person luisfrancisco = new Person(PersonName.luisfrancisco, Sex.Male);
        soledad.AddRelationship(Relationship.Son, luisfrancisco);
        luisfrancisco.AddRelationship(Relationship.Father, luisAbuelo);
        luisfrancisco.AddRelationship(Relationship.Grandmother, maria);
        luisfrancisco.AddRelationship(Relationship.Grandfather, francisco);
        luisfrancisco.AddRelationship(Relationship.Aunt, pilar);
        Person jorge = new Person(PersonName.jorge, Sex.Male);
        soledad.AddRelationship(Relationship.Son, jorge);
        jorge.AddRelationship(Relationship.Father, luisAbuelo);
        jorge.AddRelationship(Relationship.Grandmother, maria);
        jorge.AddRelationship(Relationship.Grandfather, francisco);
        jorge.AddRelationship(Relationship.Aunt, pilar);
        jorge.AddRelationship(Relationship.Brother, luisfrancisco);
        Person javier = new Person(PersonName.javier, Sex.Male);
        soledad.AddRelationship(Relationship.Son, javier);
        javier.AddRelationship(Relationship.Father, luisAbuelo);
        javier.AddRelationship(Relationship.Grandmother, maria);
        javier.AddRelationship(Relationship.Grandfather, francisco);
        javier.AddRelationship(Relationship.Aunt, pilar);
        javier.AddRelationship(Relationship.Brother, luisfrancisco);
        javier.AddRelationship(Relationship.Brother, jorge);


        Person socorro = new Person(PersonName.socorro, Sex.Female);
        soledad.AddRelationship(Relationship.DaughterInLaw, socorro);
        socorro.AddRelationship(Relationship.Husband, luisfrancisco);
        socorro.AddRelationship(Relationship.BrotherInLaw, jorge);
        socorro.AddRelationship(Relationship.BrotherInLaw, javier);
        socorro.AddRelationship(Relationship.FatherInLaw, luisAbuelo);
        Person concha = new Person(PersonName.concha, Sex.Female);
        soledad.AddRelationship(Relationship.DaughterInLaw, concha);
        concha.AddRelationship(Relationship.Husband, jorge);
        concha.AddRelationship(Relationship.BrotherInLaw, luisfrancisco);
        concha.AddRelationship(Relationship.BrotherInLaw, javier);
        concha.AddRelationship(Relationship.FatherInLaw, luisAbuelo);
        Person margarita = new Person(PersonName.margarita, Sex.Female);
        soledad.AddRelationship(Relationship.DaughterInLaw, margarita);
        margarita.AddRelationship(Relationship.Husband, javier);
        margarita.AddRelationship(Relationship.BrotherInLaw, jorge);
        margarita.AddRelationship(Relationship.BrotherInLaw, luisfrancisco);
        margarita.AddRelationship(Relationship.FatherInLaw, luisAbuelo);

        Person almudena = new Person(PersonName.almudena, Sex.Female);
        soledad.AddRelationship(Relationship.Grandchild, almudena);
        almudena.AddRelationship(Relationship.Father, luisfrancisco);
        almudena.AddRelationship(Relationship.Mother, socorro);
        almudena.AddRelationship(Relationship.Uncle, jorge);
        almudena.AddRelationship(Relationship.Aunt, concha);
        almudena.AddRelationship(Relationship.Uncle, javier);
        almudena.AddRelationship(Relationship.Aunt, margarita);
        almudena.AddRelationship(Relationship.Grandfather, luisAbuelo);
        Person javi = new Person(PersonName.javier, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild, javi);
        javi.AddRelationship(Relationship.Father, luisfrancisco);
        javi.AddRelationship(Relationship.Mother, socorro);
        javi.AddRelationship(Relationship.Uncle, jorge);
        javi.AddRelationship(Relationship.Aunt, concha);
        javi.AddRelationship(Relationship.Uncle, javier);
        javi.AddRelationship(Relationship.Aunt, margarita);
        javi.AddRelationship(Relationship.Grandfather, luisAbuelo);
        javi.AddRelationship(Relationship.Sister, almudena);
        Person david = new Person(PersonName.david, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild, david);
        david.AddRelationship(Relationship.Father, jorge);
        david.AddRelationship(Relationship.Mother, concha);
        david.AddRelationship(Relationship.Uncle, luisfrancisco);
        david.AddRelationship(Relationship.Aunt, socorro);
        david.AddRelationship(Relationship.Uncle, javier);
        david.AddRelationship(Relationship.Aunt, margarita);
        david.AddRelationship(Relationship.Grandfather, luisAbuelo);
        david.AddRelationship(Relationship.Cousin, almudena);
        david.AddRelationship(Relationship.Cousin, javi);
        Person jaime = new Person(PersonName.jaime, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild, jaime);
        jaime.AddRelationship(Relationship.Father, jorge);
        jaime.AddRelationship(Relationship.Mother, concha);
        jaime.AddRelationship(Relationship.Uncle, luisfrancisco);
        jaime.AddRelationship(Relationship.Aunt, socorro);
        jaime.AddRelationship(Relationship.Uncle, javier);
        jaime.AddRelationship(Relationship.Aunt, margarita);
        jaime.AddRelationship(Relationship.Grandfather, luisAbuelo);
        jaime.AddRelationship(Relationship.Cousin, almudena);
        jaime.AddRelationship(Relationship.Cousin, javi);
        jaime.AddRelationship(Relationship.Brother, david);
        Person ana= new Person(PersonName.ana, Sex.Female);
        soledad.AddRelationship(Relationship.Grandchild, ana);
        ana.AddRelationship(Relationship.Father, jorge);
        ana.AddRelationship(Relationship.Mother, concha);
        ana.AddRelationship(Relationship.Uncle, luisfrancisco);
        ana.AddRelationship(Relationship.Aunt, socorro);
        ana.AddRelationship(Relationship.Uncle, javier);
        ana.AddRelationship(Relationship.Aunt, margarita);
        ana.AddRelationship(Relationship.Grandfather, luisAbuelo);
        ana.AddRelationship(Relationship.Cousin, almudena);
        ana.AddRelationship(Relationship.Cousin, javi);
        ana.AddRelationship(Relationship.Brother, david);
        ana.AddRelationship(Relationship.Brother, jaime);
        Person luisNieto = new Person(PersonName.luis, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild, luisNieto);
        luisNieto.AddRelationship(Relationship.Father, javier);
        luisNieto.AddRelationship(Relationship.Mother, margarita);
        luisNieto.AddRelationship(Relationship.Uncle, luisfrancisco);
        luisNieto.AddRelationship(Relationship.Aunt, socorro);
        luisNieto.AddRelationship(Relationship.Uncle, jorge);
        luisNieto.AddRelationship(Relationship.Aunt, concha);
        luisNieto.AddRelationship(Relationship.Grandfather, luisAbuelo);
        luisNieto.AddRelationship(Relationship.Cousin, almudena);
        luisNieto.AddRelationship(Relationship.Cousin, javi);
        luisNieto.AddRelationship(Relationship.Cousin, david);
        luisNieto.AddRelationship(Relationship.Cousin, jaime);
        luisNieto.AddRelationship(Relationship.Cousin, ana);
        Person alberto = new Person(PersonName.alberto, Sex.Male);
        soledad.AddRelationship(Relationship.Grandchild, alberto);
        alberto.AddRelationship(Relationship.Father, javier);
        alberto.AddRelationship(Relationship.Mother, margarita);
        alberto.AddRelationship(Relationship.Uncle, luisfrancisco);
        alberto.AddRelationship(Relationship.Aunt, socorro);
        alberto.AddRelationship(Relationship.Uncle, jorge);
        alberto.AddRelationship(Relationship.Aunt, concha);
        alberto.AddRelationship(Relationship.Grandfather, luisAbuelo);
        alberto.AddRelationship(Relationship.Cousin, almudena);
        alberto.AddRelationship(Relationship.Cousin, javi);
        alberto.AddRelationship(Relationship.Cousin, david);
        alberto.AddRelationship(Relationship.Cousin, jaime);
        alberto.AddRelationship(Relationship.Cousin, ana);
        alberto.AddRelationship(Relationship.Brother, luisNieto);
    }

    

    private void Update() {

        if ( Input.GetMouseButtonDown(0) ) {
            GameEvents.current.TriggerMouseClicked();

        }

    }

}
