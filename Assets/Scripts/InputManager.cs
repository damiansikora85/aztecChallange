using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
	private bool couldBeSwipe = false;
	private Vector2 startPos;
	private float startTime;

	public float comfortZone = 50.0f;
	public float maxSwipeTime = 1000.0f;
	public float minSwipeDist = 50.0f;

	public RectTransform LeftRectTransform;
	public RectTransform RightRectTransform;

	List<IInputListener> listeners;

	// Use this for initialization
	void Start ()
	{
		listeners = new List<IInputListener>();
	}

	public void AddListener(IInputListener listener)
	{
		listeners.Add(listener);
	}
	
	// Update is called once per frame
	void Update ()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			foreach (IInputListener listener in listeners)
				listener.OnSwipeUp();
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			foreach (IInputListener listener in listeners)
				listener.OnSwipeDown();


			//runCollider.enabled = false;
			//downCollider.enabled = true;

		}
		if (Input.GetMouseButton(0) && LeftRectTransform != null && RightRectTransform != null)
		{
			if (RectTransformUtility.RectangleContainsScreenPoint(LeftRectTransform, Input.mousePosition))
			{
				foreach (IInputListener listener in listeners)
					listener.OnTouchLeft();
			}

			if (RectTransformUtility.RectangleContainsScreenPoint(RightRectTransform, Input.mousePosition))
			{
				foreach (IInputListener listener in listeners)
					listener.OnTouchRight();
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			foreach (IInputListener listener in listeners)
				listener.OnTap();
		}


#else
		if (Input.touchCount > 0) {
			var touch = Input.touches[0];
			
			switch (touch.phase) {
			case TouchPhase.Began:
				couldBeSwipe = true;
				startPos = touch.position;
				startTime = Time.time;
				break;
				
			case TouchPhase.Moved:
				if (Mathf.Abs(touch.position.x - startPos.x) > comfortZone) 
				{
					couldBeSwipe = false;
				}
				break;

			case TouchPhase.Stationary:
				if(RectTransformUtility.RectangleContainsScreenPoint(LeftRectTransform, touch.position))
				{
					foreach (IInputListener listener in listeners)
						listener.OnTouchLeft();
				}
				break;
				
			case TouchPhase.Ended:
				var swipeTime = Time.time - startTime;
				var swipeDist = (touch.position - startPos).magnitude;
				
				if (couldBeSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)) {
					// It's a swiiiiiiiiiiiipe!
					var swipeDirection = Mathf.Sign(touch.position.y - startPos.y);

					if(swipeDirection > 0)
					{
						foreach (IInputListener listener in listeners)
							listener.OnSwipeUp();

					}
					else
					{
						foreach (IInputListener listener in listeners)
								listener.OnSwipeDown();

					}
					
					// Do something here in reaction to the swipe.
				}
				else
				{
					foreach (IInputListener listener in listeners)
						listener.OnTap();
				}
				break;
			}
		}
#endif
	}
}
