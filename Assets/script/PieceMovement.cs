using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour {

    public bool canIdle;
    public bool placed;
    public Transform edgeParticles; // edge prefab
    public AudioSource source;
    public AudioClip correct;
    public AudioClip wrong;

    public KeyCode placePiece; // keycode to check if piece has been placed
    public bool mouseClicked; // whether mouse is clicked


   
    // Update is called once per frame
    void Update () {

        // move the puzzle with mouse movement
        if (!placed && canIdle)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

        if (Input.GetKeyDown(placePiece))
        {
            mouseClicked = true;
        }
        
	}

    // if it fits in one socket
    private void OnTriggerStay2D(Collider2D other)
    {
        if (mouseClicked)
        {
            // if placed correctly 
            if (other.gameObject.name == gameObject.name)
            {
                other.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                transform.position = other.gameObject.transform.position;
                source.clip = correct;
                source.pitch = 1;
                source.volume = 0.02f;
                source.Play();
                Instantiate(edgeParticles, other.gameObject.transform.position, Quaternion.identity); //spawn
                GetComponent<Renderer>().sortingOrder = 5; // moving layer on botton
                placed = true;
                mouseClicked = false; // mouse click set to false
            } else
            {
                // i.e. collide with collider box
                if (other.gameObject.GetComponent<Rigidbody2D>() == null)
                {
                    source.clip = wrong;
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                    source.volume = 0.2f;
                    source.pitch = 5;
                    source.Play();
                    mouseClicked = false;
                }
                
            }
            
        }
      
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }


    private void OnMouseDown()
    {
        canIdle = true;
        GetComponent<Renderer>().sortingOrder = 10; // moving layer on top
        mouseClicked = false;
    }
}
