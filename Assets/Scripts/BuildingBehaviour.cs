using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour {

	private CameraTargetBehaviour cameraTarget;

	bool targeted = false;
	float doubleClickStart = 0;

	void Start()
	{
		cameraTarget = CameraTargetBehaviour.Instance;
	}

	void OnMouseUp()
	{
		if ((Time.time - doubleClickStart) < 0.3f)
		{
			this.OnDoubleClick();
			doubleClickStart = -1;
		}
		else
		{
			doubleClickStart = Time.time;
		}
	}

	void OnDoubleClick()
	{
		Debug.Log("Double Clicked");
		if	(targeted)
		{
			// return to player control
			cameraTarget.ResetToPlayer();
			targeted = false;
		}
		else
		{
			// target game object
			targeted = true;
			cameraTarget.SetTarget(transform);
		}
	}
}
