
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public UnityEngine.UI.Text debugText;

	public BoxCollider2D runCollider;
	public BoxCollider2D downCollider;
	
	private Animator animator;
	private SpearScript hitSpear;
	private bool isHit;
	private AudioSource hitSFX;

	private PlayerCallbacks callbacks;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		hitSFX = GetComponent<AudioSource>();
		isHit = false;

		callbacks = GetComponentInChildren<PlayerCallbacks>();

		if (callbacks)
			callbacks.OnPlayerHit.AddListener(OnHit);
	}


	// Update is called once per frame
	void Update () 
	{

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

	public void OnFinish()
	{

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		OnHit(coll);
	}

	public void OnHit(Collision2D coll)
	{
		if (isHit)
			return;

		isHit = true;

		hitSFX.Play();

		//stop aztec animation

		animator.SetTrigger("kill");

		hitSpear = coll.gameObject.GetComponent<SpearScript>();
		//hitSpear.AnimationPause();
		hitSpear.StopAndStickToObject(transform);

		//hitSpear.gameObject.transform.SetParent(gameObject.transform, true);

		GameManager.Instance.Level.OnHit();
	}

	public void DownEnd()
	{
		runCollider.enabled = true;
		downCollider.enabled = false;

		animator.SetTrigger("reset");
	}

	public void JumpEnd()
	{
		animator.SetTrigger("reset");
	}

	public void Restart()
	{
		isHit = false;
		animator.speed = 1.0f;
		animator.CrossFade("test2", 0f);
		hitSpear.Reset();
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
