using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoint = 10;

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
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
