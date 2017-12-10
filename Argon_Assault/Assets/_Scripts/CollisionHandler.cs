using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

	[Tooltip("Inseconds")] [SerializeField] float levelLoadDelay = 1f;
	[Tooltip("Explosion partical effect")]	[SerializeField] GameObject deathFX;

	void Start()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		print("Triggered with " + other.gameObject.name);
		StartDeathSequence();
	}

	private void StartDeathSequence()
	{
		print("Death Sequence started");
		SendMessage("OnPlayerDeath");
		deathFX.SetActive(true);
		Invoke("ReloadScene", levelLoadDelay);
	}

	void ReloadScene() //String referenced
	{
		SceneManager.LoadScene(1);
	}
}
