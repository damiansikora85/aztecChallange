using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour
{
	public Vector2 stickTransform;
	private Animator animator;
	private Transform originalParent;
	private AnimatorStateInfo state;

	void Start()
	{
		animator = GetComponent<Animator>();
		originalParent = transform.parent;
	}

	public void AnimationFinished()
	{
		animator.speed = 1.0f;
		animator.SetTrigger("reset");
	}


	public void StopAndStickToObject(Transform objTransform)
	{
		GetComponent<Rigidbody2D>().isKinematic = true;
		//animator.speed = 0.0f;
		animator.enabled = false;
		//state = animator.GetCurrentAnimatorStateInfo(0);
		//animator.StopPlayback();
		transform.SetParent(objTransform, true);
		//stickTransform.x = transform.position.x;
		//transform.localPosition = stickTransform;
	}

	public void Reset()
	{
		animator.enabled = true;
		//animator.speed = 1.0f;
		
		transform.SetParent(originalParent);//, true);

		GetComponent<Rigidbody2D>().isKinematic = false;

		animator.SetTrigger("reset");
	}
	
}
