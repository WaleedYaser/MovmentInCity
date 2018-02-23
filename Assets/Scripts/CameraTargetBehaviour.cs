using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetBehaviour : MonoBehaviour {

	public float perspectiveZoomSpeed = 0.1f; 

	public static CameraTargetBehaviour Instance;

	public Vector3 offset;
	[HideInInspector] public Transform target;
	public PlayerController playerController;

	private TouchInputBehaviour touchInput;

	private Camera myCamera;
	private float initialFOV;

	void Awake()
	{
		Instance = this;
		gameObject.SetActive(false);
	}

	void Start()
	{
		touchInput = TouchInputBehaviour.Instance;
		myCamera = GetComponent<Camera>();
		initialFOV = GetComponent<Camera>().fieldOfView;
	}

	public void SetTarget (Transform target) {
		this.target = target;
		playerController.isControlable = false;
		transform.parent = target;
		transform.localPosition = offset;
		transform.localEulerAngles = Vector3.zero;
		GetComponent<Camera>().fieldOfView = 60;
		gameObject.SetActive(true);
	}
	
	public void ResetToPlayer()
	{
		playerController.isControlable = true;
		gameObject.SetActive(false);
	}

	private void FixedUpdate()
	{

		if (touchInput.IsTouch)
		{
			transform.RotateAround(target.position, Vector3.up, touchInput.DeltaX * Time.deltaTime);
		}
		else if (touchInput.IsPinch)
		{
			GetComponent<Camera>().fieldOfView += touchInput.DeltaMagnitudeDiff * perspectiveZoomSpeed;

			// Clamp the field of view to make sure it's between 0 and 180.
			GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 20f, 60f);
		}
	}
}
