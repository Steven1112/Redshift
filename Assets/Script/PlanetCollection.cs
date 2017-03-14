using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetCollection : MonoBehaviour {

    public static PlanetCollection instance = null;
    public int numPlanetColelcted = 0;
    HashSet<string> collection;
    public static int maxNumPlanet = 9;

    // UI
    [SerializeField]
    public GameObject canvas;
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

    }

    // Update is called once per frame
    void Update () {

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
            Debug.Log(name + " is added to the collection");

            // get all UI compoents of the newly collected planet
            GameObject planetObj = collectionBook[planetIndex];
            GameObject planetIngredients = planetObj.transform.GetChild(0).gameObject;
            GameObject planetImage = planetObj.transform.GetChild(1).gameObject;
            GameObject planetName = planetObj.transform.GetChild(2).gameObject;

            // update the image of the planet on UI
            Sprite image = Resources.Load<Sprite> (planet.name + "_2D") as Sprite;
            planetImage.GetComponent<Image>().sprite = image;
            // update the name of the planet on UI
            planetName.GetComponent<Text>().text = name;

            for(int i = 0; i < 3; i++)
            {
                string[] ingredients = new string[planet.ingredients.Count];
				// convert hashset from formation class to array
                planet.ingredients.CopyTo(ingredients);

                string ingredient = ingredients[i];
                Sprite ingredientImage = Resources.Load<Sprite>(ingredient + "_2D") as Sprite;
                planetIngredients.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = ingredientImage;
            }

            //planetObj.GetComponent<Image>().sprite = planetImage;
            foreach(string collected in collection)
            {
                Debug.Log("in collection: " + collected);
            }
        }
    }

}
