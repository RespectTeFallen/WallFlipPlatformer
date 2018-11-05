using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5 || transform.position.y > 15 || Input.GetKeyDown(KeyCode.R))
        {
            reset();
        }
    }

    void reset()
    {
        transform.position = new Vector3((LevelChange.currentLevel - 1), 1, -1.01f);
    }
}
