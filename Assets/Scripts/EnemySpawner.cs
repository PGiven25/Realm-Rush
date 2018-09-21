using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 6f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text enemySpawned;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;

    // Use this for initialization
    void Start() {
        StartCoroutine(RepeatSpawnEnemies());
    }

    IEnumerator RepeatSpawnEnemies()
    {
        while (true)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score += 1;
        enemySpawned.text = score.ToString();

        }
}
