using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPiece : MonoBehaviour {
    public KeyCode returnPiece;

   
    public Vector2 piecePosition;

	
    // putting puzzle back to inventory
    public void returnPuzzle()
    {
        if (Input.GetKeyDown(returnPiece) && GetComponent<PieceMovement>().canIdle)
        {
            transform.position = new Vector2 (piecePosition.x, piecePosition.y + GetComponent<Scroller>().yDiff);
            GetComponent<PieceMovement>().canIdle = false;
        }
    }

    private void OnMouseDown()
    {
        piecePosition = transform.position;
    }
}
