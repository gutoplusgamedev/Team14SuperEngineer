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

	public void ChangeRagdoll (bool state)
	{
		Rigidbody[] rbs = GetComponentsInChildren<Rigidbody> ();
		Collider[] cs = GetComponentsInChildren <Collider> ();
		CharacterJoint[] joints = GetComponentsInChildren <CharacterJoint> ();
		foreach (Rigidbody r in rbs) 
		{
			if (r.gameObject.tag != "CharRoot")
				r.useGravity = state;
		}

		foreach (Collider c in cs) 
		{
			if(c.gameObject.tag != "CharRoot")
				c.enabled = state;
		}

	}

	void Awake()
	{
		ChangeRagdoll (false);
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
		ChangeRagdoll (true);
		this.enabled = false;
		yield return new WaitForSeconds (4);
		GameOver.OnGameOver ();
	}
}
