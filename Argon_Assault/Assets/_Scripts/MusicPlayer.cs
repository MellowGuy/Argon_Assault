using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{ 
	// Awake
	void Awake()
	{
		int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
		if (numMusicPlayers > 1)
		{
			Destroy(gameObject);
		}
		//singleton pattern
		DontDestroyOnLoad(gameObject);
	}
}
