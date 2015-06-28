using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    //ayy lmao
	public Transform myTarget;
//SUCK MY DICK
	void Update () {
	
		if (myTarget != null) {
			Vector3 targPos = myTarget.position;
			targPos.z = transform.position.z;
			transform.position = targPos;
		}
	}
}
