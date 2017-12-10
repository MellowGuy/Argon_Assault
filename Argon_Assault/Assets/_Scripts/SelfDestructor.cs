using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
	[Tooltip("Seconds until Destroy() is called")] [SerializeField] int destructionDelay = 5;
	// Use this for initialization
	void Start()
	{
		Destroy(gameObject, destructionDelay);
	}
}
