using UnityEngine;
using System.Collections;

public class Level2 : LevelLogic
{
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
}
