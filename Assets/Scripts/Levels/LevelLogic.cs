using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/*

	Music:
	Snabisch

*/

public class LevelLogic : MonoBehaviour, IInputListener
{
	public BasePlayerScript Player;
	public Text LevelProgressTime;
	public ProgressController ProgressController;
	public HUDScript HUD;


	protected bool updateProgress;

	// Use this for initialization
	void Start()
	{
		updateProgress = true;

		//StartCoroutine("ThroughSpear");

	}

	// Update is called once per frame
	void Update()
	{
		if (updateProgress)
		{
			if (ProgressController.IsFinished)
				GameManager.Instance.LevelFinished();

			ProgressController.UpdateProgress(Time.deltaTime);
			LevelProgressTime.text = "Progress: " + ProgressController.CurrentProgress.ToString("F2") + "%";
		}
	}



	public virtual void OnHit()
	{
		updateProgress = false;


		if (HUD.LivesElement.LivesLeft > 1)
		{
			HUD.LivesElement.DecreaseLives();
			GameManager.Instance.LooseLive();
		}
		else
		{
			HUD.LivesElement.DecreaseLives();
			GameManager.Instance.GameOver();
		}
	}

	public virtual void Restart()
	{
		updateProgress = true;

		Player.Restart();
	}

	protected virtual IEnumerator finishLevel()
	{
		yield return null;
	}

	public virtual void OnSwipeUp()
	{
		//Player.OnJump();
	}

	public virtual void OnSwipeDown()
	{
		//Player.OnDown();
	}

	public virtual void OnSwipeLeft()
	{

	}

	public virtual void OnSwipeRight()
	{

	}

	public virtual void OnTap()
	{

	}

	public virtual void OnTouchLeft()
	{

	}

	public virtual void OnTouchRight()
	{

	}
}
