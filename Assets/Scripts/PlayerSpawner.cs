using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	float respawnTimer;

	public int numLives = 3;

	// Use this for initialization
	void Start () {
		SpawnPlayer ();
	}
	
	// Update is called once per frame
	void SpawnPlayer () {
		numLives--;
		respawnTimer = 1;
		playerInstance = (GameObject)Instantiate (playerPrefab, transform.position, Quaternion.identity);
	}

	void Update() {
		if (playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;
			if (respawnTimer <= 0) {
				SpawnPlayer ();
			}
		}
	}

	void OnGUI() {
		if (numLives > 0 || playerInstance != null) {
			GUI.Label (new Rect (0, 0, 100, 50), "Lives: " + numLives);
		} else {
			GUI.Label (new Rect (Screen.width/2 - 35, Screen.height/2 -25, 100, 50), "Game Over");
		}
	}
}
