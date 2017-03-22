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
		//DontDestroyOnLoad(gameObject);

		asteroidPullin = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//hot key for testing
		if (Input.GetKeyDown(KeyCode.T))
		{
			asteroidPullin.Play("AsteroidPullin");
			// hot key for testing sound
			//SoundManager.instance.explosionOxygen.Play();
			//SoundManager.instance.playSingle("explosionOxygen", colOxygenSound);
		}

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
