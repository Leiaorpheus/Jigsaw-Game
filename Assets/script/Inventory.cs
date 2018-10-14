using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {
    public int totalPiece;
    public int row;
    public float heightDistance;
    public float widthDistance;
    public GameObject samplePiece;
    private int k = 0;

    [SerializeField]
    float pieceWidth;
    [SerializeField]
    float pieceHeight;

    [SerializeField]
    private int column;

    [SerializeField]
    string spriteName;

    [SerializeField]
    int imagePos;

    [SerializeField]
    Sprite[] replacements;

   
    // Use this for initialization
    void Awake () {
        if (samplePiece.GetComponent<Rigidbody2D>() != null)
        {
            spriteName = samplePiece.GetComponent<SpriteRenderer>().sprite.name;
            imagePos = spriteName.IndexOf("_");
            replacements = Resources.LoadAll<Sprite>(spriteName.Substring(0, imagePos));
        }
        
        spawnPieces();
        
	}
	


    void spawnPieces()
    {
       
        column = totalPiece / row;

        pieceWidth = samplePiece.GetComponent<SpriteRenderer>().bounds.size.x;
        pieceHeight = samplePiece.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                GameObject pieceClone = Instantiate(samplePiece);
                pieceClone.GetComponent<Renderer>().sortingOrder = 2;
                if (samplePiece.GetComponent<Rigidbody2D>() != null)
                    pieceClone.GetComponent<SpriteRenderer>().sprite = replacements[k];
                k++;
                pieceClone.transform.position = transform.position + new Vector3 ( j * (pieceWidth + widthDistance), -(pieceHeight + heightDistance) * i, 0);
                pieceClone.name = "A" + k;
                pieceClone.transform.SetParent(transform);
                
            }
        }
    }
}
