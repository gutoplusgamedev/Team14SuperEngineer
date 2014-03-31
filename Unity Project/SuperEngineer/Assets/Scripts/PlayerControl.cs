using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	private bool _isJumping = false;
	public float jumpForce;
	public float velocity;
	public static PlayerControl PlayerInstance;

	public bool IsGrounded 
	{
		get { return Physics.Raycast (transform.position, -Vector3.up, 1.7f); }
	}

	void Start()
	{
		animation ["Jump"].speed = 0.5f;
		PlayerInstance = this;
	}

	void Update ()
	{
		if (!_isJumping) 
		{
			animation.CrossFade ("RunCycle", 0.2f);
		}
		else 
		{
			animation.CrossFade ("Jump", 0.2f);
		}

		transform.position += Vector3.right * Time.deltaTime * velocity;

		if (Input.GetKey (KeyCode.W) && this.IsGrounded) 
		{
			StartCoroutine (Jump ());
		}
	}

	IEnumerator Jump ()
	{
		if (!_isJumping) 
		{
			_isJumping = true;
			rigidbody.velocity = new Vector3 (0, jumpForce, 0);
			yield return new WaitForSeconds (1);
			while (!this.IsGrounded)
			{
				yield return new WaitForEndOfFrame ();
			}
			_isJumping = false;
		}
	}
}
