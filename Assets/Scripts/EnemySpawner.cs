using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f,120f)]
    [SerializeField]float secondsBetweenSpawns = 6f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    // Use this for initialization
    void Start () {
        StartCoroutine(RepeatSpawnEnemies());
	}

    IEnumerator RepeatSpawnEnemies()
    {
        while(true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
