using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputBehaviour : MonoBehaviour {

	public static TouchInputBehaviour Instance;

	private Vector3 touchInitPos;
	private Vector3 touchCurrentPos;

	private float deltaX;
	private float deltaMagnitudeDiff;

	private bool isTouch = false;
	private bool isPinch = false;

	public bool IsTouch
	{
		get
		{
			return isTouch;
		}
	}

	public bool IsPinch
	{
		get
		{
			return isPinch;
		}
	}

	public float DeltaX
	{
		get
		{
			return deltaX;
		}
	}

	public float DeltaMagnitudeDiff
	{
		get
		{
			return deltaMagnitudeDiff;
		}
	}

	void Awake()
	{
		Instance = this;
	}

	void Update () {
#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0))
		{
			isTouch = true;
			touchInitPos = Input.mousePosition;
		}

		if(Input.GetMouseButtonUp(0))
		{
			isTouch = false;
			deltaX = 0;
		}

		if(isTouch)
		{
			isPinch = false;
			isTouch = true;

			touchCurrentPos = Input.mousePosition;
			deltaX = touchCurrentPos.x - touchInitPos.x;
		}

#elif UNITY_ANDROID

		if (Input.touchCount == 2)
        {
			isPinch = true;
			isTouch = false;

			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
		}
		else if(Input.touchCount == 1)
		{
			if(!isTouch)
			{
				isPinch = false;
				isTouch = true;
				touchInitPos = Input.GetTouch(0).position;
			}

			touchCurrentPos = Input.GetTouch(0).position;

			deltaX = touchCurrentPos.x - touchInitPos.x;
		}
		else
		{
			isPinch = false;
			isTouch = false;
			deltaX = 0;
			deltaMagnitudeDiff = 0;
		}
#endif
	}

}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TouchInputBehaviour : MonoBehaviour {

// 	public static TouchInputBehaviour Instance;

// 	private Vector3 mouseInitPos;
// 	private Vector3 mouseCurrentPos;

// 	private float deltaX;
// 	private float deltaMagnitudeDiff;

// 	private bool isTouch = false;
// 	private bool isPinch = false;

// 	public bool IsTouch
// 	{
// 		get
// 		{
// 			return isTouch;
// 		}
// 	}

// 	public bool IsPinch
// 	{
// 		get
// 		{
// 			return isPinch;
// 		}
// 	}

// 	public float DeltaX
// 	{
// 		get
// 		{
// 			return deltaX;
// 		}
// 	}

// 	public float DeltaMagnitudeDiff
// 	{
// 		get
// 		{
// 			return deltaMagnitudeDiff;
// 		}
// 	}

// 	void Awake()
// 	{
// 		Instance = this;
// 	}

// 	void Update () {

// 		if(Input.touchCount == 1)
// 		{
// 			if(Input.GetMouseButtonDown(0))
// 			{
// 				isTouch = true;
// 				mouseInitPos = Input.mousePosition;
// 			}

// 			if(Input.GetMouseButtonUp(0))
// 			{
// 				isTouch = false;
// 				deltaX = 0;
// 			}
// 		}

// 		else if (Input.touchCount == 2)
//         {
// 			isPinch = true;

// 			Touch touchZero = Input.GetTouch(0);
// 			Touch touchOne = Input.GetTouch(1);

// 			// Find the position in the previous frame of each touch.
// 			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
// 			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

// 			// Find the magnitude of the vector (the distance) between the touches in each frame.
// 			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
// 			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

// 			// Find the difference in the distances between each frame.
// 			deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
// 		}
// 		else
// 		{
// 			isPinch = false;
// 		}

// 		if(isTouch)
// 		{
// 			mouseCurrentPos = Input.mousePosition;
// 			deltaX = mouseCurrentPos.x - mouseInitPos.x;
// 		}
// 	}

// }

