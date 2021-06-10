#region

using System.Collections;
using UnityEngine;

#endregion
public class SpiderLeg : MonoBehaviour
{
    private Transform rubbish;
    [Header("Sprites")]
    private SpriteRenderer sr;
    public Sprite[] sprites;
    private Vibrator vibrator;

    [Header("Stats")]
    [SerializeField]
    public float health = 50.0f;

    [Header("Attack")]
    public float legDownDuration = 1.0f;
    public float legDownSpeed = .3f;
    public GameObject smokePrefab;
    private Killzone killzone;
    private Vector3 upPos;
    private Vector3 downPos;
    private Vector2 smokePos;
    private bool legDown;

    private void Awake()
    {
        vibrator = GetComponent<Vibrator>();
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
        sr = GetComponent<SpriteRenderer>();
        killzone = GetComponentInChildren<Killzone>();
    }

    private void Start()
    {
        sr.sprite = sprites[0];
        upPos = transform.position;
        downPos = new Vector3(transform.position.x, transform.position.y - 4.4f, transform.position.z);
        smokePos = new Vector3(transform.position.x, transform.position.y - 8.4f, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (legDown && health > 0)
        {
            killzone.activated = true;
        }
        else
        {
            killzone.activated = false;
        }

        if (health <= 0)
        {
            transform.position = downPos;
            sr.sprite = sprites[2];
            vibrator.enabled = false;
        }
        else if (health <= 25.0f)
        {
            sr.sprite = sprites[1];
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Pauline") || collision.CompareTag("Adrien") && health > 0) && health > 0)
        {
            vibrator.enabled = true;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        vibrator.enabled = false;
        while (!legDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, downPos, legDownSpeed);
            if (Vector3.Distance(transform.position, downPos) < 0.01f)
            {
                legDown = true;
            }

            yield return null;
        }
        Instantiate(smokePrefab, smokePos, Quaternion.identity, rubbish);
        yield return new WaitForSeconds(legDownDuration);
        StartCoroutine(Retract());

    }

    private IEnumerator Retract()
    {
        while (legDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, upPos, 0.1f);
            if (Vector3.Distance(transform.position, upPos) < 0.01f)
            {
                legDown = false;
            }

            yield return null;
        }
    }
}