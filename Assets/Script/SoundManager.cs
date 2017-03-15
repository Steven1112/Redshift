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
    public AudioSource transformingSound;
    public AudioSource triggerUISound;

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
            explosionOxygen.volume = 1;
            explosionOxygen.Play();
            Debug.Log("is playing the oxygen explosion sound!");
        }
        if (audioSource == "explosionSulfur")
        {
            explosionSulfur.clip = sound;
            explosionSulfur.volume = 1;
            explosionSulfur.Play();
            Debug.Log("is playing the sulfur explosion sound!");
        }
        if (audioSource == "explosionCarbon")
        {
            explosionCarbon.clip = sound;
            explosionCarbon.volume = 1;
            explosionCarbon.Play();
            Debug.Log("is playing the carbon explosion sound!");
        }
        if (audioSource == "explosionNitrogen")
        {
            explosionNitrogen.clip = sound;
            explosionNitrogen.volume = 1;
            explosionNitrogen.Play();
            Debug.Log("is playing the nitrogen explosion sound!");
        }
        if (audioSource == "explosionHydrogen")
        {
            explosionHydrogen.clip = sound;
            explosionHydrogen.volume = 1;
            explosionHydrogen.Play();
            Debug.Log("is playing the hydrogen explosion sound!");
        }
        if (audioSource == "transformingSound")
        {
            transformingSound.clip = sound;
            transformingSound.volume = 1;
            transformingSound.Play();
            Debug.Log("is playing the transforming sound!");
        }
        if (audioSource == "triggerUISound")
        {
            triggerUISound.clip = sound;
            triggerUISound.volume = 1;
            triggerUISound.Play();
            Debug.Log("is playing the trigger UI sound!");
        }
        else
        {
            //
        }
    }

    public void stopSingle(string audioSource, AudioClip sound)
    {
        if (audioSource == "transformingSound")
        {
            transformingSound.clip = sound;
            transformingSound.Stop();
            Debug.Log("is stoping the transforming sound!");
        }
        if (audioSource == "triggerUISound")
        {
            triggerUISound.clip = sound;
            triggerUISound.Stop();
            Debug.Log("is stopping the trigger UI sound!");
        }
        else
        {
            //
        }
    }
}
