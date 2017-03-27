using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetCreator : MonoBehaviour {
	public GameObject lava;

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

	public PlanetCollection collectionBook;

    [Header("Sound Triggers")]
	public AudioClip backgroundSound;
    public AudioClip colOxygenSound;
    public AudioClip colSulfurSound;
    public AudioClip colCarbonSound;
    public AudioClip colNitrogenSound;
    public AudioClip colHydrogenSound;
    public AudioClip transformingSound;


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

		// reloads collection book for each planet creator instance
		collectionBook = UnityEngine.GameObject.FindGameObjectWithTag("Collection").GetComponent<PlanetCollection>();
		collectionBook.ReloadCollectionBook();

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
        Formation venus = new Formation("venus", venusIngredients, Resources.Load("venus") as GameObject);
		Formation earth = new Formation("earth", earthIngredients, Resources.Load("earth") as GameObject);
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

		protoPlanet.GetComponent<Animator> ().enabled = false;
		GameObject bigAsteroids = UnityEngine.GameObject.FindGameObjectWithTag ("bigAsteroids");
		bigAsteroids.gameObject.GetComponent<Animator> ().enabled = false;
		//lava.GetComponent<Animator> ().enabled = false;

		SoundManager.instance.playBackgroundSound ("backgroundSound", backgroundSound);

    }

    public void addMaterial(GameObject gameObject) {

        string material = gameObject.tag;

        AnimationManager.instance.visualEffectsClearAll();


        if (string.Equals(material, "common"))
        {
            AnimationManager.instance.commonHitExplosion.transform.position = gameObject.transform.position;
            AnimationManager.instance.commonHitExplosion.Play();
		}
		else if (string.Equals(material, "nitrogen"))
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

        //SoundManager.instance.playSingle("effectSource",clickSound);
        if (numMaterialCollected < MAX_NUM_MATERIAL && !userMixture.Contains(material) && material!= "common")
		{
			numMaterialCollected++;
			userMixture.Add (material);

            // update Asteroid Tracking UI
            GameObject curAsteroid = asteroidTracking [numMaterialCollected - 1];
			Sprite asteroidImage = Resources.Load<Sprite> (material + "_2D") as Sprite;
			curAsteroid.GetComponent<Image> ().enabled = true;
			curAsteroid.GetComponent<Image> ().sprite = asteroidImage;
			curAsteroid.transform.GetChild (0).GetComponent<Text> ().text = material;

			growSize();
		}


		if (numMaterialCollected == 3) {
			//computeResult(userMixture).form(protoPlanet);
            AnimationManager.instance.playSingle("transformingSound", transformingSound);
			//PullinScript.instance.asteroidPullin.Play("AsteroidPullin");
            StartCoroutine(stopSound());
        }

    }
	void addNitrogen(GameObject gameObject) {
        AnimationManager.instance.nitrogenHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.nitrogenHitExplosion.Play();
        SoundManager.instance.playSingle("explosionNitrogen", colNitrogenSound);

    }
	void addCarbon(GameObject gameObject)
    {
        AnimationManager.instance.carbonHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.carbonHitExplosion.Play();
        SoundManager.instance.playSingle("explosionCarbon", colCarbonSound);

    }
	void addOxygen(GameObject gameObject) {
        AnimationManager.instance.oxygenHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.oxygenHitExplosion.Play();
        SoundManager.instance.playSingle("explosionOxygen", colOxygenSound);

    }
	void addHydrogen(GameObject gameObject) {
        AnimationManager.instance.hydrogenHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.hydrogenHitExplosion.Play();
        SoundManager.instance.playSingle("explosionHydrogen", colHydrogenSound);

    }
	void addSulfur(GameObject gameObject) {
        AnimationManager.instance.sulfurHitExplosion.transform.position = gameObject.transform.position;
        AnimationManager.instance.sulfurHitExplosion.Play();
        SoundManager.instance.playSingle("explosionSulfur", colSulfurSound);


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

		SceneManager.LoadScene("Scene_27Mar_Master");
        //SceneManager.LoadScene(restartSceneName);
    }

	void Update() {
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			reStart();
			canRestart = false;
		}

	}

    IEnumerator stopSound()
    {
        yield return new WaitForSeconds(7);
        AnimationManager.instance.stopSingle("transformingSound", transformingSound);
    }

}
