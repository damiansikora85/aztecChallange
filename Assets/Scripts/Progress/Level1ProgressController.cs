using UnityEngine;
using System.Collections;

public class Level1ProgressController : ProgressController
{
	public Animator pyramideAnimator;
	public int animationSteps;

	private string[] animatorTriggers = { "progress1", "progress2", "progress3" };
	private int currentStage;
	private float progressCheckpoint;


	// Use this for initialization
	public override void Start()
	{
		base.Start();

		currentStage = 0;

		progressCheckpoint = TotalLevelTime / 3.0f;

		//TotalLevelTime / animationSteps;
	}

	void AnimatePyramide()
	{
		pyramideAnimator.SetTrigger(animatorTriggers[currentStage]);
		currentStage++;
	}

	// Update is called once per frame
	public override void UpdateProgress(float dt)
	{
		base.UpdateProgress(dt);

		if (currentLevelTime > progressCheckpoint)
		{
			AnimatePyramide();
			progressCheckpoint += TotalLevelTime / 3.0f;
		}
	}
}
