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
	/*
	public void playFormationEffect(AnimationClip animation){
		animation.Play();
	}

	public void stopFormationEffect(){
		seeResults.Stop();		
	}*/

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
