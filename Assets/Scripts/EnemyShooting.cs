using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    //comment in shooting
	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);
	
	public GameObject bulletPrefab;
	int bulletLayer;

	public float fireRange = 4;
	public float fireDelay = .5f;
	float cooldownTimer = 0;

	Transform player;

	void Start() {
		bulletLayer = 12;
	}
	// Update is called once per frame
	void Update () {

		if (player == null) {
			GameObject go = GameObject.FindWithTag("Player");
			if(go != null) {
				player = go.transform;
			}
		}

		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0 && player!= null && Vector3.Distance (transform.position, player.position) < fireRange) {
			Debug.Log ("EnemyPew");
			cooldownTimer = fireDelay;
			
			Vector3 offset = transform.rotation * bulletOffset;
			
			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}
