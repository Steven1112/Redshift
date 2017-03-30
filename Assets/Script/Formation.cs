using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Formation : MonoBehaviour {
    public string name;
    public HashSet<string> ingredients;
    AnimationClip animation;
    public GameObject finalStage;
    AudioClip voiceOver;

	public Formation(string name, HashSet<string> ingredients, GameObject planet,AudioClip voiceOver) {
        this.ingredients = new HashSet<string>();
        this.name = name;
        this.ingredients = ingredients;
        this.finalStage = planet;
        this.voiceOver = voiceOver;
    }

    public HashSet<string> getIngredients() {
        return ingredients;
    }

    public void form(GameObject protoPlanet) {
		//wait for a few seconds

		// add formed planet to collection
		PlanetCollection.instance.addPlanetToCollection(this);

		// show planet info
		UnityEngine.GameObject.FindGameObjectWithTag("planetInfo").GetComponent<PlanetInfo>().ShowPlanetInfo(name);

		//display animation

		//replace finalStage with the current protoplanet object
		GameObject formed = (GameObject)Instantiate (finalStage);
		formed.AddComponent<Spin> ();
		formed.GetComponent<Spin> ().speed = protoPlanet.GetComponent<Spin> ().speed;
		formed.GetComponent<Spin> ().vector = protoPlanet.GetComponent<Spin> ().vector;
		Debug.Log (finalStage.name + " is created");
		formed.transform.position = protoPlanet.transform.position;
		formed.transform.rotation = protoPlanet.transform.rotation;
		//formed.transform.localScale = protoPlanet.transform.localScale;


		// triggering animation of formation
		protoPlanet.GetComponent<Animator> ().enabled = true;
		GameObject bigAsteroids = UnityEngine.GameObject.FindGameObjectWithTag ("bigAsteroids");
		bigAsteroids.GetComponent<Animator> ().enabled = true;
		bigAsteroids.GetComponent<Animator> ().Play ("AsteroidPullin");
		PlanetCreator.instance.lava.GetComponent<Animator> ().enabled = true;
		PlanetCreator.instance.lava.GetComponent<Animator> ().Play (name + "lava");
		protoPlanet.GetComponent<Animator> ().Play ("prototransform");
		formed.GetComponent<Animator> ().Play (name + "transform");
		SoundManager.instance.playSingle ("voiceOverSource", voiceOver);
    }

    public void setIngredients(HashSet<string> ingredients) {
        this.ingredients = ingredients;
    }

    public void setName(string name) {
        this.name = name;
    }
		
}
