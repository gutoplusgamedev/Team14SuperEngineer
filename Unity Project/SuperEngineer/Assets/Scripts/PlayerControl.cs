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
		get { return Physics.Raycast (transform.position, -Vector3.up, 2f); }
	}

	void Awake()
	{
		animation ["Jump"].speed = 0.5f;
		PlayerInstance = this;
		GapDetector.OnPlayerCollision += OnPlayerCollidedWithGap;
	}

	void OnDisable ()
	{
		GapDetector.OnPlayerCollision -= OnPlayerCollidedWithGap;
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

		if (Input.GetKeyDown (KeyCode.W) && this.IsGrounded) 
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

	void OnPlayerCollidedWithGap ()
	{
		StartCoroutine (OnDie ());
	}

	IEnumerator OnDie ()
	{
		this.enabled = false;
		yield return new WaitForSeconds (1);
		GameOver.OnGameOver ();
	}
}
