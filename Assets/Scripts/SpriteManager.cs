using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteManager : MonoBehaviour {

    public static SpriteManager current;

    [SerializeField]
    SpriteAtlas relationshipSprites;

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
    }

    // Update is called once per frame
    void Update() {

    }

    public Sprite GetSpriteFromRelationship(Relationship relationship) {
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
            case Relationship.Grandchild:
                relationshipString = "grandchild";
                break;
            case Relationship.Uncle:
                relationshipString = "uncle";
                break;
            case Relationship.Aunt:
                relationshipString = "aunt";
                break;
            case Relationship.Cousin:
                relationshipString = "cousin";
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
        return relationshipSprites.GetSprite(relationshipString);
    }

}
