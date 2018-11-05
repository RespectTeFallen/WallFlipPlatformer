using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    [SerializeField]
    GameObject levelGameObject;
    public int Level;
	
	void Update () {
		if (LevelChange.currentLevel == Level)
        {
            levelGameObject.SetActive(true);
        }
        else
        {
            levelGameObject.SetActive(false);
        }
    }
}
