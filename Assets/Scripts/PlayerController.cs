using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private CharacterController characterController;
	private Animator m_Animator;
	private TouchInputBehaviour touchInput;

	public bool isControlable = true;

	void Start () {
		characterController = GetComponent<CharacterController>();
		m_Animator = characterController.GetComponent<Animator>();
		touchInput = TouchInputBehaviour.Instance;
	}
	
	private void FixedUpdate()
	{

		if(touchInput.IsTouch && isControlable)
		{
			Vector3 m_ForwardAmount = characterController.transform.forward * Time.deltaTime;
			Vector3 m_TurnAmount = new Vector3(0, touchInput.DeltaX * Time.deltaTime, 0);

			characterController.transform.Rotate(m_TurnAmount);
			characterController.Move(m_ForwardAmount);

			m_Animator.SetFloat("Forward", 0.5f, 0.1f, Time.deltaTime);
			m_Animator.SetFloat("Turn", m_TurnAmount.y * Mathf.Deg2Rad, 0.1f, Time.deltaTime);
		} 
		else
		{
			m_Animator.SetFloat("Forward", 0f, 0.1f, Time.deltaTime);
			m_Animator.SetFloat("Turn", 0, 0.1f, Time.deltaTime);
		}
		
	}
}
