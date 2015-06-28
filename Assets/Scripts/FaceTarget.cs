using UnityEngine;
using System.Collections;

public class FaceTarget : MonoBehaviour {

	public float rotSpeed = 90f;

	public string target = "Enemy";
	
	Transform Target;
	
	void Update () {
		if (Target == null) {
			GameObject go = GameObject.FindWithTag(target);
			if(go != null) {
				Target = go.transform;
			}
		}
		
		if (Target == null)
			return;
		
		Vector3 dir = Target.position - transform.position;
		dir.Normalize ();
		
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		
		Quaternion desiredRotation = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
	}
}
