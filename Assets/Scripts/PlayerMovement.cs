using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 180f;

	float shipBoundaryRadius = 0.5f;

	void Start () {
	
	}

	void Update () {
		// rotate the ship

		//grave our rotation quaternion
		Quaternion rot = transform.rotation;

		//grave the z euler angle
		float z = rot.eulerAngles.z;

		//change the z angle based on input
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;

		//recreate the quaternion
		rot = Quaternion.Euler(0,0,z);

		//feed the quaternion into our rotation
		transform.rotation = rot;

		//move the ship
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime, 0);
		pos += rot * velocity;

		if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}

		if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		float screenRation = (float)Screen.width / Screen.height;
		float widthOrtho = screenRation * Camera.main.orthographicSize;

		if(pos.x+shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		
		if(pos.x-shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}

		transform.position = pos;
	}
}
