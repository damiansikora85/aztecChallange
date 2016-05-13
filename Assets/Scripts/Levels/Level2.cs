using UnityEngine;
using System.Collections;

public class Level2 : LevelLogic
{
	public override void OnTouchLeft()
	{
		base.OnTouchLeft();

		Player.MoveLeft();
	}

	public override void OnTouchRight()
	{
		base.OnTouchRight();

		Player.MoveRight();
	}
}
