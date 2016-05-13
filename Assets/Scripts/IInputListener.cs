using UnityEngine;
using System.Collections;

public interface IInputListener
{
	void OnSwipeUp();
	void OnSwipeDown();
	void OnSwipeLeft();
	void OnSwipeRight();
	void OnTap();
	void OnTouchLeft();
	void OnTouchRight();

}
