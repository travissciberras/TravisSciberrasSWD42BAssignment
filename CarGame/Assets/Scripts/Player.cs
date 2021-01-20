using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float CarMoveSpeed = 10f;
    [SerializeField] float padding = 0.7f;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] public int playerHealth = 50;

    GameSession gamesession;

    float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        ViewPortToWorldPoint();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public float returnCarMoveSpeed()
    {
        return CarMoveSpeed;
    }

    //Camera Boundaries
    private void ViewPortToWorldPoint()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * CarMoveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //move the car to the newXPos
        this.transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //access the Damage Dealer from the "other" object which hit the enemy
        //and depending on the laser damage reduce health
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        //if there is no damageDealer on Trigger
        //end the method
        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();

        damageDealer.Hit();
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public int getHealth()
    {
        return playerHealth;
    }
}
