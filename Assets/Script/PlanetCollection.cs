using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetCollection : MonoBehaviour {

	public static PlanetCollection instance = null;
	public int numPlanetColelcted = 0;
	public HashSet<string> collection;
	public HashSet<Formation> formations;
	public static int maxNumPlanet = 9;

    List<string> planetsNotInCollection;

	// UI
	[SerializeField]
    public GameObject tutorialPane;
    public GameObject[] collectionBook = new GameObject[9];


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
		DontDestroyOnLoad(gameObject);

		collection = new HashSet<string>();

        // initialize planetsNotInCollection
        planetsNotInCollection = new List<string>();
        planetsNotInCollection.Add("mercury");
        planetsNotInCollection.Add("venus");
        planetsNotInCollection.Add("earth");
        planetsNotInCollection.Add("mars");
        planetsNotInCollection.Add("jupiter");
        planetsNotInCollection.Add("saturn");
        planetsNotInCollection.Add("uranus");
        planetsNotInCollection.Add("neptune");
        planetsNotInCollection.Add("pluto");
    }

	// Update is called once per frame
	void Update () {

	}

	public void ReloadCollectionBook()
	{
        tutorialPane = UnityEngine.GameObject.FindGameObjectWithTag("tutorial");

        //Debug.Log(planetsNotInCollection[1]);
        //tutorialPane.GetComponent<Image>().sprite = Resources.Load("PlanetInfo/Locked/" + planetsNotInCollection[0] + "Info_locked") as Sprite;

        collectionBook [0] = UnityEngine.GameObject.FindGameObjectWithTag ("earth");
		collectionBook [1] = UnityEngine.GameObject.FindGameObjectWithTag ("jupiter");
		collectionBook [2] = UnityEngine.GameObject.FindGameObjectWithTag ("mars");
		collectionBook [3] = UnityEngine.GameObject.FindGameObjectWithTag ("mercury");
        collectionBook [4] = UnityEngine.GameObject.FindGameObjectWithTag ("neptune");
		collectionBook [5] = UnityEngine.GameObject.FindGameObjectWithTag ("pluto");
		collectionBook [6] = UnityEngine.GameObject.FindGameObjectWithTag ("saturn");
		collectionBook [7] = UnityEngine.GameObject.FindGameObjectWithTag ("venus");
		collectionBook [8] = UnityEngine.GameObject.FindGameObjectWithTag ("uranus");

        if (collection!=null && collection.Count > 0)
		{
			string[] planetsInCollection = new string[collection.Count];
			collection.CopyTo(planetsInCollection);

			for (int i = 0; i < planetsInCollection.Length; i++)
			{
				for (int j = 0; j < collectionBook.Length; j++)
				{
					if (planetsInCollection[i] == collectionBook[j].tag)
					{
						//Formation planet = (Formation)PlanetCreator.instance.results[planetsInCollection[i]];
						//Debug.Log ("planet name:" + planet.name);
						// get all UI compoents of the newly collected planet
						GameObject planetObj = collectionBook[j];
						GameObject planetImage = planetObj.transform.GetChild(0).gameObject;
						GameObject planetName = planetObj.transform.GetChild(1).gameObject;

						// update the image of the planet on UI
						Sprite image = Resources.Load<Sprite>(planetsInCollection[i] + "_2D") as Sprite;
						planetImage.GetComponent<Image>().sprite = image;
						// update the name of the planet on UI
						planetName.GetComponent<Text>().text = planetObj.tag.ToUpper();
					}
				}
			}
		}
	}

	public void addPlanetToCollection(Formation planet) {
		int planetIndex = 0;
		string name = planet.name;

		for(int i = 0; i < maxNumPlanet; i++)
		{
			if (collectionBook[i].tag.Equals(name))
			{
				planetIndex = i;
				Debug.Log("planet index: " + i);
				break;
			}
		}

		if (planet.name != "fail" && !collection.Contains(name)) 
		{
			numPlanetColelcted++;
			collection.Add(name);
            planetsNotInCollection.Remove(name);

			Debug.Log(name + " is added to the collection");

			// get all UI compoents of the newly collected planet
			GameObject planetObj = collectionBook[planetIndex];
			GameObject planetImage = planetObj.transform.GetChild(0).gameObject;
			GameObject planetName = planetObj.transform.GetChild(1).gameObject;

			// update the image of the planet on UI
			Sprite image = Resources.Load<Sprite> (planet.name + "_2D") as Sprite;
			planetImage.GetComponent<Image>().sprite = image;
			
            // update the name of the planet on UI
			planetName.GetComponent<Text>().text = name.ToUpper();

			foreach(string collected in collection)
			{
				Debug.Log("in collection: " + collected);
			}
		}
	}
}