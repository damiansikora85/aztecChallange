
using UnityEngine;
using System.Collections;

public class BasePlayerScript : MonoBehaviour 
{
	public UnityEngine.UI.Text debugText;

	
	
	protected Animator animator;
	
	private bool isHit;
	private AudioSource hitSFX;

	// Use this for initialization
	public virtual void Start () 
	{
		hitSFX = GetComponent<AudioSource>();
		isHit = false;
	}


	

	public void OnFinish()
	{

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		OnHit(coll);
	}

	public virtual void OnHit(Collision2D coll)
	{
		if (isHit)
			return;

		isHit = true;

		hitSFX.Play();

		//stop aztec animation

		animator.SetTrigger("kill");

		

		//hitSpear.gameObject.transform.SetParent(gameObject.transform, true);

		GameManager.Instance.Level.OnHit();
	}

	public virtual void Restart()
	{
		isHit = false;
		animator.speed = 1.0f;
		animator.CrossFade("test2", 0f);
		
	}

	
}
