using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource explosionOxygen;
    public AudioSource explosionSulfur;
    public AudioSource explosionCarbon;
    public AudioSource explosionNitrogen;
    public AudioSource explosionHydrogen;
    public AudioSource triggerUISound;
    public AudioSource teleportSound;
    public AudioSource pickupSound;
    public AudioSource throwingSound;


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
        if (audioSource == "effectSource")
        {
            effectSource.clip = sound;
            effectSource.Play();
            Debug.Log("is playing the effect sound!");
        }
        if (audioSource == "explosionOxygen")
        {
            explosionOxygen.clip = sound;
            explosionOxygen.volume = 0.2f;
            explosionOxygen.Play();
			explosionOxygen.loop = false;
            Debug.Log("is playing the oxygen explosion sound!");
        }
        if (audioSource == "explosionSulfur")
        {
            explosionSulfur.clip = sound;
			explosionSulfur.volume = 0.2f;
            explosionSulfur.Play();
			explosionSulfur.loop = false;
            Debug.Log("is playing the sulfur explosion sound!");
        }
        if (audioSource == "explosionCarbon")
        {
            explosionCarbon.clip = sound;
			explosionCarbon.volume = 0.2f;
            explosionCarbon.Play();
			explosionCarbon.loop = false;
            Debug.Log("is playing the carbon explosion sound!");
        }
        if (audioSource == "explosionNitrogen")
        {
            explosionNitrogen.clip = sound;
			explosionNitrogen.volume = 0.1f;
            explosionNitrogen.Play();
			explosionNitrogen.loop = false;
            Debug.Log("is playing the nitrogen explosion sound!");
        }
        if (audioSource == "explosionHydrogen")
        {
            explosionHydrogen.clip = sound;
			explosionHydrogen.volume = 0.2f;
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
            pickupSound.volume = 0.2f;
            pickupSound.Play();
            pickupSound.loop = false;
            Debug.Log("is playing the pickup asteroid sound!");
        }
        if (audioSource == "throwingSound")
        {
            throwingSound.clip = sound;
            throwingSound.volume = 0.2f;
            throwingSound.Play();
            throwingSound.loop = false;
            Debug.Log("is playing the throwing asteroid sound!");
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
        else
        {
            //
        }
    }
}
