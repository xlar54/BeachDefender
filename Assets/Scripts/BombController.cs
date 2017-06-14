using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public GameObject explosion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Target" && collision.gameObject.tag != "EnemyBomber")
        {
            //Camera c = Camera.current;
            //c.GetComponent<CameraShake>().ShakeCamera(20f, 1f);

            GameObject newExplosion = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(newExplosion, 2);

            Destroy(gameObject);
        }


    }

}
