using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray [level];

		if (thisLevelMusic) { // Si hay musica cargada
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
}
