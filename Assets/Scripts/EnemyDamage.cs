using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour {
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoint = 10;
    [SerializeField] ParticleSystem enemyIsHit;
    [SerializeField] ParticleSystem enemyDead;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoint <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoint = hitPoint - 1;
        enemyIsHit.Play();
    }

    private void KillEnemy()
    {
       
        var explode = Instantiate(enemyDead, transform.position, Quaternion.identity);
        explode.Play();
        float destroyDelay = explode.main.duration;

        Destroy(gameObject);
        Destroy(explode.gameObject, destroyDelay);
    }
}
