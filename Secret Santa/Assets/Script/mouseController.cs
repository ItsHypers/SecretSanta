using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseController: MonoBehaviour { [SerializeField] private List < AudioClips > audiofiles = new List < AudioClips > ();
	private AudioSource AudioS;
	private int sounds;
    private float pitch;
    private float pan;
	void OnMouseDown() {
		sounds = Random.Range(0, audiofiles.Count);
        pitch = Random.Range(0.2f, 1.0f);
        pan = Random.Range(-1.0f, 1.0f);
		AudioS = GetComponent < AudioSource > ();
        AudioS.pitch = pitch;
        AudioS.panStereo = pan;
		AudioS.PlayOneShot(audiofiles[sounds].audio);	

	} 
    
    [System.Serializable]
	public class AudioClips { [SerializeField] public AudioClip audio;
	}
}