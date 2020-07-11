using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soledad : MonoBehaviour {

    public static Soledad current;

    Person soledad;

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
        soledad = new Person("Soledad", Sex.Female);

        Person mother = AddAnonymousRelationship(Relationship.Mother, Sex.Female);
        Person father = AddAnonymousRelationship(Relationship.Father, Sex.Male);
        mother.AddRelationship(Relationship.Husband, father);

        Person sister = AddAnonymousRelationship(Relationship.Sister, Sex.Female);
        sister.AddRelationship(Relationship.Mother, mother);
        sister.AddRelationship(Relationship.Father, father);

        Person husband = AddAnonymousRelationship(Relationship.Husband, Sex.Male);
        husband.AddRelationship(Relationship.SisterInLaw, sister);
        husband.AddRelationship(Relationship.MotherInLaw, mother);
        husband.AddRelationship(Relationship.FatherInLaw, father);

        Person son1 = AddAnonymousRelationship(Relationship.Son, Sex.Male);
        son1.AddRelationship(Relationship.Father, husband);
        son1.AddRelationship(Relationship.Grandmother, mother);
        son1.AddRelationship(Relationship.Grandfather, father);
        son1.AddRelationship(Relationship.Aunt, sister);
        Person son2 = AddAnonymousRelationship(Relationship.Son, Sex.Male);
        son2.AddRelationship(Relationship.Father, husband);
        son2.AddRelationship(Relationship.Grandmother, mother);
        son2.AddRelationship(Relationship.Grandfather, father);
        son2.AddRelationship(Relationship.Aunt, sister);
        son2.AddRelationship(Relationship.Brother, son1);
        Person son3 = AddAnonymousRelationship(Relationship.Son, Sex.Male);
        son3.AddRelationship(Relationship.Father, husband);
        son3.AddRelationship(Relationship.Grandmother, mother);
        son3.AddRelationship(Relationship.Grandfather, father);
        son3.AddRelationship(Relationship.Aunt, sister);
        son3.AddRelationship(Relationship.Brother, son1);
        son3.AddRelationship(Relationship.Brother, son2);


        Person daughterIL1 = AddAnonymousRelationship(Relationship.DaughterInLaw, Sex.Female);
        daughterIL1.AddRelationship(Relationship.Husband, son1);
        daughterIL1.AddRelationship(Relationship.BrotherInLaw, son2);
        daughterIL1.AddRelationship(Relationship.BrotherInLaw, son3);
        daughterIL1.AddRelationship(Relationship.FatherInLaw, husband);
        Person daughterIL2 = AddAnonymousRelationship(Relationship.DaughterInLaw, Sex.Female);
        daughterIL2.AddRelationship(Relationship.Husband, son2);
        daughterIL2.AddRelationship(Relationship.BrotherInLaw, son1);
        daughterIL2.AddRelationship(Relationship.BrotherInLaw, son3);
        daughterIL2.AddRelationship(Relationship.FatherInLaw, husband);
        Person daughterIL3 = AddAnonymousRelationship(Relationship.DaughterInLaw, Sex.Female);
        daughterIL3.AddRelationship(Relationship.Husband, son3);
        daughterIL3.AddRelationship(Relationship.BrotherInLaw, son2);
        daughterIL3.AddRelationship(Relationship.BrotherInLaw, son1);
        daughterIL3.AddRelationship(Relationship.FatherInLaw, husband);

        Person grandchild11 = AddAnonymousRelationship(Relationship.Grandchild, Sex.Female);
        grandchild11.AddRelationship(Relationship.Father, son1);
        grandchild11.AddRelationship(Relationship.Mother, daughterIL1);
        grandchild11.AddRelationship(Relationship.Uncle, son2);
        grandchild11.AddRelationship(Relationship.Aunt, daughterIL2);
        grandchild11.AddRelationship(Relationship.Uncle, son3);
        grandchild11.AddRelationship(Relationship.Aunt, daughterIL3);
        grandchild11.AddRelationship(Relationship.Grandfather, husband);
        Person grandchild12 = AddAnonymousRelationship(Relationship.Grandchild, Sex.Male);
        grandchild12.AddRelationship(Relationship.Father, son1);
        grandchild12.AddRelationship(Relationship.Mother, daughterIL1);
        grandchild12.AddRelationship(Relationship.Uncle, son2);
        grandchild12.AddRelationship(Relationship.Aunt, daughterIL2);
        grandchild12.AddRelationship(Relationship.Uncle, son3);
        grandchild12.AddRelationship(Relationship.Aunt, daughterIL3);
        grandchild12.AddRelationship(Relationship.Grandfather, husband);
        grandchild12.AddRelationship(Relationship.Sister, grandchild11);
        Person grandchild21 = AddAnonymousRelationship(Relationship.Grandchild, Sex.Male);
        grandchild21.AddRelationship(Relationship.Father, son2);
        grandchild21.AddRelationship(Relationship.Mother, daughterIL2);
        grandchild21.AddRelationship(Relationship.Uncle, son1);
        grandchild21.AddRelationship(Relationship.Aunt, daughterIL1);
        grandchild21.AddRelationship(Relationship.Uncle, son3);
        grandchild21.AddRelationship(Relationship.Aunt, daughterIL3);
        grandchild21.AddRelationship(Relationship.Grandfather, husband);
        grandchild21.AddRelationship(Relationship.Cousin, grandchild11);
        grandchild21.AddRelationship(Relationship.Cousin, grandchild12);
        Person grandchild22 = AddAnonymousRelationship(Relationship.Grandchild, Sex.Male);
        grandchild22.AddRelationship(Relationship.Father, son2);
        grandchild22.AddRelationship(Relationship.Mother, daughterIL2);
        grandchild22.AddRelationship(Relationship.Uncle, son1);
        grandchild22.AddRelationship(Relationship.Aunt, daughterIL1);
        grandchild22.AddRelationship(Relationship.Uncle, son3);
        grandchild22.AddRelationship(Relationship.Aunt, daughterIL3);
        grandchild22.AddRelationship(Relationship.Grandfather, husband);
        grandchild22.AddRelationship(Relationship.Cousin, grandchild11);
        grandchild22.AddRelationship(Relationship.Cousin, grandchild12);
        grandchild22.AddRelationship(Relationship.Brother, grandchild21);
        Person grandchild23 = AddAnonymousRelationship(Relationship.Grandchild, Sex.Female);
        grandchild23.AddRelationship(Relationship.Father, son2);
        grandchild23.AddRelationship(Relationship.Mother, daughterIL2);
        grandchild23.AddRelationship(Relationship.Uncle, son1);
        grandchild23.AddRelationship(Relationship.Aunt, daughterIL1);
        grandchild23.AddRelationship(Relationship.Uncle, son3);
        grandchild23.AddRelationship(Relationship.Aunt, daughterIL3);
        grandchild23.AddRelationship(Relationship.Grandfather, husband);
        grandchild23.AddRelationship(Relationship.Cousin, grandchild11);
        grandchild23.AddRelationship(Relationship.Cousin, grandchild12);
        grandchild23.AddRelationship(Relationship.Brother, grandchild21);
        grandchild23.AddRelationship(Relationship.Brother, grandchild22);
        Person grandchild31 = AddAnonymousRelationship(Relationship.Grandchild, Sex.Male);
        grandchild31.AddRelationship(Relationship.Father, son3);
        grandchild31.AddRelationship(Relationship.Mother, daughterIL3);
        grandchild31.AddRelationship(Relationship.Uncle, son1);
        grandchild31.AddRelationship(Relationship.Aunt, daughterIL1);
        grandchild31.AddRelationship(Relationship.Uncle, son2);
        grandchild31.AddRelationship(Relationship.Aunt, daughterIL2);
        grandchild31.AddRelationship(Relationship.Grandfather, husband);
        grandchild31.AddRelationship(Relationship.Cousin, grandchild11);
        grandchild31.AddRelationship(Relationship.Cousin, grandchild12);
        grandchild31.AddRelationship(Relationship.Cousin, grandchild21);
        grandchild31.AddRelationship(Relationship.Cousin, grandchild22);
        grandchild31.AddRelationship(Relationship.Cousin, grandchild23);
        Person grandchild32 = AddAnonymousRelationship(Relationship.Grandchild, Sex.Male);
        grandchild32.AddRelationship(Relationship.Father, son3);
        grandchild32.AddRelationship(Relationship.Mother, daughterIL3);
        grandchild32.AddRelationship(Relationship.Uncle, son1);
        grandchild32.AddRelationship(Relationship.Aunt, daughterIL1);
        grandchild32.AddRelationship(Relationship.Uncle, son2);
        grandchild32.AddRelationship(Relationship.Aunt, daughterIL2);
        grandchild32.AddRelationship(Relationship.Grandfather, husband);
        grandchild32.AddRelationship(Relationship.Cousin, grandchild11);
        grandchild32.AddRelationship(Relationship.Cousin, grandchild12);
        grandchild32.AddRelationship(Relationship.Cousin, grandchild21);
        grandchild32.AddRelationship(Relationship.Cousin, grandchild22);
        grandchild32.AddRelationship(Relationship.Cousin, grandchild23);
        grandchild32.AddRelationship(Relationship.Brother, grandchild31);
    }

    Person AddAnonymousRelationship(Relationship relationship, Sex sex) {
        Person newPerson = new Person(sex);
        soledad.AddRelationship(relationship, newPerson);
        return newPerson;
    }



}
