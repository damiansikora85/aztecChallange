using UnityEngine;
using System.Collections;

public class Level1PlayerScript : BasePlayerScript
{
	public BoxCollider2D runCollider;
	public BoxCollider2D downCollider;

	private SpearScript hitSpear;

	public override void Start()
	{
		base.Start();

		animator = GetComponent<Animator>();

	}

	public override void OnHit(Collision2D coll)
	{
		base.OnHit(coll);

		animator.ResetTrigger("down");
		animator.ResetTrigger("jump");

		hitSpear = coll.gameObject.GetComponent<SpearScript>();
		//hitSpear.AnimationPause();
		hitSpear.StopAndStickToObject(transform);
	}

	public override void Restart()
	{
		base.Restart();

		hitSpear.Reset();
	}

	public void OnDown()
	{
		animator.SetTrigger("down");
		runCollider.enabled = false;
		downCollider.enabled = true;
	}

	public void OnJump()
	{
		animator.SetTrigger("jump");
	}

	public void DownEnd()
	{
		runCollider.enabled = true;
		downCollider.enabled = false;

		animator.ResetTrigger("down");
		animator.ResetTrigger("jump");
		animator.SetTrigger("reset");
	}

	public void JumpEnd()
	{
		animator.ResetTrigger("down");
		animator.ResetTrigger("jump");
		animator.SetTrigger("reset");
	}
}
