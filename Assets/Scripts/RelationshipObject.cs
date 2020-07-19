using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipObject : MonoBehaviour {

    Relationship relationship;
    Person person;

    public Relationship Relationship { get => relationship; }
    public Person Person { get => person; }

    Vector3 highlightScale = new Vector3(1.1f, 1.1f, 1);
    bool isHighlighted = false;


    // Start is called before the first frame update
    void Start() {

        GetComponent<SpriteRenderer>().color = SpriteManager.Instance.GetSpriteColorFromPersonName(person.Name);

        GameEvents.Instance.onMouseClicked += HandleMouseClicked;
    }

    public void SetPersonAndRelationship(Person person, Relationship relationship) {
        SetPerson(person);
        SetRelationship(relationship);
    }

    void SetPerson(Person person) {
        this.person = person;
    }

    void SetRelationship(Relationship relationship) {
        this.relationship = relationship;
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
            GameController.Instance.SetCenterPerson(person);
        }

    }

}
