using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteManager : MonoBehaviour {

    public static SpriteManager current;

    SpriteAtlas relationshipSprites;
    SpriteAtlas personSprites;

    private void Awake() {

        if ( current != null ) {
            Destroy(gameObject);
        }
        else {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {

        relationshipSprites = (SpriteAtlas) Resources.Load("Relationships");
        personSprites = (SpriteAtlas) Resources.Load("Persons");
    }


    public Sprite GetSpriteFromRelationship(Relationship relationship) {
        string relationshipString = GetStringOfRelationship(relationship);
        return relationshipSprites.GetSprite(relationshipString);
    }

    private static string GetStringOfRelationship(Relationship relationship) {
        string relationshipString;
        switch ( relationship ) {
            case Relationship.Unknown:
                relationshipString = "";
                break;
            case Relationship.Husband:
                relationshipString = "husband";
                break;
            case Relationship.Wife:
                relationshipString = "wife";
                break;
            case Relationship.Father:
                relationshipString = "father";
                break;
            case Relationship.Mother:
                relationshipString = "mother";
                break;
            case Relationship.Son:
                relationshipString = "son";
                break;
            case Relationship.Daughter:
                relationshipString = "daughter";
                break;
            case Relationship.Brother:
                relationshipString = "brother";
                break;
            case Relationship.Sister:
                relationshipString = "sister";
                break;
            case Relationship.Grandmother:
                relationshipString = "grandmother";
                break;
            case Relationship.Grandfather:
                relationshipString = "grandfather";
                break;
            case Relationship.Grandchild_m:
                relationshipString = "grandchild_m";
                break;
            case Relationship.Grandchild_f:
                relationshipString = "grandchild_f";
                break;
            case Relationship.Uncle:
                relationshipString = "uncle";
                break;
            case Relationship.Aunt:
                relationshipString = "aunt";
                break;
            case Relationship.Cousin_m:
                relationshipString = "cousin_m";
                break;
            case Relationship.Cousin_f:
                relationshipString = "cousin_f";
                break;
            case Relationship.Niece:
                relationshipString = "niece";
                break;
            case Relationship.Nephew:
                relationshipString = "nephew";
                break;
            case Relationship.FatherInLaw:
                relationshipString = "fatheril";
                break;
            case Relationship.MotherInLaw:
                relationshipString = "motheril";
                break;
            case Relationship.SonInLaw:
                relationshipString = "sonil";
                break;
            case Relationship.DaughterInLaw:
                relationshipString = "daughteril";
                break;
            case Relationship.BrotherInLaw:
                relationshipString = "brotheril";
                break;
            case Relationship.SisterInLaw:
                relationshipString = "sisteril";
                break;
            case Relationship.Friend:
                relationshipString = "friendil";
                break;
            default:
                relationshipString = "";
                break;
        }

        return relationshipString;
    }

    public Sprite GetSpriteFromPerson(PersonName person) {
        string personString = GetStringOfPersonName(person);
        return personSprites.GetSprite(personString);
    }

    private static string GetStringOfPersonName(PersonName person) {
        string personString;
        switch ( person ) {
            case PersonName.soledad:
                personString = "soledad";
                break;
            case PersonName.javier:
                personString = "javier";
                break;
            case PersonName.jorge:
                personString = "jorge";
                break;
            case PersonName.luisfrancisco:
                personString = "luisfrancisco";
                break;
            case PersonName.socorro:
                personString = "socorro";
                break;
            case PersonName.margarita:
                personString = "margarita";
                break;
            case PersonName.concha:
                personString = "concha";
                break;
            case PersonName.almudena:
                personString = "almudena";
                break;
            case PersonName.javi:
                personString = "javi";
                break;
            case PersonName.david:
                personString = "david";
                break;
            case PersonName.jaime:
                personString = "jaime";
                break;
            case PersonName.ana:
                personString = "ana";
                break;
            case PersonName.luisNieto:
                personString = "luisnieto";
                break;
            case PersonName.alberto:
                personString = "alberto";
                break;
            case PersonName.luis:
                personString = "luis";
                break;
            case PersonName.francisco:
                personString = "francisco";
                break;
            case PersonName.maria:
                personString = "maria";
                break;
            default:
                personString = "";
                break;
        }

        return personString;
    }

    public Color GetSpriteColorFromPersonName(PersonName name) {

        float r = 0;
        float g = 0;
        float b = 0;
        float total = 0;

        string str = name.ToString();
        for ( int i = 0; i < str.Length; i++ ) {
            int c = (int) str[i] - (int) 'a';

            switch ( i%3 ) {
                case 0:
                    r += c;
                    break;
                case 1:
                    g += c;
                    break;
                default:
                    b += c;
                    break;
            }
            total += c;
        }

        r /= total;
        g /= total;
        b /= total;

        return new Color(r, g, b);

    }

}
