using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTriggerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyBomber")
        {
            col.gameObject.GetComponent<EnemyController>().dropBomb = true;
            //newBomb.GetComponent<Rigidbody>().velocity = col.gameObject.GetComponent<Rigidbody>().velocity;
        }
    }
}
