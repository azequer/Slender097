using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes;

	public float sensitivityX = 15f;

	public float sensitivityY = 15f;

	public float minimumX = -360f;

	public float maximumX = 360f;

	public float minimumY = -60f;

	public float maximumY = 60f;

	public bool inverted;

	private float rotationY;

	private void Update()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		float lookX = mouseX + Input.GetAxis("Gamepad Look X") * Time.deltaTime * 20f;
		float lookY = mouseY + Input.GetAxis("Gamepad Look Y") * Time.deltaTime * 20f;
		if (axes == RotationAxes.MouseXAndY)
		{
			float y = base.transform.localEulerAngles.y + lookX * sensitivityX;
			if (inverted)
			{
				rotationY -= lookY * sensitivityY;
			}
			else
			{
				rotationY += lookY * sensitivityY;
			}
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			base.transform.localEulerAngles = new Vector3(0f - rotationY, y, 0f);
		}
		else if (axes == RotationAxes.MouseX)
		{
			base.transform.Rotate(0f, lookX * sensitivityX, 0f);
		}
		else
		{
			if (inverted)
			{
				rotationY -= lookY * sensitivityY;
			}
			else
			{
				rotationY += lookY * sensitivityY;
			}
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			base.transform.localEulerAngles = new Vector3(0f - rotationY, base.transform.localEulerAngles.y, 0f);
		}
	}

	private void Start()
	{
		if ((bool)base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}
}
