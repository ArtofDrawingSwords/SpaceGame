using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float minEnemyRate = 2f;

	float spawnDistance = 12f;

	float enemyRate = 5;
	float nextEnemy = 1;

	void Update () {
		nextEnemy -= Time.deltaTime;

		if (nextEnemy <= 0) {
			nextEnemy = enemyRate;
			if(enemyRate > minEnemyRate)
				enemyRate *= 0.9f;
			Vector3 offset = Random.onUnitSphere;
			offset.z = 0;
			offset = offset.normalized * spawnDistance;
			Instantiate (enemyPrefab, transform.position + offset, Quaternion.identity);
		}
	}
}
