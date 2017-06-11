using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, lifetime);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
