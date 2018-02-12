using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public Vector3 direction;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;

	}
	
	// Late Update is called once per frame after everything else
	void LateUpdate () {
		transform.position = transform.forward + player.transform.position + offset;
	}
}
