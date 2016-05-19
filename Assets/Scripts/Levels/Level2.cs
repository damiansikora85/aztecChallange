using UnityEngine;
using System.Collections;

public class Level2 : LevelLogic
{
	public Scroller StairsScroll;
	public BoulderSpawner BoulderSpawner;

	public override void OnTouchLeft()
	{
		base.OnTouchLeft();
		Level2PlayerScript pl2 = Player as Level2PlayerScript;
		pl2.MoveLeft();
	}

	public override void OnTouchRight()
	{
		base.OnTouchRight();
		Level2PlayerScript pl2 = Player as Level2PlayerScript;
		pl2.MoveRight();
	}

	public override void OnHit()
	{
		base.OnHit();

		StairsScroll.SetEnable(false);
		BoulderSpawner.SetEnable(false);
	}

	public override void Restart()
	{
		base.Restart();

		StairsScroll.SetEnable(true);
		BoulderSpawner.SetEnable(true);
	}
}
