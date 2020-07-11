using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum Sex {
    Male,
    Female
}


public class Person {

    PersonName name;
    Sex sex;


    Dictionary<Relationship, List<Person>> dictionaryOfRelationships;

    public Dictionary<Relationship, List<Person>>.KeyCollection Relationships { get => dictionaryOfRelationships.Keys; }
    public PersonName Name { get => name; }
    public Sex Sex { get => sex; }


    public Person(PersonName name, Sex sex) {
        this.name = name;
        this.sex = sex;

        dictionaryOfRelationships = new Dictionary<Relationship, List<Person>>();
    }

    public void AddRelationship(Relationship relationship, Person person) {
        if ( !dictionaryOfRelationships.ContainsKey(relationship) ) {
            dictionaryOfRelationships.Add(relationship, new List<Person>());
        }

        if ( dictionaryOfRelationships[relationship].Contains(person) ) {
            return;
        }

        dictionaryOfRelationships[relationship].Add(person);

        AddReciprocateRelationship(relationship, person);
    }

    public void AddReciprocateRelationship(Relationship relationship, Person person) {
        Relationship reciprocate = RelationshipExtensions.Reciprocate(relationship, this);
        if ( !person.dictionaryOfRelationships.ContainsKey(reciprocate) ) {
            person.dictionaryOfRelationships.Add(reciprocate, new List<Person>());
        }

        person.dictionaryOfRelationships[reciprocate].Add(this);
    }

    public List<Person> GetPersonsFromRelationship(Relationship relationship) {

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
        return name.ToString();
    }




}
