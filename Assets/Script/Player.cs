using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float nextTime;
	public float interval = 1.0f;   // “_–ÅŽüŠú

	// Use this for initialization
	void Start()
	{
		nextTime = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		
		
		var renderComponent = GetComponent<Renderer>();
		renderComponent.enabled = !renderComponent.enabled;
		renderComponent.enabled = !renderComponent.enabled;
		renderComponent.enabled = !renderComponent.enabled;
		renderComponent.enabled = !renderComponent.enabled;

	}
}
