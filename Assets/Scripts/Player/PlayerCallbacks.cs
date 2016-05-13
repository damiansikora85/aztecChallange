using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class CustomEvent : UnityEvent<Collision2D>
{
}

public class PlayerCallbacks : MonoBehaviour
{
	public UnityEvent OnJumpFinished;
	public UnityEvent OnDownFinished;
	public CustomEvent OnPlayerHit;

	void Start()
	{
		OnPlayerHit = new CustomEvent();
	}

	public void OnJumpAnimFinished()
	{
		OnJumpFinished.Invoke();
	}

	public void OnDownAnimFinished()
	{
		OnDownFinished.Invoke();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		OnPlayerHit.Invoke(coll);
	}
}
