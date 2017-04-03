using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public AudioSource voiceOverSource;
	public AudioSource backgroundSound;
    public AudioSource explosionOxygen;
    public AudioSource explosionSulfur;
    public AudioSource explosionCarbon;
    public AudioSource explosionNitrogen;
    public AudioSource explosionHydrogen;
    public AudioSource triggerUISound;
    public AudioSource teleportSound;
    public AudioSource pickupSound;
    public AudioSource throwingSound;
	public AudioSource effectSource;
	public AudioSource hitAsteroidSound;


    public static SoundManager instance = null;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);

       // explosionOxygen = GetComponent<AudioSource>();
    }

    public void playSingle(string audioSource, AudioClip sound)
    {
		if(audioSource == "voiceOverSource"){
			voiceOverSource.clip = sound;
			voiceOverSource.Play ();
		}
        if (audioSource == "explosionOxygen")
        {
            explosionOxygen.clip = sound;
            explosionOxygen.volume = 1f;
            explosionOxygen.Play();
			explosionOxygen.loop = false;
            Debug.Log("is playing the oxygen explosion sound!");
        }
        if (audioSource == "explosionSulfur")
        {
            explosionSulfur.clip = sound;
			explosionSulfur.volume = 1f;
            explosionSulfur.Play();
			explosionSulfur.loop = false;
            Debug.Log("is playing the sulfur explosion sound!");
        }
        if (audioSource == "explosionCarbon")
        {
            explosionCarbon.clip = sound;
			explosionCarbon.volume = 1f;
            explosionCarbon.Play();
			explosionCarbon.loop = false;
            Debug.Log("is playing the carbon explosion sound!");
        }
        if (audioSource == "explosionNitrogen")
        {
            explosionNitrogen.clip = sound;
			explosionNitrogen.volume = 1f;
            explosionNitrogen.Play();
			explosionNitrogen.loop = false;
            Debug.Log("is playing the nitrogen explosion sound!");
        }
        if (audioSource == "explosionHydrogen")
        {
            explosionHydrogen.clip = sound;
			explosionHydrogen.volume = 1f;
            explosionHydrogen.Play();
			explosionHydrogen.loop = false;
            Debug.Log("is playing the hydrogen explosion sound!");
        }
        if (audioSource == "triggerUISound")
        {
            triggerUISound.clip = sound;
			triggerUISound.volume = 0.2f;
            triggerUISound.Play();
			triggerUISound.loop = false;
            Debug.Log("is playing the trigger UI sound!");
        }
        if (audioSource == "teleportSound")
        {
            teleportSound.clip = sound;
            teleportSound.volume = 0.2f;
            teleportSound.Play();
            teleportSound.loop = false;
            Debug.Log("is playing the teleporting sound!");
        }
        if (audioSource == "pickupSound")
        {
            pickupSound.clip = sound;
            pickupSound.volume = 0.05f;
            pickupSound.Play();
            pickupSound.loop = false;
            Debug.Log("is playing the pickup asteroid sound!");
        }
        if (audioSource == "throwingSound")
        {
            throwingSound.clip = sound;
            throwingSound.volume = 0.4f;
            throwingSound.Play();
            throwingSound.loop = false;
            Debug.Log("is playing the throwing asteroid sound!");
        }
		if (audioSource == "effectSource") {
			effectSource.clip = sound;
			effectSource.Play();
		}
        else
        {
            //
        }
    }

    public void stopSingle(string audioSource, AudioClip sound)
    {
        if (audioSource == "triggerUISound")
        {
            triggerUISound.clip = sound;
            triggerUISound.Stop();
            Debug.Log("is stopping the trigger UI sound!");
        }
        if (audioSource == "teleportSound")
        {
            teleportSound.clip = sound;
            teleportSound.volume = 0.2f;
            teleportSound.Stop();
            teleportSound.loop = false;
            Debug.Log("is stopping the teleporting sound!");
        }
		if (audioSource == "pickupSound")
		{
			pickupSound.clip = sound;
			pickupSound.volume = 0.2f;
			pickupSound.Stop();
			pickupSound.loop = false;
			Debug.Log("is stopping the pickup asteroid sound!");
		}
		if (audioSource == "throwingSound")
		{
			throwingSound.clip = sound;
			throwingSound.volume = 0.2f;
			throwingSound.Stop();
			throwingSound.loop = false;
			Debug.Log("is stopping the throwing asteroid sound!");
		}
        else
        {
            //
        }
    }

	public void playBackgroundSound(string audioSource, AudioClip sound)
	{
		if (audioSource == "backgroundSound")
		{
			backgroundSound.clip = sound;
			backgroundSound.Play();
			explosionOxygen.loop = true;
			Debug.Log("is playing the background sound!");
		}

		else
		{
			//
		}
	}

	public void playHitAsteroidSound(string audioSource, AudioClip sound)
	{
		if (audioSource == "hitAsteroidSound")
		{
			hitAsteroidSound.clip = sound;
			hitAsteroidSound.volume = 0.15f;
			hitAsteroidSound.Play();
			hitAsteroidSound.loop = false;
			Debug.Log("is playing the hitting asteroid sound!");
		}

		else
		{
			//
		}
	}

	public void stopHitAsteroidSound(string audioSource, AudioClip sound)
	{
		if (audioSource == "hitAsteroidSound")
		{
			hitAsteroidSound.clip = sound;
			hitAsteroidSound.Stop();
			Debug.Log("is stopping the hitting asteroid sound!");
		}

		else
		{
			//
		}
	}
}
