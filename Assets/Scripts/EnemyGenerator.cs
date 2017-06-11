using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public int waitTime;

    public int spawnMin;
    public int spawnMax;
    public int minX;
    public int maxX;
    public int speedMin;
    public int speedMax;
    public int bomberPercentage;
    public GameObject jetFighter;
    public GameObject bomber;
    public Transform spawnPoint;

    private System.DateTime lastTime;

	// Use this for initialization
	void Start () {

        lastTime = System.DateTime.Now;

    }
	
	// Update is called once per frame
	void Update () {

        System.DateTime currentTime = System.DateTime.Now;

        var diffInSeconds = (currentTime - lastTime).TotalSeconds;

        if (diffInSeconds > waitTime)
        {
            int randomSpawnCount = Random.Range(spawnMin, spawnMax);

            for (int z = 0; z < randomSpawnCount; z++)
            {

                CreatePlane(jetFighter);

                if (Random.Range(0,100) < bomberPercentage)
                {
                    CreatePlane(bomber);
                }

            }

            lastTime = currentTime;

        }


	}

    private void CreatePlane(GameObject plane)
    {
        GameObject go = (GameObject)Instantiate(plane, spawnPoint.position, Quaternion.identity);

        ((EnemyController)go.GetComponent<EnemyController>()).speed = Random.Range(speedMin, speedMax);

        // Fix rotation
        Vector3 rotFix = spawnPoint.rotation.eulerAngles;
        rotFix.x -= 90;
        rotFix.z += 90;
        go.transform.Rotate(rotFix);


        // Randomize x and y
        Vector3 pos = go.transform.position;
        pos.x = Random.Range(minX, maxX);

        go.transform.position = pos;

        Destroy(go, 10);
    }
}
