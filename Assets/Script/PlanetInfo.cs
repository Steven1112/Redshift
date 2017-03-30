using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour {
    PlanetCollection planetCollection;
    public GameObject tutorialPane;

	public string currentPlanet = "";
	public string currentState = "";

	public AudioClip tutorialVoice;

    // Use this for initialization
    void Start () {
        planetCollection = UnityEngine.GameObject.FindGameObjectWithTag("Collection").GetComponent<PlanetCollection>();       		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowPlanetInfo(string planet)
    {
        Sprite planetInfoImage;

        if (planetCollection.collection.Contains(planet))
        {
            // show planet facts
            planetInfoImage = Resources.Load<Sprite>("PlanetInfo/Unlocked/" + planet + "Info_unlocked") as Sprite;
			currentState = "Unlocked";

        }
        else
        {
            // show tutorial
            planetInfoImage = Resources.Load<Sprite>("PlanetInfo/Locked/" + planet + "Info_locked") as Sprite;
			currentState = "Locked";
        }

		currentPlanet = planet;
        tutorialPane.GetComponent<Image>().sprite = planetInfoImage;
    }

	public void PlayTutorialVoice(){
		SoundManager.instance.playSingle("effectSource", tutorialVoice);
	}

}
