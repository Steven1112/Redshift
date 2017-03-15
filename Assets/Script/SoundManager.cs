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

        explosionOxygen = GetComponent<AudioSource>();
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
            explosionOxygen.Play();
            Debug.Log("is playing the oxygen explosion sound!");
        }
        if (audioSource == "explosionSulfur")
        {
            explosionSulfur.clip = sound;
            explosionSulfur.Play();
            Debug.Log("is playing the sulfur explosion sound!");
        }
        if (audioSource == "explosionCarbon")
        {
            explosionCarbon.clip = sound;
            explosionCarbon.Play();
            Debug.Log("is playing the carbon explosion sound!");
        }
        if (audioSource == "explosionNitrogen")
        {
            explosionNitrogen.clip = sound;
            explosionNitrogen.Play();
            Debug.Log("is playing the nitrogen explosion sound!");
        }
        if (audioSource == "explosionHydrogen")
        {
            explosionHydrogen.clip = sound;
            explosionHydrogen.Play();
            Debug.Log("is playing the hydrogen explosion sound!");
        }
        else
        {
            //
        }
    }
}
