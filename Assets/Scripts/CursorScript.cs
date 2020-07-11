using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

    Vector3 mousePosition = new Vector3();

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start() {
        Cursor.visible = false;

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        Cursor.visible = false;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -Camera.main.transform.position.z;

        transform.position = mousePosition ;

    }

}
