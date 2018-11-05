using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    [SerializeField]
    GameObject level1;
    [SerializeField]
    GameObject level2;
    [SerializeField]
    GameObject level3;
    [SerializeField]
    GameObject level4;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelChange.currentLevel == 1)
        {
            level1.SetActive(false);
            level2.SetActive(true);
        }
        else if (LevelChange.currentLevel == 2)
        {
            level2.SetActive(false);
            level3.SetActive(true);
        }
        else if (LevelChange.currentLevel == 3)
        {
            level3.SetActive(false);
            level4.SetActive(true);
        }
    }
}
