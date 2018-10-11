using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour {

    public bool placed;
	
	// Update is called once per frame
	void Update () {

        // move the puzzle with mouse movement
        if (!placed)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
        
	}

    // if it fits in one socket
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            transform.position = other.gameObject.transform.position;
            placed = true;
        }
    }
}
