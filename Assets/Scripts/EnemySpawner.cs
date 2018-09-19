using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f,120f)]
    [SerializeField]float secondsBetweenSpawns = 6f;
    [SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(RepeatSpawnEnemies());
	}

    IEnumerator RepeatSpawnEnemies(/*List<EnemyMovement> enemies*/)
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
