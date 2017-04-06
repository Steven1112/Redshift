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

    List<string> planetsNotInCollection = new List<string>() {"mercury", "venus", "earth", "mars", "jupiter","saturn", "uranus", "neptune", "pluto"};

	// UI
	[SerializeField]
    public GameObject tutorialPane;
    public GameObject[] collectionBook = new GameObject[9];

    public bool isTutorialShown = false;
	public AudioClip collectionCompleteVoice;


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
    }

	// Update is called once per frame
	void Update () {

	}

	public void ReloadCollectionBook()
	{
        tutorialPane = UnityEngine.GameObject.FindGameObjectWithTag("tutorial");

        if (isTutorialShown == true)
        {
            Sprite planetInfoImage = Resources.Load<Sprite>("PlanetInfo/Locked/" + planetsNotInCollection[0] + "Info_locked") as Sprite;
            tutorialPane.GetComponent<Image>().sprite = planetInfoImage;
        }

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

		if(numPlanetColelcted == maxNumPlanet){
			PlanetCreator planetCreator = UnityEngine.GameObject.FindGameObjectWithTag("creator").GetComponent<PlanetCreator>();
			planetCreator.restartPane.SetActive(false);
			planetCreator.solarSystemPane.SetActive(true);
			SoundManager.instance.playSingle("voiceOverSource",collectionCompleteVoice);
		}
	}
}