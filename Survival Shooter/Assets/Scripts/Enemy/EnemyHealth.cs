using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deadClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticle;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticle = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed / Time.deltaTime);
        }
	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if(isDead)
        {
            return;
        }
        enemyAudio.Play();

        currentHealth -= amount;

        hitParticle.transform.position = hitPoint;

        hitParticle.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deadClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        ScoreManager.score += scoreValue;

        Destroy(gameObject, 2);
    }
}
