using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAnimator : MonoBehaviour {
    [SerializeField]
    List<Animator> myanimators;

    public float waitEnd;
    public float seconds;
	// Use this for initialization
	void Start () {
        myanimators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(doAnimation());
	}
	
	IEnumerator doAnimation()
    {
        while(true)
        {
            foreach (Animator i in myanimators)
            {
                i.SetTrigger("doAnimation");
                yield return new WaitForSeconds(seconds);
            }

            yield return new WaitForSeconds(waitEnd);
        }
    }
}
