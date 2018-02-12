using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondController : MonoBehaviour {


	public float speed;
	public float gravity;
	public float jumpHeight;
	public LayerMask ground;
	public Transform feet;
	public GameObject wall;
	public GameObject button;
	public Text winText;


	private Vector3 direction;
	private Vector3 walkingVelocity;
	private Vector3 fallingVelocity;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		gravity = 9.8f;
		direction = Vector3.zero;
		fallingVelocity = Vector3.zero;
		controller = GetComponent<CharacterController> ();
		button.gameObject.SetActive (false);
		winText.text = " ";

	}
	
	// Update is called once per frame
	void Update () {
		direction.x = Input.GetAxis ("Horizontal");
		direction.z = Input.GetAxis ("Vertical");
		direction = direction.normalized;
		walkingVelocity = direction * speed;
		controller.Move (walkingVelocity * Time.deltaTime);
		if (direction != Vector3.zero) 
			{
				transform.forward = direction;
				Debug.Log (direction);
			}
		bool isGrounded = Physics.CheckSphere (feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
		if (isGrounded) 
			{
				fallingVelocity.y = 0f;
			} 
		else 
			{
				fallingVelocity.y -= gravity * Time.deltaTime;
			}
		if (Input.GetButtonDown ("Jump") && isGrounded) 
			{
				fallingVelocity.y = Mathf.Sqrt (gravity * jumpHeight);
			}
			
		controller.Move(fallingVelocity * Time.deltaTime);

		if (Input.GetKeyDown("escape"))
			button.gameObject.SetActive (true);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			wall.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("Finish")) 
		{
			other.gameObject.SetActive (false);
			winText.text = "You Win!";
			button.gameObject.SetActive (true);

		}
	}
}
