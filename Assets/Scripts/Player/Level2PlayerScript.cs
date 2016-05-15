using UnityEngine;
using System.Collections;

public class Level2PlayerScript : BasePlayerScript
{
	private PlayerCallbacks callbacks;

	// Use this for initialization
	public override void Start ()
	{
		base.Start();

		if (animator == null)
			animator = GetComponentInChildren<Animator>();

		callbacks = GetComponentInChildren<PlayerCallbacks>();

		if (callbacks)
			callbacks.OnPlayerHit.AddListener(OnHit);
	}

	public void MoveLeft()
	{
		transform.position -= new Vector3(0.01f, 0, 0);
	}

	public void MoveRight()
	{
		transform.position += new Vector3(0.01f, 0, 0);
	}
}
