﻿using System.Collections;
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
    public Animator asteroidPullin;

    // [Header("Explosion Sound")]
    // public AudioClip colOxygenSound;

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
