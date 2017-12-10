﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 12;

	ScoreBoard scoreBoard;

	// Use this for initialization
	void Start()
	{
		AddBoxCollider();
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}

	private void AddBoxCollider()
	{
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
		scoreBoard.ScoreHit(scorePerHit);
	}
}
