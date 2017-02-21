using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSizeTest : MonoBehaviour {

    private GameObject spaceSize;

	// Use this for initialization
	void Start () {
		spaceSize = GameObject.Find("Floor");
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            spaceSize.transform.localScale = new Vector3(spaceSize.transform.localScale.x * 2, spaceSize.transform.localScale.y, spaceSize.transform.localScale.z * 2);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            spaceSize.transform.localScale = new Vector3(spaceSize.transform.localScale.x / 2, spaceSize.transform.localScale.y, spaceSize.transform.localScale.z / 2);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceSize.transform.localScale = new Vector3(20, 1, 20);
        }
    }
}
