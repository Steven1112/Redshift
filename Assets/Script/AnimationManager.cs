using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	[Header("Animations")]
	public ParticleSystem simpleExplosion;
	public ParticleSystem seeResults;

	public static AnimationManager instance = null;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playFormationEffect(){
		seeResults.Play();
	}

	public void stopFormationEffect(){
		seeResults.Stop();		
	}
}
