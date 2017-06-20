using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerController : MonoBehaviour {

    public float max = 10;
    public float current = 0;

    public GameObject ValueBar;

	// Use this for initialization
	void Start () {

        Rescale();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rescale();
        }
    }

    void Rescale()
    {
        if (current <= max)
            ValueBar.transform.localScale = new Vector3(current / max, 1, 1);
    }
}
