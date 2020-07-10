using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Person {

    string name;

    Dictionary<Relationship, Person> dictionaryOfRelationships;

    public Dictionary<Relationship, Person>.KeyCollection Relationships { get => dictionaryOfRelationships.Keys; }

    public Person(string name) {
        this.name = name;

        dictionaryOfRelationships = new Dictionary<Relationship, Person>();
    }

    public void AddRelationship(Relationship relationship, Person person) {
        dictionaryOfRelationships.Add(relationship, person);
    }

    public Person GetPersonFromRelationship(Relationship relationship) {

        if ( Relationships.Contains(relationship) ) {
            return dictionaryOfRelationships[relationship];
        }
        return null;
    }

    public void RemoveRelationship(Relationship relationship) {
        if ( Relationships.Contains(relationship) ) {
            dictionaryOfRelationships.Remove(relationship);
        }
    }

    public override string ToString() {
        return name;
    }




}
