using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public GameObject explosion;
    public bool dropBomb;
    public GameObject bomb;
    public Transform bombSpawnPoint;

    private Vector3 previous;
    public float velocity;

	// Use this for initialization
	void Start () {

        previous = transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        float translation = Time.deltaTime * speed;
        transform.Translate(translation, 0, 0);

        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;

        if (dropBomb)
        {
            dropBomb = false;
            GameObject newBomb = (GameObject)Instantiate(bomb, bombSpawnPoint.position, Quaternion.identity);
            newBomb.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-velocity);

            // fix rotation of spawned object. not always needed
            Vector3 rotFix = newBomb.transform.rotation.eulerAngles;
            rotFix.y += 90;
            newBomb.transform.Rotate(rotFix);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "EnemyBomb")
        {

        GameObject newExplosion = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(newExplosion, 2);
        

        Destroy(gameObject);
        }


    }
}
