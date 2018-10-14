using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {
    public float scrollDistance;
    public float yDiff;

    private void Update()
    {
        if (!GetComponent<PieceMovement>().placed)
        {
            scoll(); // can scroll those in inventory
            GetComponent<ReturnPiece>().returnPuzzle(); // put puzzle back
        }
        
    }


    void scoll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (!GetComponent<PieceMovement>().canIdle)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + scrollDistance);
            } else
            {
                yDiff += scrollDistance;
            }
            
            
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (!GetComponent<PieceMovement>().canIdle)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - scrollDistance);
            } else
            {
                yDiff -= scrollDistance;
            }
            
            
        }
    }
}
