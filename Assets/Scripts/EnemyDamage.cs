using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour {
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoint = 10;
    [SerializeField] ParticleSystem enemyIsHit;
    [SerializeField] ParticleSystem enemyDead;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

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
        myAudioSource.PlayOneShot(enemyHitSFX);
    }

    private void KillEnemy()
    {
       
        var explode = Instantiate(enemyDead, transform.position, Quaternion.identity);
        explode.Play();
        Destroy(explode.gameObject, explode.main.duration);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, transform.position);
        
        Destroy(gameObject);
    }
}
