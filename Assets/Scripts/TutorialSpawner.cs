using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabNameToken;

    int spawnTurn = 0;

    public void SpawnNextBatchOfNames() {
        if ( GameController.current.Language == Language.ES ) {
            SpawnNextBatchOfNamesES();
        }
        else {
            SpawnNextBatchOfNamesEN();
        }
    }


    private void SpawnNextBatchOfNamesES() {
        switch ( spawnTurn ) {
            case 0:
                InstantiateNameTokenAtPosition(PersonName.maria, new Vector3(3, 5, 0));
                InstantiateNameTokenAtPosition(PersonName.francisco, new Vector3(5, 5, 0));
                break;
            case 1:
                InstantiateNameTokenAtPosition(PersonName.luis, new Vector3(7, 5, 0));
                break;
            case 2:
                InstantiateNameTokenAtPosition(PersonName.luisfrancisco, new Vector3(3, 2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.jorge, new Vector3(5, 2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.javier, new Vector3(7, 2.5f, 0));
                break;
            case 3:
                InstantiateNameTokenAtPosition(PersonName.socorro, new Vector3(3, 0.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.concha, new Vector3(5, 0.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.margarita, new Vector3(7, 0.5f, 0));
                break;
            case 4:
                InstantiateNameTokenAtPosition(PersonName.almudena, new Vector3(3, -2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.javi, new Vector3(3, -4f, 0));
                break;
            case 5:
                InstantiateNameTokenAtPosition(PersonName.david, new Vector3(5, -1.75f, 0));
                InstantiateNameTokenAtPosition(PersonName.jaime, new Vector3(5, -3.25f, 0));
                InstantiateNameTokenAtPosition(PersonName.ana, new Vector3(5, -4.75f, 0));
                break;
            case 6:
                InstantiateNameTokenAtPosition(PersonName.luisNieto, new Vector3(7, -2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.alberto, new Vector3(7, -4f, 0));
                break;
            default:
                break;
        }
        spawnTurn++;
    }

    private void SpawnNextBatchOfNamesEN() {
        switch ( spawnTurn ) {
            case 0:
                InstantiateNameTokenAtPosition(PersonName.margarita, new Vector3(3, 5, 0));
                InstantiateNameTokenAtPosition(PersonName.jaime, new Vector3(5, 5, 0));
                break;
            case 1:
                InstantiateNameTokenAtPosition(PersonName.carlos, new Vector3(7, 5, 0));
                break;
            case 2:
                InstantiateNameTokenAtPosition(PersonName.alberto, new Vector3(3, 2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.francisco, new Vector3(5, 2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.david, new Vector3(7, 2.5f, 0));
                break;
            case 3:
                InstantiateNameTokenAtPosition(PersonName.almudena, new Vector3(3, 0.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.maria, new Vector3(5, 0.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.ana, new Vector3(7, 0.5f, 0));
                break;
            case 4:
                InstantiateNameTokenAtPosition(PersonName.socorro, new Vector3(3, -2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.luisfrancisco, new Vector3(3, -4f, 0));
                break;
            case 5:
                InstantiateNameTokenAtPosition(PersonName.jorge, new Vector3(5, -1.75f, 0));
                InstantiateNameTokenAtPosition(PersonName.javier, new Vector3(5, -3.25f, 0));
                InstantiateNameTokenAtPosition(PersonName.pilar, new Vector3(5, -4.75f, 0));
                break;
            case 6:
                InstantiateNameTokenAtPosition(PersonName.luis, new Vector3(7, -2.5f, 0));
                InstantiateNameTokenAtPosition(PersonName.javi, new Vector3(7, -4f, 0));
                break;
            default:
                break;
        }
        spawnTurn++;
    }




    void InstantiateNameTokenAtPosition(PersonName name, Vector3 position) {
        GameObject nameToken = Instantiate(prefabNameToken);
        SpriteRenderer spriteRenderer = nameToken.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SpriteManager.current.GetSpriteFromPerson(name);
        spriteRenderer.color = SpriteManager.current.GetSpriteColorFromPersonName(name);

        nameToken.transform.position = position;
    }

    public void ClearAllTokens() {
        foreach ( GameObject gameObject in GameObject.FindGameObjectsWithTag("Token") ) {
            Destroy(gameObject);
        }

    }

}
