using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetCollection : MonoBehaviour {

    public static PlanetCollection instance = null;
    public int numPlanetColelcted = 0;
    HashSet<string> collection;

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
        string name = planet.name;
        if (planet.name != "fail" && !collection.Contains(name)) 
        {
            numPlanetColelcted++;
            collection.Add(name);
            Debug.Log(name + " is added to the collection");
            Sprite planetImage = Resources.Load<Sprite> (planet.name + "_2D") as Sprite;

            collectionBook[numPlanetColelcted - 1].GetComponent<Image>().sprite = planetImage;
            foreach(string collected in collection)
            {
                Debug.Log("in collection: " + collected);
            }
        }
    }

    public bool isInCollection(Formation planet)
    {
        /*
        for(int i =0; i < numPlanetColelcted; i++)
        {
            Debug.Log("index: " + i);
            if (string.Equals(collection[i].name, planet.name))
            {
                return true;
            }
        }*/
        return false;
    }
}
