using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource efxSource;
	public AudioClip btnSfx;
	public AudioClip timeSfx;

	void Awake () {

		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		
	}
	public void PlaySingle(AudioClip clip,float vol=1f)
	{
		if (GameManager.Sound && clip !=null) {
			AudioSource.PlayClipAtPoint (clip, Camera.main.transform.position, vol);
		}
		if (clip !=null)
		{

		}
	}
	public void PlayTimerSound()
	{
		if (GameManager.Sound) {
			efxSource.clip = timeSfx;
			efxSource.Play ();
		}
	}
	public void StopTimerSound(){
		efxSource.Stop ();
		efxSource.clip = null;
	}
	public void PlaybtnSfx(){
		PlaySingle (btnSfx);
	}

}
