using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour {

    [SerializeField]
    GameObject edge1;
    [SerializeField]
    GameObject edge2;

    bool changeLevel = false;

    bool FirstRayHit = false;

    public static int currentLevel = 0;
    public int maxLevel = 3;

    float xChange = 0;
    float yChange = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray downRay = new Ray(edge1.transform.position, Vector3.down);
        if (Physics.Raycast(downRay, out hit, 0.5f))
        {
            if (hit.transform.name == "EndPlatform")
            {
                PlayerMovement.canMove = false;
                currentLevel += 1;
                changeLevel = true;
                FirstRayHit = true;
            }
        }

        if (!FirstRayHit)
        {
            RaycastHit hit2;
            Ray downRay2 = new Ray(edge2.transform.position, Vector3.down);
            if (Physics.Raycast(downRay2, out hit2))
            {
                if (hit.transform.name == "EndPlatform")
                {
                    PlayerMovement.canMove = false;
                    currentLevel += 1;
                    changeLevel = true;
                }
            }
        }

        if (changeLevel == true && currentLevel < maxLevel)
        {
            FirstRayHit = false;
            transform.position = new Vector3(currentLevel * 50, 1.5f, -1);
            changeLevel = false;
            StartCoroutine(MoveDelay());
        }
        else
        {
            changeLevel = false;
            PlayerMovement.canMove = true;
        }
	}

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(0.7f);
        PlayerMovement.canMove = true;
    }
}
