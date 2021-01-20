using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float health = 50;
    [SerializeField] int scoreValue = 5;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] GameObject Explosion;
    [SerializeField] float enemyBulletSpeed = 1f;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //every frame reduces the amount of time that the frame takes to run
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            EnemyFire();
            //reset shotCounter after every fire
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        GameObject enemyLaser = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //enemy laser shoots downwards, hence -enemyLaserSpeed
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyBulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //access the Damage Dealer from the "other" object which hit the enemy
        //and depending on the laser damage reduce health
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(explosion, 1f);
    }
}