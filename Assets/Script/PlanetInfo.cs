using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour {
    PlanetCollection planetCollection;
    public GameObject tutorialPane;

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
            planetInfoImage = Resources.Load("PlanetInfo/Unlocked/" + planet + "Info_unlocked") as Sprite;

        }
        else
        {
            // show tutorial
            planetInfoImage = Resources.Load("PlanetInfo/Locked/" + planet + "Info_locked") as Sprite;
        }

        tutorialPane.GetComponent<Image>().sprite = planetInfoImage;
    }
}
