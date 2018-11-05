using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject barrel;

    //shootLock is not yet implemented into the game, used in the future for disabling the turret.
    public static bool shootLock = false;

    public static bool shoot = false;
    public float force = 100;

    public int levelInit;

	// Use this for initialization
	void Start () {
        shoot = false;
        StartCoroutine(ShootDelay());
    }
	
	// Update is called once per frame
	void Update () {
		if (shoot && LevelChange.currentLevel == levelInit && !shootLock)
        {
            bullet.gameObject.SetActive(true);
            GameObject BulletDupe = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
            bullet.gameObject.SetActive(false);
            BulletDupe.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * force, ForceMode.Force);
            shoot = false;
            StartCoroutine(ShootDelay());
        }
	}

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(1);
        shoot = true;
    }
}
