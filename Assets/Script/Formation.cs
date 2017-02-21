using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Formation : MonoBehaviour {
    public string name;
    public HashSet<string> ingredients;
    AnimationClip animation;
    public GameObject finalStage;

    public Formation(string name, HashSet<string> ingredients, GameObject planet) {
        this.ingredients = new HashSet<string>();
        this.name = name;
        this.ingredients = ingredients;
        this.finalStage = planet;
    }

    public HashSet<string> getIngredients() {
        return ingredients;
    }

    public void form(GameObject protoPlanet) {
		//wait for a few seconds

		// add formed planet to collection
		// PlanetCollection.instance.addPlanetToCollection(this);

		//display animation

		//replace finalStage with the current protoplanet object
		GameObject formed = (GameObject)Instantiate (finalStage);
		formed.GetComponent<Spin> ().speed = protoPlanet.GetComponent<Spin> ().speed;
		formed.GetComponent<Spin> ().vector = protoPlanet.GetComponent<Spin> ().vector;
		Debug.Log (finalStage.name + " is created");
		formed.transform.position = protoPlanet.transform.position;
		formed.transform.rotation = protoPlanet.transform.rotation;
		//formed.transform.localScale = protoPlanet.transform.localScale;

        if (protoPlanet.transform.parent != null)
        {
            Destroy(protoPlanet.transform.parent.gameObject);
			Debug.Log ("protoplanet has parent");
        }
        else {}

		AnimationManager.instance.seeResults.Stop();
        Destroy(protoPlanet);
    

        // destory asteroids
        GameObject collected = UnityEngine.GameObject.FindGameObjectWithTag("collected");
        Destroy(collected);
    }

    public void setIngredients(HashSet<string> ingredients) {
        this.ingredients = ingredients;
    }
    public void setName(string name) {
        this.name = name;
    }
		
}
