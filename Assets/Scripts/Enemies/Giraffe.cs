#region

using UnityEngine;

#endregion
public class Giraffe : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Transform rubbish;
    private Vector3 spawnScale;
    private Vector3 fireScale;
    private float startSpeed;
    private SpriteRenderer sr;
    public Sprite[] giraffeSprites;
    public float health;
    public GameObject flashPrefab;
    public GameObject fireBallPrefab;
    public GameObject deathPrefab;

    private void Awake()
    {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
        enemyMovement = GetComponent<EnemyMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        startSpeed = enemyMovement.speed;
        sr.sprite = giraffeSprites[0];
        spawnScale = transform.localScale;
        fireScale = new Vector3(transform.localScale.x, transform.localScale.x, transform.localScale.z) * 1.1f;
    }

    private void Update()
    {
        transform.localScale = spawnScale;
        health = EnemyStats.health;

        if (enemyMovement.destinationReached)
        {
            Fire();
        }

        if (health < 70.0f)
        {
            EnemyStats.stage = 1.5f;
        }
        if (health < 30.0f)
        {
            EnemyStats.stage = 2.5f;
        }
        if (health <= 0.0f)
        {
            EnemyStats.stage = 3.5f;
        }

        if (EnemyStats.stage == 1.5f)
        {
            enemyMovement.speed = startSpeed + 1;
            sr.sprite = giraffeSprites[1];
            EnemyStats.stage = 2.0f;
        }

        if (EnemyStats.stage == 2.5f)
        {
            enemyMovement.speed = startSpeed + 2;
            sr.sprite = giraffeSprites[2];
            EnemyStats.stage = 3.0f;
        }

        if (EnemyStats.stage == 3.5f)
        {
            transform.parent.gameObject.SetActive(false);
            Instantiate(deathPrefab, transform.position, transform.rotation, rubbish);
            PlayerPrefs.SetInt("melonFreed", 1);
            Settings.melonFreed = true;
        }
    }

    private void Fire()
    {
        transform.localScale = fireScale;
        Instantiate(flashPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), transform.rotation, rubbish);
        Instantiate(fireBallPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), transform.rotation, rubbish);
    }

    private void OnEnable()
    {
        EnemyStats.health = 100.0f;
    }
}