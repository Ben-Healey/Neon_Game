using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class canMouseLook : MonoBehaviour {

	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	//new stuff
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;

	Vector2 mouseLook;
	Vector2 smoothV;

	GameObject character;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
//		rb = character.GetComponent<Rigidbody> ();
//		Debug.Log (rb.ToString());
//		if (rb) {
//			rb.freezeRotation = true;
//		}
			
		character = this.transform.parent.gameObject;

	}

	// Update is called once per frame
	void Update () {
		if (Global_Script.Paused == false) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
////			// MD = Mouse Delta
			var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

			md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));

			smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
			smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
			mouseLook += smoothV;

			mouseLook.y = Mathf.Clamp (mouseLook.y, -60.0f, 60.0f);
			transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
			character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
//			if (axes == RotationAxes.MouseXAndY)
//			{
//				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
//
//				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
//				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
//
//				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
//			}
//			else if (axes == RotationAxes.MouseX)
//			{
//				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
//			}
//			else
//			{
//				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
//				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
//
//				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
//			}
//
		} else if (Global_Script.Paused == true) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		}
	}
		


}
