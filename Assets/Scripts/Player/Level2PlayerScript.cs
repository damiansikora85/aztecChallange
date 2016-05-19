using UnityEngine;
using System.Collections;

public class Level2PlayerScript : BasePlayerScript
{
	//private PlayerCallbacks callbacks;

	private bool canMove;

	// Use this for initialization
	public override void Start ()
	{
		base.Start();

		if (animator == null)
			animator = GetComponentInChildren<Animator>();

		canMove = true;

		/*callbacks = GetComponentInChildren<PlayerCallbacks>();

		if (callbacks)
			callbacks.OnPlayerHit.AddListener(OnHit);*/
	}

	public override void OnHit(Collider2D coll)
	{
		base.OnHit(coll);

		canMove = false;
	}

	public void MoveLeft()
	{
		if(canMove)
			transform.position -= new Vector3(0.01f, 0, 0);
	}

	public void MoveRight()
	{
		if (canMove)
			transform.position += new Vector3(0.01f, 0, 0);
	}

	public override void Restart()
	{
		base.Restart();

		animator.CrossFade("run", 0f);
		canMove = true;
	}
}
