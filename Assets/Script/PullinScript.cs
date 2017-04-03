using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullinScript : MonoBehaviour {

	[Header("Animations")]
	public Animator asteroidPullin;

	public static PullinScript instance = null;
	// Use this for initialization
	void Start () {
		// create instance
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		asteroidPullin = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void playAsteroidPullinEffect()
	{
		asteroidPullin.Play("AsteroidPullin");
	}

	public void stopAsteroidPullinEffect()
	{
		asteroidPullin.Stop();
	}
}
