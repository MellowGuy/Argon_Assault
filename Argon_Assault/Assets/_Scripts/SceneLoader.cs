using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	//Amount of time to wait in seconds
	public float waitTime = 3f;

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
