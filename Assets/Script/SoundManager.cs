using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource effectSource;

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
    }

    public void playSingle(string audioSource, AudioClip sound)
    {
        if (audioSource == "effectSource")
        {
            effectSource.clip = sound;
            effectSource.Play();
            Debug.Log("is playing some sound!");
        }else
        {
            //
        }
    }
}
