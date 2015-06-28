using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);
	public float degRotated = 0;
	public string fireType = "Fire1";

	public GameObject bulletPrefab;
	int bulletLayer;

	void Start() {
		if (bulletPrefab.layer == 11) {
			bulletLayer = 11;
		} else {
			bulletLayer = gameObject.layer;
		}
	}

	public float fireDelay = .25f;
	float cooldownTimer = 0;
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if (Input.GetButton(fireType) && cooldownTimer <= 0) {
			Debug.Log ("Pew");
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset;
			Quaternion rot = transform.rotation;
			float z = rot.eulerAngles.z + degRotated;

			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, Quaternion.Euler(0,0,z));

			bulletGO.layer = bulletLayer;
		}
	}
}
