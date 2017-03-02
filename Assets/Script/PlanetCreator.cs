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
	public string restartSceneName;


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
        ingredients = new HashSet<string> {"nitrogen", "hydrogen", "oxygen", "sulfur", "carbon", "common"};
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

		foreach (GameObject image in asteroidTracking) {
			image.GetComponent<Image> ().enabled = false;
		}

    }

    public void addMaterial(GameObject gameObject) {

        string material = gameObject.tag;

        AnimationManager.instance.visualEffectsClearAll();


        if (string.Equals(material, "common"))
        {
            AnimationManager.instance.commonHitExplosion.transform.position = gameObject.transform.position;
            AnimationManager.instance.commonHitExplosion.Play();
        }

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

            if (string.Equals(material, "nitrogen"))
			{
				addNitrogen(gameObject);
			}
			else if (string.Equals(material, "carbon"))
			{
				addCarbon(gameObject);

			}
			else if (string.Equals(material, "oxygen"))
			{
				addOxygen(gameObject);
			}
			else if (string.Equals(material, "hydrogen"))
			{
				addHydrogen(gameObject);
			}
			else if (string.Equals(material, "sulfur"))
			{
				addSulfur(gameObject);
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
	void addNitrogen(GameObject gameObject) {
        userMixture.Add("nitrogen");
        Debug.Log("asteroid " + numMaterialCollected + ":nitrogen");
        AnimationManager.instance.nitrogenHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.nitrogenHitExplosion.Play();

    }
	void addCarbon(GameObject gameObject)
    {
        userMixture.Add("carbon");
        Debug.Log("asteroid" + numMaterialCollected + ":carbon");
        AnimationManager.instance.carbonHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.carbonHitExplosion.Play();


    }
	void addOxygen(GameObject gameObject) {
        userMixture.Add("oxygen");
        Debug.Log("asteroid" + numMaterialCollected + ":oxygen");
        AnimationManager.instance.oxygenHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.oxygenHitExplosion.Play();

    }
	void addHydrogen(GameObject gameObject) {
        userMixture.Add("hydrogen");
        Debug.Log("asteroid" + numMaterialCollected + ":hydrogen");
        AnimationManager.instance.hydrogenHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.hydrogenHitExplosion.Play();


    }
	void addSulfur(GameObject gameObject) {
        userMixture.Add("sulfur");
        Debug.Log("asteroid" + numMaterialCollected + ":sulfur");
        AnimationManager.instance.sulfurHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.sulfurHitExplosion.Play();
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

		SceneManager.LoadScene("VFX_29Feb_Dust_Effect");
        //SceneManager.LoadScene(restartSceneName);
    }

	void Update() {
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			reStart();
			canRestart = false;
		}

	}

}
