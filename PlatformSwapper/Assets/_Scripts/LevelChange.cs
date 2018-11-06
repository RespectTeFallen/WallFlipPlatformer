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

    public static int currentLevel = 1;
    public int setLevel;
    public int maxLevel = 6;

    float xChange = 0;
    float yChange = 0;

	// Use this for initialization
	void Start () {
        currentLevel = setLevel;
        transform.position = new Vector3((LevelChange.currentLevel - 1) * 50, 1, -1.01f);
    }
	
	// Update is called once per frame
	void Update () {
        
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(downRay, out hit, 0.5f))
        {
            if (hit.transform.name == "EndPlatform")
            {
                PlayerMovement.canMove = false;
                if (currentLevel < maxLevel)
                {
                    currentLevel += 1;
                    transform.position = new Vector3((currentLevel - 1) * 50, 1.5f, -1.01f);
                    changeLevel = false;
                    StartCoroutine(MoveDelay());
                }
                else
                {
                    PlayerMovement.canMove = true;
                }
                FirstRayHit = true;
            }
        }
	}

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(0.7f);
        PlayerMovement.canMove = true;
    }
}
