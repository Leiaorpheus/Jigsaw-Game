using UnityEngine.SceneManagement;
using UnityEngine;

public class checkWin : MonoBehaviour {
    public int total;
	// Use this for initialization
	void Start () {
        total = GameObject.Find("SpawnPoint").GetComponent<Inventory>().totalPiece;
       
	}
	
	// Update is called once per frame
	void Update () {
		if (total == 0)
        {
            SceneManager.LoadScene("Win");
        }
	}
}
