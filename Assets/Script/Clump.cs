using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{

    int numCollision;
    Vector3 velocity;
    Vector3 scale;
    GameObject planet;
    GameObject asteroid;
    //GameObject sparkle;

    Vector3 planetScale;
    double planetScaleInc;

    Vector3 asteroidScale;
    double asteroidScaleDec;

	Vector3 planetCenter;

    public AudioClip colSound;
    //public AnimationManager animationManager;

    void OnCollisionEnter(Collision col)
    {
        /*
        Debug.Log("Tag name:" + col.gameObject.tag);
        if (string.Equals(col.gameObject.tag, "bigasteroid"))
        {
            AnimationManager.instance.hitBigAsteroid.Play();
            Debug.Log("asteroid hit the big asteroid collision happened");
            StartCoroutine(ClearBackendEffect());
        }

        */

        if (string.Equals(col.gameObject.tag, "protoplanet"))
        {
            switch (numCollision)
            {
			case 0:
				//SoundManager.instance.playSingle ("effectSource", colSound);
				Debug.Log ("collision " + numCollision + " happened");

				planet = col.gameObject;
				planetCenter = planet.transform.position;
				//planet.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 100, 0);

				asteroid = gameObject;
				asteroid.GetComponent<SphereCollider> ().radius /= 3.0f;
				Vector3 velocity = new Vector3 (planetCenter.x - asteroid.transform.position.x, planetCenter.y - asteroid.transform.position.y, planetCenter.z - asteroid.transform.position.z);
				Debug.Log (velocity);
				asteroid.GetComponent<Rigidbody>().velocity = velocity;

                    planetScale = planet.transform.localScale;
                    planetScaleInc = (double)planetScale.x * 0.00002;

                    asteroidScale = asteroid.transform.localScale;
                    asteroidScaleDec = (double)asteroidScale.x * 0.00004;

				    asteroid.transform.parent = planet.transform;
				    //PlanetCreator.instance.collected[PlanetCreator.instance.numMaterialCollected] = asteroid;

                    //call addMaterial() and collision parameters to be passed for visual effects
                    PlanetCreator.instance.addMaterial(gameObject);

                    //AnimationManager.instance.asteroidExplosion.Play();

                    StartCoroutine(Replay());

                    numCollision++;

                    if (PlanetCreator.instance.numMaterialCollected == 3)
                    {
                        // destory unused asteroids
                        GameObject asteroids = UnityEngine.GameObject.FindGameObjectWithTag("asteroids");
                        Destroy(asteroids);
                        AnimationManager.instance.playAsteroidPullinEffect();
                    }

                    break;
                case 1:
                    //sparkle = (GameObject)Instantiate(Resources.Load("sparkle"));
                    //sparkle.transform.position = asteroid.transform.position;
                    //sparkle.transform.SetParent(asteroid.transform);
                    Debug.Log("collision " + numCollision + " happened");
                    asteroid.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                    planet.GetComponent<Rigidbody>().mass += asteroid.GetComponent<Rigidbody>().mass;

				    // AnimationManager.instance.simpleExplosion.Play();
                    StartCoroutine(Replay());
                    numCollision++;

				if(PlanetCreator.instance.numMaterialCollected == 3){
					//AnimationManager.instance.playFormationEffect();
				}

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
					//AnimationManager.instance.seeResults.Stop();
					PlanetCreator.instance.canRestart = true;
				}
            }
        }
        /*
        if (sparkle != null) {
            sparkle.transform.localScale = asteroid.transform.localScale;
        }
        */
    }

    bool hasScale(Vector3 scale)
    {
        if (scale.x > 0 && scale.y > 0 && scale.z > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void absorb(GameObject planet, GameObject asteroid)
    {
		//Debug.Log("absorbing...");
		asteroid.transform.parent = null;
        planet.transform.localScale += new Vector3((float) planetScaleInc, (float) planetScaleInc, (float) planetScaleInc);
        asteroid.transform.localScale -= new Vector3((float)asteroidScaleDec, (float)asteroidScaleDec, (float)asteroidScaleDec);
		asteroid.transform.parent = planet.transform;
    }

    IEnumerator Replay()
    {
        yield return new WaitForSeconds(2);
        //AnimationManager.instance.asteroidExplosion.Stop();
        AnimationManager.instance.commonHitExplosion.Stop();
        // soundManager.hitOn.Stop();
    }

    void increaseSpin() {
		planet.GetComponent<Spin>().speed += 0.007f;
	}

    IEnumerator ClearBackendEffect()
    {
        yield return new WaitForSeconds(1.5f);
        AnimationManager.instance.hitBigAsteroid.Stop();
    }
}

