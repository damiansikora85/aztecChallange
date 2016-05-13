using UnityEngine;
using System.Collections;

public class LivesScript : MonoBehaviour
{
	public GameObject LiveTemplate;
	public int StartLivesNum = 3;

	public int LivesLeft
	{
		get { return livesLeft; }
	}

	private int livesLeft;

	// Use this for initialization
	void Start ()
	{
		livesLeft = StartLivesNum;

		SetupLives();
	}
	
	public void DecreaseLives()
	{
		livesLeft--;

		SetupLives();
	}

	private void SetupLives()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}

		for (int i = 0; i < livesLeft; i++)
		{
			GameObject live = Instantiate(LiveTemplate);
			live.transform.SetParent(transform, true);
		}
	}
}
