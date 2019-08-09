using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public List<AudioClip> clips = new List<AudioClip>();
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayAudio(int numberOfClips)
	{
		audioSource.PlayOneShot(clips[numberOfClips]);
	}
}