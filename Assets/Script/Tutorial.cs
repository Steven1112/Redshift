using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
	public AudioClip teleportVoiceOver;
	public AudioClip controllerVoiceOver;
	public AudioClip createPlanetVoiceOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayTutorialVoiceOver(string tutorialType){
		if (tutorialType == "teleport") {
			SoundManager.instance.playSingle ("voiceOverSource", teleportVoiceOver);
		}else if(tutorialType == "createPlanet") {
			SoundManager.instance.playSingle ("voiceOverSource", createPlanetVoiceOver);
		}else if(tutorialType == "controller") {
			SoundManager.instance.playSingle ("voiceOverSource", controllerVoiceOver);
		}else{
			// do nothing
		}
	}
}
