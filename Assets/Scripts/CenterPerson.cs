using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CenterPerson : MonoBehaviour {

    [SerializeField]
    GameObject prefabRelationship;

    Person person;

    List<RelationshipObject> relationships;


    public string Name { get => person.Name; }

    private void Start() {
        person = Soledad.current.Abuela;

        relationships = new List<RelationshipObject>();


        ShowRelationships();
    }

    void ShowRelationships() {
        foreach ( Relationship relationship in person.Relationships ) {
            foreach ( Person person in person.GetPersonsFromRelationship(relationship) ) {
                CreateRelationshipObject(relationship, person);
            }
        }




    }

    private void CreateRelationshipObject(Relationship relationship, Person person) {
        RelationshipObject relationshipObject = Instantiate(prefabRelationship).GetComponent<RelationshipObject>();
        relationshipObject.SetPersonAndRelationship(person, relationship);
        SetRelationshipObjectSprite(relationshipObject);

        relationships.Add(relationshipObject);
    }


    void SetRelationshipObjectPosition(RelationshipObject relationshipObject) {
        relationshipObject.transform.position = new Vector3(2, 2, 0);
    }

    void SetRelationshipObjectSprite(RelationshipObject relationshipObject) {
        relationshipObject.GetComponent<SpriteRenderer>().sprite = SpriteManager.current.GetSpriteFromRelationship(relationshipObject.Relationship);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        print(person.Name);
    }

}
