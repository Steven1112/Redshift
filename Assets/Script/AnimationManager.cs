using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	[Header("Animations")]
	public ParticleSystem simpleExplosion;
	public ParticleSystem seeResults;
    public ParticleSystem asteroidExplosion;
    [Header("Asteroids Collision Point")]
    public GameObject oxygen1;
    public GameObject oxygen2;
    public GameObject oxygen3;
    public GameObject nitrogen1;
    public GameObject nitrogen2;
    public GameObject nitrogen3;
    public GameObject hydrogen1;
    public GameObject hydrogen2;
    public GameObject hydrogen3;
    public GameObject sulfur1;
    public GameObject sulfur2;
    public GameObject sulfur3;
    public GameObject carbon1;
    public GameObject carbon2;
    public GameObject carbon3;


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
