using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Called every frame
	//void Update()
	//{	}
	public Text countText;
	public Text winText;
	public GameObject but;
	public float speed;
	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		but = GameObject.FindWithTag ("Back To Menu");
		but.gameObject.SetActive (false);

		SetCountText ();
		winText.text = " ";


	}

	void Update()
	{
		if (Input.GetKeyDown("escape"))
			but.gameObject.SetActive (true);
	}
		
	//called before any physics calculation
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); // X
		float moveVertical = Input.GetAxis ("Vertical"); // Z
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	//Makes the Pickups collectible
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
		
			SetCountText ();
		
		}
		
	}
	void SetCountText()
	{
		countText.text = "Count: = " + count.ToString ();
		if (count >= 13) 
		{
			but.gameObject.SetActive (true);
			winText.text = "You Win!";
		
		}
	}
}
//Destroy (other.gameObject);
//if(other.gameObject.CompareTag("Player")) cpmpares tag with a string value
	//gameObject.SetActive(false);  activates or deactivates an object	