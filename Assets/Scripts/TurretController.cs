using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public float turretSpeed;
    public float rotationSpeed;

    public Transform barrel;
    public Transform projectileSpawnPoint;
    public Transform barrelDisc;
    public float projectileForce;
    public float destroyAfter;

    public GameObject projectile;
    public ParticleSystem smokeParticles;

	// Use this for initialization
	void Start () {

        


    }
	
	// Update is called once per frame
	void Update () {
		
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turretSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;

        barrel.Rotate(z, 0, 0);
        barrelDisc.Rotate(0, x, 0);
        //transform.Translate(x, 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = (GameObject)Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);

            // fix rotation of spawned object. not always needed
            Vector3 rotFix = projectileSpawnPoint.rotation.eulerAngles;
            rotFix.x -= 90;
            newBullet.transform.Rotate(rotFix);

            // set destroy time
            Destroy(newBullet, destroyAfter);

            // Send it on its way
            newBullet.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.up * projectileForce);

            GetComponent<AudioSource>().Play();

            //smokeParticles.Emit(3);

        }


	}
}
