using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipObject : MonoBehaviour {

    Relationship relationship;
    Person person;

    public Relationship Relationship { get => relationship; }
    public Person Person { get => person; }



    // Start is called before the first frame update
    void Start() {

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
        print(person.Name);
    }

}
