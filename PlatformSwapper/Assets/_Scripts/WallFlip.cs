using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFlip : MonoBehaviour {
    
    [SerializeField]
    GameObject Player;

    public static bool flip = false;

    bool canFlip = true;

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canFlip == true)
        {
            canFlip = false;
            if (anim.GetBool("Side") == false)
            {
                Player.GetComponent<BoxCollider>().enabled = false;
                Player.GetComponent<Rigidbody>().useGravity = false;
                anim.SetBool("Side", true);
                StartCoroutine(FlipDelay());
            }
            else if (anim.GetBool("Side") == true)
            {
                Player.GetComponent<BoxCollider>().enabled = false;
                Player.GetComponent<Rigidbody>().useGravity = false;
                anim.SetBool("Side", false);
                StartCoroutine(FlipDelay());
            }
        }
	}

    IEnumerator FlipDelay()
    {
        yield return new WaitForSeconds(0.05f);
        Player.GetComponent<BoxCollider>().enabled = true;
        Player.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(0.2f);
        canFlip = true;
    }
}
