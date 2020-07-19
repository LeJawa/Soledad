using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CenterPerson : MonoBehaviour {

    [SerializeField]
    GameObject prefabRelationship;

    Person person;
    Sprite personSprite;
    SpriteRenderer spriteRenderer;

    List<RelationshipObject> relationships;

    Vector3 highlightScale = new Vector3(1.1f, 1.1f, 1);
    bool isHighlighted = false;


    public PersonName Name { get => person.Name; }

    private void Start() {
        GameController.Instance.SetCenterPersonObject(this);

        person = GameController.Instance.Soledad;
        spriteRenderer = GetComponent<SpriteRenderer>();

        relationships = new List<RelationshipObject>();

        GameEvents.Instance.onMouseClicked += HandleMouseClicked;
        GameEvents.Instance.onTutorial1 += ShowRelationships;
        GameEvents.Instance.onNameTokenFound += ResetCenterPersonToSoledad;
        GameEvents.Instance.onResetEverything += Clear;

        SetCenterSprite();
    }

    void UpdateEverything() {

        SetCenterSprite();

        Clear();

        ShowRelationships();
    }

    void Clear() {
        relationships.Clear();
        foreach ( GameObject gameObject in GameObject.FindGameObjectsWithTag("Relationship") ) {
            Destroy(gameObject);
        }
    }

    void SetCenterSprite() {
        spriteRenderer.sprite = SpriteManager.Instance.GetSpriteFromPerson(person.Name);
        spriteRenderer.color = SpriteManager.Instance.GetSpriteColorFromPersonName(person.Name);
    }

    public void SetPerson(Person person) {
        if ( person == this.person ) {
            UpdateEverything();
            return;
        }

        this.person = person;
        UpdateEverything();

    }


    void ShowRelationships() {
        foreach ( Relationship relationship in person.Relationships ) {
            foreach ( Person person in person.GetPersonsFromRelationship(relationship) ) {
                CreateRelationshipObject(relationship, person);
            }
        }

        SetRelationshipObjectsPosition();
    }

    private void CreateRelationshipObject(Relationship relationship, Person person) {
        RelationshipObject relationshipObject = Instantiate(prefabRelationship).GetComponent<RelationshipObject>();
        relationshipObject.SetPersonAndRelationship(person, relationship);
        SetRelationshipObjectSprite(relationshipObject);

        relationships.Add(relationshipObject);
    }


    void SetRelationshipObjectsPosition() {
        int N = relationships.Count;
        int NumberOfRelationshipsPerCircle = 9;
        int numberOfCircles = N / NumberOfRelationshipsPerCircle + 1;

        for ( int j = 0; j < numberOfCircles; j++ ) {
            int relationshipsInThisCircle = NumberOfRelationshipsPerCircle;
            if ( N < (j+1) * NumberOfRelationshipsPerCircle ) {
                relationshipsInThisCircle = N % NumberOfRelationshipsPerCircle;
            }

            float angleBetweenRelationships = 2 * Mathf.PI / relationshipsInThisCircle;

            for ( int i = j*NumberOfRelationshipsPerCircle; i < j * NumberOfRelationshipsPerCircle + relationshipsInThisCircle; i++ ) {
                float angle = Mathf.PI / 2 + angleBetweenRelationships * i;
                relationships[i].transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * (2.5f + 1.5f*j) + transform.position;
            }
        }


    }

    void SetRelationshipObjectSprite(RelationshipObject relationshipObject) {

        if ( relationshipObject.Person.Name == PersonName.soledad ) {
            relationshipObject.GetComponent<SpriteRenderer>().sprite = SpriteManager.Instance.GetSoledadSpriteFromRelationship(relationshipObject.Relationship);
        }
        else {
            relationshipObject.GetComponent<SpriteRenderer>().sprite = SpriteManager.Instance.GetSpriteFromRelationship(relationshipObject.Relationship);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.CompareTag("Cursor") ) {

            transform.localScale = highlightScale;
            isHighlighted = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if ( collision.CompareTag("Cursor") ) {
            transform.localScale = Vector3.one;
            isHighlighted = false;
        }
    }

    void HandleMouseClicked() {
        if ( isHighlighted ) {
            GameEvents.Instance.TriggerCenterPersonClicked(person.Name);
        }

    }

    void ResetCenterPersonToSoledad() {
        SetPerson(GameController.Instance.Soledad);
    }

    private void OnDestroy() {
        GameEvents.Instance.onMouseClicked -= HandleMouseClicked;
        GameEvents.Instance.onTutorial1 -= ShowRelationships;
        GameEvents.Instance.onNameTokenFound -= ResetCenterPersonToSoledad;
        GameEvents.Instance.onResetEverything -= Clear;
    }

}
