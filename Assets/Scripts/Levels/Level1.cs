using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/*

	Music:
	Snabisch

*/

public class Level1 : LevelLogic
{
	public Projectiles Spears;
	public Animator PyramideAnimator;
	public Animator[] LeftWarriorsAnimator;
	public Animator[] RightWarriorsAnimator;


	//private bool shouldThroughSpears;
	private IEnumerator throughSpearCoroutine;



	void StartFromCheckpoint(int num)
	{
		if (num == 0)
			return;

		if (num > 4)
			return;

		Debug.Log("Continue from checkpoint");

		PlayerPrefs.DeleteKey("Continue");

		int offsetY = 0;

		switch (num)
		{
			case 1:
				offsetY = 1;
				break;
			case 2:
				offsetY = 2;
				break;
			case 3:
				offsetY = 3;
				break;
		}

		GameObject pyramide = PyramideAnimator.gameObject;
		pyramide.gameObject.transform.position = pyramide.gameObject.transform.position + new Vector3(0, offsetY, 0);
		//.position = Pyramide.transform.position + new Vector3(0, 10.0f, 0);
	}


	public override void OnHit()
	{
		base.OnHit();

		Spears.Pause();

		//screenAnimator.SetTrigger("kill");

		foreach (Animator animator in LeftWarriorsAnimator)
			animator.speed = 0.0f;

		foreach (Animator animator in RightWarriorsAnimator)
			animator.speed = 0.0f;
	}

	public override void Restart()
	{
		base.Restart();

		foreach (Animator animator in LeftWarriorsAnimator)
			animator.speed = 1.0f;

		foreach (Animator animator in RightWarriorsAnimator)
			animator.speed = 1.0f;

		Spears.Restart();
	}

	protected override IEnumerator finishLevel()
	{
		Player.OnFinish();

		StopCoroutine(throughSpearCoroutine);

		foreach (Animator animator in LeftWarriorsAnimator)
			animator.speed = 0.0f;

		foreach (Animator animator in RightWarriorsAnimator)
			animator.speed = 0.0f;

		yield return new WaitForSeconds(10);
	}

	public override void OnSwipeUp()
	{
		Level1PlayerScript pl1 = Player as Level1PlayerScript;
		pl1.OnJump();
	}

	public override void OnSwipeDown()
	{
		Level1PlayerScript pl1 = Player as Level1PlayerScript;
		pl1.OnDown();
	}

}
