using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public GameObject explosion;
    public bool dropBomb;
    public GameObject bomb;
    public Transform bombSpawnPoint;
    public bool bank;
    public GameObject GameManager;
    public int hitPoints;


    private Vector3 previous;
    public float velocity;

    private Quaternion startRotation;
    private int bankDirection;
    private int bankAngle;
    private bool fixBank;

    // Use this for initialization
    void Start () {

        previous = transform.position;

        startRotation = transform.rotation;
        bankDirection = Random.Range(0, 2) * 2 - 1;
        bankAngle = 30;
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(-Vector3.forward * Time.deltaTime * speed);

        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;


        if (bank)
        {
            var v = -1 * bankDirection;
            transform.Rotate(new Vector3(0.5f, bankDirection * 0.5f, bankDirection * bankAngle * Time.deltaTime * 3));
            
            if (Quaternion.Angle(transform.rotation, startRotation) > bankAngle)
            {
                bank = false;
                fixBank = true;
            }

        }

        /*if (fixBank)
        {
            transform.Rotate(new Vector3(-bankDirection * bankAngle * Time.deltaTime * 3, -0.3f, 0));

            if (Quaternion.Angle(transform.rotation, startRotation) == 0)
            {
                //transform.Rotate(new Vector3(0, -0.3f, 0));
                fixBank = false;
            }
        }*/



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
            if (gameObject.tag == "EnemyJet")
            {
                GameManager.GetComponent<GameController>().score += 10;
                GameManager.GetComponent<GameController>().hits++;

                hitPoints--;
            }

            if (gameObject.tag == "EnemyBomber")
            {
                hitPoints--;

                gameObject.GetComponentInChildren<HitMarkerController>().current--;
            }

            
            if(hitPoints == 0)
            {
                GameObject newExplosion = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(newExplosion, 2);
                Destroy(gameObject);
            }
            

        }


    }
}
