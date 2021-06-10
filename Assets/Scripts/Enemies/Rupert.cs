using UnityEngine;

public class Rupert : MonoBehaviour {
    private EnemyMovement enemyMovement;
    private Transform rubbish;
    private Vibrator vibrator;
    private float spawnSpeed;
    private float spawnWait;
    private SpriteRenderer sr;

    [Header("Rupert")]
    public float health;
    public float stage;
    public Sprite[] rupertSprites;
    public GameObject deathPrefab;

    [Header("Attacks")]
    public float fireRate = 0.2f;
    private float initFireRate;
    private float reloaded;
    public GameObject clownPrefab;
    public GameObject candyPrefab;
    public GameObject icecreamPrefab;

    [Header("Level modifiers")]
    private float reloadedVomit;
    public GameObject vomitPrefab;

    private void Awake() {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
        enemyMovement = GetComponent<EnemyMovement>();
        sr = GetComponent<SpriteRenderer>();
        vibrator = transform.parent.GetComponent<Vibrator>();
    }

    private void Start() {
        initFireRate = fireRate;
        reloaded = fireRate;
        reloadedVomit = fireRate;
        vibrator.vibrationStrength = 0f;
        spawnSpeed = enemyMovement.speed;
        spawnWait = enemyMovement.waitFor;
        sr.sprite = rupertSprites[0];
    }

    private void Update() {
        health = EnemyStats.health;
        stage = EnemyStats.stage;

        if (enemyMovement.docked) {
            Fire();
        }

        if (health < 70.0f) {
            EnemyStats.stage = 1.5f;
        }
        if (health < 30.0f) {
            EnemyStats.stage = 2.5f;
        }
        if (health <= 0.0f) {
            EnemyStats.stage = 3.5f;
        }

        if (EnemyStats.stage == 1.5f) {
            enemyMovement.speed = spawnSpeed + 4;
            fireRate = (initFireRate / 3) * 1.5f;
            vibrator.vibrationStrength = 0.03f;
            sr.sprite = rupertSprites[1];
            EnemyStats.stage = 2.0f;
        }

        if (EnemyStats.stage == 2.5f) {
            enemyMovement.speed = spawnSpeed + 12;
            enemyMovement.waitFor = spawnWait + 2;
            fireRate = 1f;
            vibrator.vibrationStrength = 0.05f;
            sr.sprite = rupertSprites[2];
            EnemyStats.stage = 3.0f;
        }

        if (EnemyStats.stage == 3.5f) {
            transform.parent.gameObject.SetActive(false);
            Instantiate(deathPrefab, transform.position, transform.rotation, rubbish);
            PlayerPrefs.SetInt("dogsFreed", 1);
            Settings.dogsFreed = true;
        }
    }

    private void Fire() {
        reloaded -= Time.deltaTime;
        if (reloaded <= 0) {
            reloaded = fireRate;
            int randomPick = 0;
            randomPick = Random.Range(0, 3);

            switch (randomPick) {
                case 0:
                    Instantiate(clownPrefab, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), transform.rotation, rubbish);
                    break;
                case 1:
                    Instantiate(candyPrefab, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), transform.rotation, rubbish);
                    break;
                case 2:
                    Instantiate(icecreamPrefab, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), transform.rotation, rubbish);
                    break;
                default:
                    Instantiate(clownPrefab, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), transform.rotation, rubbish);
                    break;
            }
        }
        if (EnemyStats.stage >= 3) {
            Vomit();
        }
    }

    private void Vomit() {
        reloadedVomit -= Time.deltaTime;
        if (reloadedVomit <= 0 && enemyMovement.docked) {
            reloadedVomit = fireRate + vomitPrefab.GetComponent<VomitActivator>().vomitDuration + 2;

            Instantiate(vomitPrefab, new Vector3(-10.7f, transform.position.y - 2f, -.2f), Quaternion.identity, rubbish);
        }
    }

    private void OnEnable() {
        EnemyStats.health = 100.0f;
    }
}