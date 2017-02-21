using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetCreator : MonoBehaviour {

    [SerializeField]
    public GameObject protoPlanet;

    //public GameObject[] planets;
    public HashSet<string> ingredients;
    public HashSet<string> userMixture;
    public Hashtable results = new Hashtable();
    public int numMaterialCollected;
    public const int MAX_NUM_MATERIAL = 3;
	public bool canRestart = false;

	public GameObject[] collected;

    public static PlanetCreator instance = null;
	public GameObject[] asteroidTracking = new GameObject[3];

	/*
	//[Header("Asteroid Tracking Text")]
	public GameObject textFirstCollected;
	public Text textFirstCollectedText;
	public GameObject textSecondCollected;
	public Text textSecondCollectedText;
	public GameObject textThirdCollected;
	public Text textThirdCollectedText;

	private Sprite nitrogenSprite;
	private Sprite hydrogenSprite;
	private Sprite oxygenSprite;
	private Sprite sulfurSprite;
	private Sprite carbonSprite;

	//[Header("Asteroid Tracking Image")]
	public Image firstCollectedImage;
	public Image secondCollectedImage;
	public Image thirdCollectedImage;
	*/


    void Awake() {

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

        //planets = new GameObject[10];
        ingredients = new HashSet<string> {"nitrogen", "hydrogen", "oxygen", "sulfur", "carbon", "commonasteroids"};
        userMixture = new HashSet<string>();

        HashSet<string> mercuryIngredients = new HashSet<string> { "oxygen", "hydrogen", "nitrogen"};
        HashSet<string> venusIngredients = new HashSet<string> { "carbon", "hydrogen", "sulfur" };
        HashSet<string> earthIngredients = new HashSet<string> { "nitrogen", "carbon", "hydrogen" };
        HashSet<string> marsIngredients = new HashSet<string> { "nitrogen", "carbon", "oxygen" };
        HashSet<string> jupiterIngredients = new HashSet<string> { "nitrogen", "hydrogen", "sulfur" };
        HashSet<string> saturnIngredients = new HashSet<string> { "oxygen", "hydrogen", "sulfur" };
        HashSet<string> uranusIngredients = new HashSet<string> { "carbon", "oxygen", "hydrogen" };
        HashSet<string> neptuneIngredients = new HashSet<string> { "carbon", "oxygen", "sulfur" };
        HashSet<string> plutoIngredients = new HashSet<string> { "nitrogen", "carbon", "sulfur" };
        HashSet<string> failIngredients = new HashSet<string> { "nitrogen", "oxygen", "sulfur" };

        Formation mercury = new Formation("mercury", mercuryIngredients,Resources.Load("mercury") as GameObject);
        Debug.Log("the name of the object is: "+ mercury.finalStage.name);
        Formation venus = new Formation("venus", venusIngredients, Resources.Load("venus") as GameObject);
        Formation earth = new Formation("earth", earthIngredients, Resources.Load("earth") as GameObject);
		Debug.Log("the name of the object is: "+ earth.finalStage.name);
        Formation mars = new Formation("mars", marsIngredients, Resources.Load("mars") as GameObject);
        Formation jupiter = new Formation("jupiter", jupiterIngredients, Resources.Load("jupiter") as GameObject);
        Formation saturn = new Formation("saturn", saturnIngredients, Resources.Load("saturn") as GameObject);
        Formation uranus = new Formation("uranus", uranusIngredients, Resources.Load("uranus") as GameObject);
        Formation neptune = new Formation("neptune", neptuneIngredients, Resources.Load("neptune") as GameObject);
        Formation pluto = new Formation("pluto", plutoIngredients, Resources.Load("pluto") as GameObject);
        Formation fail = new Formation("fail", failIngredients, Resources.Load("fail") as GameObject);

        results[0] = mercury;
        results[1] = venus;
        results[2] = earth;
        results[3] = mars;
        results[4] = jupiter;
        results[5] = saturn;
        results[6] = uranus;
        results[7] = neptune;
        results[8] = pluto;
        results[9] = fail;

		/*
		textFirstCollectedText = textFirstCollected.GetComponent<Text>();
		textSecondCollectedText = textSecondCollected.GetComponent<Text>();
		textThirdCollectedText = textThirdCollected.GetComponent<Text>();

		if (numMaterialCollected == 0) {
			textFirstCollectedText.text = "";
			textSecondCollectedText.text = "";
			textThirdCollectedText.text = "";
		}

		nitrogenSprite = Resources.Load <Sprite>("asteroids02");
		hydrogenSprite = Resources.Load <Sprite>("asteroids01");
		oxygenSprite = Resources.Load <Sprite>("asteroids04");
		sulfurSprite = Resources.Load <Sprite>("asteroids05");
		carbonSprite = Resources.Load <Sprite>("asteroids03");

		//firstCollectedImage = GameObject.Find("FirstAsteroidImage");
		//secondCollectedImage = GameObject.Find("SecondAsteroidImage");
		//thirdCollectedImage = GameObject.Find("ThirdAsteroidImage");

		firstCollectedImage.sprite = null;
		secondCollectedImage.sprite = null;
		thirdCollectedImage.sprite = null;
		firstCollectedImage.enabled = false;
		secondCollectedImage.enabled = false;
		thirdCollectedImage.enabled = false;
		*/
		foreach (GameObject image in asteroidTracking) {
			image.GetComponent<Image> ().enabled = false;
		}

    }

    public void addMaterial(string material) {

        //SoundManager.instance.playSingle("effectSource",clickSound);
		if (numMaterialCollected < MAX_NUM_MATERIAL && !userMixture.Contains(material) && material!= "common")
		{
			numMaterialCollected++;

			// update Asteroid Tracking UI
			GameObject curAsteroid = asteroidTracking [numMaterialCollected - 1];
			Sprite asteroidImage = Resources.Load<Sprite> (material + "_2D") as Sprite;
			curAsteroid.GetComponent<Image> ().enabled = true;
			curAsteroid.GetComponent<Image> ().sprite = asteroidImage;
			curAsteroid.transform.GetChild (0).GetComponent<Text> ().text = material;
			/*
			if(string.Equals(material, "commonasteroids")){
				Debug.Log ("Add nothing");
			}
			else{
					Debug.Log ("Add material collection");
					numMaterialCollected++;
			}
			*/
			if (string.Equals(material, "nitrogen"))
			{
				addNitrogen();
			}
			else if (string.Equals(material, "carbon"))
			{
				addCarbon();

			}
			else if (string.Equals(material, "oxygen"))
			{
				addOxygen();
			}
			else if (string.Equals(material, "hydrogen"))
			{
				addHydrogen();
			}
			else if (string.Equals(material, "sulfur"))
			{
				addSulfur();
			}

			else {
				// do nothing
			}

			growSize();
		}


		if (numMaterialCollected == 3) {
			computeResult(userMixture).form(protoPlanet);
		}

    }
    void addNitrogen() {
        userMixture.Add("nitrogen");
        Debug.Log("asteroid " + numMaterialCollected + ":nitrogen");
		/*
		if (numMaterialCollected == 1) {
			textFirstCollectedText.text = "nitrogen";
			firstCollectedImage.sprite = nitrogenSprite;
			firstCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 2) {
			textSecondCollectedText.text = "nitrogen";
			secondCollectedImage.sprite = nitrogenSprite;
			secondCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 3) {
			textThirdCollectedText.text = "nitrogen";
			thirdCollectedImage.sprite = nitrogenSprite;
			thirdCollectedImage.enabled = true;
		}*/
    }
    void addCarbon()
    {
        userMixture.Add("carbon");
        Debug.Log("asteroid" + numMaterialCollected + ":carbon");
		/*
		if (numMaterialCollected == 1) {
			textFirstCollectedText.text = "carbon";
			firstCollectedImage.sprite = carbonSprite;
			firstCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 2) {
			textSecondCollectedText.text = "carbon";
			secondCollectedImage.sprite = carbonSprite;
			secondCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 3) {
			textThirdCollectedText.text = "carbon";
			thirdCollectedImage.sprite = carbonSprite;
			thirdCollectedImage.enabled = true;
		}*/

    }
    void addOxygen() {
        userMixture.Add("oxygen");
        Debug.Log("asteroid" + numMaterialCollected + ":oxygen");
		/*
		if (numMaterialCollected == 1) {
			textFirstCollectedText.text = "oxygen";
			firstCollectedImage.sprite = oxygenSprite;
			firstCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 2) {
			textSecondCollectedText.text = "oxygen";
			secondCollectedImage.sprite = oxygenSprite;
			secondCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 3) {
			textThirdCollectedText.text = "oxygen";
			thirdCollectedImage.sprite = oxygenSprite;
			thirdCollectedImage.enabled = true;
		}*/
    }
    void addHydrogen() {
        userMixture.Add("hydrogen");
        Debug.Log("asteroid" + numMaterialCollected + ":hydrogen");
		/*
		if (numMaterialCollected == 1) {
			textFirstCollectedText.text = "hydrogen";
			firstCollectedImage.sprite = hydrogenSprite;
			firstCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 2) {
			textSecondCollectedText.text = "hydrogen";
			secondCollectedImage.sprite = hydrogenSprite;
			secondCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 3) {
			textThirdCollectedText.text = "hydrogen";
			thirdCollectedImage.sprite = hydrogenSprite;
			thirdCollectedImage.enabled = true;
		}*/

    }
    void addSulfur() {
        userMixture.Add("sulfur");
        Debug.Log("asteroid" + numMaterialCollected + ":sulfur");
		/*
		if (numMaterialCollected == 1) {
			textFirstCollectedText.text = "sulfur";
			firstCollectedImage.sprite = sulfurSprite;
			firstCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 2) {
			textSecondCollectedText.text = "sulfur";
			secondCollectedImage.sprite = sulfurSprite;
			secondCollectedImage.enabled = true;
		}

		if (numMaterialCollected == 3) {
			textThirdCollectedText.text = "sulfur";
			thirdCollectedImage.sprite = sulfurSprite;
			thirdCollectedImage.enabled = true;
		}*/
    }



    Formation computeResult(HashSet<string> userMixture)
    {
        int size = results.Count;
        
        for(int i=0; i < size; i++)
        {
            if (userMixture.SetEquals(((Formation)results[i]).ingredients)) {
                return ((Formation)results[i]);
            }
        }
        return null;
    }

    public void growSize() {
        //increase the size of the protoplanet
        protoPlanet.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
	
	public void lastAbsorbed(){

		computeResult(userMixture).form(protoPlanet);
    }

	public void reStart(){

		SceneManager.LoadScene("Teleport_Scene_2");
	}

	void Update() {
		
		if (canRestart && Input.GetKeyDown(KeyCode.R))
		{
			reStart();
			canRestart = false;
		}

	}
}
