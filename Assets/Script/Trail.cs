using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {
    public GameObject trail;

	// Use this for initialization
	void Start () {
        trail = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        trail.SetActive(false);		
	}
	
	// Update is called once per frame
	void Update () {
        		
	}
}
