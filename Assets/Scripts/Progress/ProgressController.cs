using UnityEngine;
using System.Collections;

public class ProgressController : MonoBehaviour
{
	public int TotalLevelTime;

	public float CurrentProgress
	{
		get { return currentLevelTime / TotalLevelTime * 100; }
	}

	public bool IsFinished
	{
		get { return currentLevelTime > TotalLevelTime; }
	}
	
	protected float currentLevelTime;



	// Use this for initialization
	public virtual void Start ()
	{

	}

	
	// Update is called once per frame
	public virtual void UpdateProgress (float dt)
	{
		currentLevelTime += dt;
	}
}
