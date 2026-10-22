using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Character/FPS Input Controller")]
[RequireComponent(typeof(CharacterMotor))]
public class FPSInputController : MonoBehaviour
{
	private CharacterMotor motor;

	public virtual void Awake()
	{
		motor = (CharacterMotor)GetComponent(typeof(CharacterMotor));
	}

	public virtual void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		float gamepadHorizontal = Input.GetAxis("Gamepad Horizontal");
		float gamepadVertical = Input.GetAxis("Gamepad Vertical");
		if (Mathf.Abs(gamepadHorizontal) > Mathf.Abs(horizontal))
		{
			horizontal = gamepadHorizontal;
		}
		if (Mathf.Abs(gamepadVertical) > Mathf.Abs(vertical))
		{
			vertical = gamepadVertical;
		}
		Vector3 vector = new Vector3(horizontal, 0f, vertical);
		if (vector != Vector3.zero)
		{
			float magnitude = vector.magnitude;
			vector /= magnitude;
			magnitude = Mathf.Min(1f, magnitude);
			magnitude *= magnitude;
			vector *= magnitude;
		}
		motor.inputMoveDirection = transform.rotation * vector;
	}

	public virtual void Main()
	{
	}
}
