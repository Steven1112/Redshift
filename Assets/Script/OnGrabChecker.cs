using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrabChecker : MonoBehaviour {

    public bool isOnGrab;
	public GameObject asteroidInfo;

	// Use this for initialization
	void Start () {
        isOnGrab = false;
	}

	public void DisableInfoPanel(){
		asteroidInfo.SetActive (false);
	}
}
