using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour
{
    public GameObject optionsMenu;
    public AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (optionsMenu.activeSelf)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
	}
}
