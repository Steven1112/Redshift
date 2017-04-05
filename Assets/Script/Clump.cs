using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{
	ColourMixer colourMixer;
	int numCollision;
	Vector3 velocity;
	Vector3 scale;
	GameObject planet;
	GameObject asteroid;

	Vector3 planetScale;
	double planetScaleInc;

	Vector3 asteroidScale;
	double asteroidScaleDec;

	Vector3 planetCenter;

	public AudioClip colSound;

	void Start()
	{
		colourMixer = UnityEngine.GameObject.FindGameObjectWithTag("colourMixer").GetComponent<ColourMixer>();
	}

	void OnCollisionEnter(Collision col)
	{

		if (string.Equals(col.gameObject.tag, "protoplanet"))
		{
			switch (numCollision)
			{
			case 0:

				Debug.Log ("collision " + numCollision + " happened");

				planet = col.gameObject;
				planetCenter = planet.transform.position;

				asteroid = gameObject;
				asteroid.GetComponent<SphereCollider> ().radius /= 3.0f;
				Vector3 velocity = new Vector3 (planetCenter.x - asteroid.transform.position.x, planetCenter.y - asteroid.transform.position.y, planetCenter.z - asteroid.transform.position.z);
				asteroid.GetComponent<Rigidbody>().velocity = velocity;

				planetScale = planet.transform.localScale;
				planetScaleInc = (double)planetScale.x * 0.00002;

				asteroidScale = asteroid.transform.localScale;
				asteroidScaleDec = (double)asteroidScale.x * 0.004;

				asteroid.transform.parent = planet.transform;

				PlanetCreator.instance.addMaterial(gameObject);
				colourMixer.MixColour(planet,asteroid);

				StartCoroutine(Replay());

				numCollision++;

				if (PlanetCreator.instance.numMaterialCollected == 3)
				{
					// destory unused asteroids
					GameObject asteroids = UnityEngine.GameObject.FindGameObjectWithTag("asteroids");
					Destroy(asteroids);
				}

				break;
			case 1:
				Debug.Log("collision " + numCollision + " happened");
				asteroid.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

				planet.GetComponent<Rigidbody>().mass += asteroid.GetComponent<Rigidbody>().mass;

				StartCoroutine(Replay());
				numCollision++;
				break;
			default:
				// do nothing
				break;
			}
		}
	}

	void Update()
	{

		scale = gameObject.transform.localScale;
		if (numCollision == 2)
		{
			if (hasScale(scale))
			{
				if (planet != null)
				{
					absorb(planet, asteroid);
					increaseSpin();
				}
			}
			else
			{
				Destroy(asteroid);

				if(PlanetCreator.instance.numMaterialCollected == 3){

					Debug.Log("The third asteroid is completely absorbed");
					PlanetCreator.instance.lastAbsorbed();
					PlanetCreator.instance.canRestart = true;
				}
			}
		}
	}

	bool hasScale(Vector3 scale)
	{
		return (scale.x > 0 && scale.y > 0 && scale.z > 0);
	}

	void absorb(GameObject planet, GameObject asteroid)
	{
		asteroid.transform.parent = null;
		planet.transform.localScale += new Vector3((float) planetScaleInc, (float) planetScaleInc, (float) planetScaleInc);
		asteroid.transform.localScale -= new Vector3((float)asteroidScaleDec, (float)asteroidScaleDec, (float)asteroidScaleDec);
		asteroid.transform.parent = planet.transform;
	}

	IEnumerator Replay()
	{
		yield return new WaitForSeconds(2);
	}

	void increaseSpin() {
		planet.GetComponent<Spin>().speed += 0.007f;
	}

}