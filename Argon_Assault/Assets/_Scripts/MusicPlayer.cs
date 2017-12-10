using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

	public float waitTime = 3f;

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

	// Use this for initialization
	void Start()
	{
		Invoke("LoadFirstScene", waitTime);
	}

	void LoadFirstScene()
	{
		SceneManager.LoadScene(1);
		Debug.Log("Scene Loaded");
	}
}
