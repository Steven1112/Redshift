using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	[Header("Visual Effects")]
	public ParticleSystem simpleExplosion;
	public ParticleSystem seeResults;
    public ParticleSystem oxygenHitExplosion;
    public ParticleSystem nitrogenHitExplosion;
    public ParticleSystem hydrogenHitExplosion;
    public ParticleSystem sulfurHitExplosion;
    public ParticleSystem carbonHitExplosion;
    public ParticleSystem commonHitExplosion;

    [Header("Animations")]
    public Animator asteroidSuckin;

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
		
        asteroidSuckin = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {

        //hot key for testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            asteroidSuckin.Play("AsteroidSuckin");
        }
    }

    public void playAsteroidSuckinEffect()
    {
        asteroidSuckin.Play("AsteroidSuckin");
    }

    public void playFormationEffect(){
		seeResults.Play();
	}

	public void stopFormationEffect(){
		seeResults.Stop();		
	}

    public void visualEffectsClearAll()
    {
        oxygenHitExplosion.Stop();
        nitrogenHitExplosion.Stop();
        hydrogenHitExplosion.Stop();
        sulfurHitExplosion.Stop();
        carbonHitExplosion.Stop();
        commonHitExplosion.Stop();
    }
}
