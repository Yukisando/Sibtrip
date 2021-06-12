#region

using UnityEngine;

#endregion
public class SpiderHead : MonoBehaviour
{

    [Header("Head")]
    public float health = 200.0f;
    public Transform pauline;
    public Transform adrien;
    public static Transform closestPlayer;
    private SpriteRenderer sr;
    public Sprite[] sprites;
    public GameObject deathPrefab;

    [Header("Attacks")]
    public GameObject webPrefab;
    public float attackRate = 1;
    private float initattackRate;
    private float reloaded;
    private Transform rubbish;
    private float paulineDistance;
    private float adrienDistance;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
    }

    private void Start()
    {
        sr.sprite = sprites[0];
        EnemyStats.health = health;
        initattackRate = attackRate;
        reloaded = 1;
    }

    private void Update()
    {
        health = EnemyStats.health;
        closestPlayer = FacePlayer();
        if (closestPlayer.gameObject.activeSelf)
        {
            Attack();
        }

        if (health < 150.0f)
        {
            EnemyStats.stage = 1.5f;
        }
        if (health < 100.0f)
        {
            EnemyStats.stage = 2.5f;
        }
        if (health <= 50.0f)
        {
            EnemyStats.stage = 3.5f;
        }

        if (EnemyStats.stage == 1.5f)
        {
            attackRate = initattackRate / 3 * 1.5f;
            sr.sprite = sprites[1];
            EnemyStats.stage = 2.0f;
        }

        if (EnemyStats.stage == 2.5f)
        {
            attackRate = 1f;
            sr.sprite = sprites[2];
            EnemyStats.stage = 3.0f;
        }

        if (EnemyStats.stage == 3.5f)
        {
            transform.parent.gameObject.SetActive(false);
            Instantiate(deathPrefab, transform.position, transform.rotation, rubbish);
            PlayerPrefs.SetInt("catsFreed", 1);
            Settings.catsFreed = true;
        }
    }

    private void Attack()
    {
        reloaded -= Time.deltaTime;
        if (reloaded <= 0)
        {
            Instantiate(webPrefab, transform.position, Quaternion.identity, rubbish);
            reloaded = attackRate;
        }
    }

    private Transform FacePlayer()
    {
        Transform closestPlayer;
        paulineDistance = Vector2.Distance(pauline.position, transform.position);
        adrienDistance = Vector2.Distance(adrien.position, transform.position);

        if (paulineDistance < adrienDistance)
        {
            closestPlayer = pauline;
        }
        else
        {
            closestPlayer = adrien;
        }

        if (!pauline.gameObject.activeSelf)
        {
            closestPlayer = adrien;
        }

        if (!adrien.gameObject.activeSelf)
        {
            closestPlayer = pauline;
        }

        Vector2 direction = closestPlayer.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(new Vector3(0, 0, 90));
        return closestPlayer;
    }

    private void OnEnable()
    {
        EnemyStats.health = health;
    }
}