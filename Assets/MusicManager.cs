using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource EffectsSource;
	public AudioSource MusicSource;
    public static MusicManager Instance = null;
    public AudioClip CheerMusic;
    private void Awake() {
        if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
    }
    public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}
	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}
    // Start is called before the first frame update
    void Start()
    {
       PlayMusic(CheerMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    	// Play a single clip through the sound effects source.

}