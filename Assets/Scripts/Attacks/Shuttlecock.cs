using UnityEngine;
using UnityStandardAssets.Utility;

public class Shuttlecock : MonoBehaviour {
    public GameObject hitMarker;
    public Sprite[] shuttlecockSprites;
    Transform rubbish;
    SpriteRenderer sr;
    GameObject enemy;

    AutoMoveAndRotate movement;

    private void Awake() {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
        movement = GetComponent<AutoMoveAndRotate>();
        sr = GetComponent<SpriteRenderer>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(EnemyStats.stage == 0) return;
    }

    private void Start() {
        sr.sprite = shuttlecockSprites[Random.Range(0, shuttlecockSprites.Length)];
        if(!AdrienStats.facingRight && AdrienStats.twoSided) {
            movement.moveUnitsPerSecond.value = -movement.moveUnitsPerSecond.value;
            sr.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "EnemyPart") {
            if(EnemyStats.stage == 0) return;
            EnemyStats.health -= AdrienStats.weaponDamage;
            if(coll.gameObject.tag == "EnemyPart")
                coll.gameObject.transform.parent.gameObject.GetComponent<SpiderLeg>().health -= AdrienStats.weaponDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            enemy.GetComponent<SpriteRenderer>().color = new Color(200, 0, 0, 100);
            Invoke("ResetEnemyColor", .1f);
            sr.enabled = false;
            Destroy(gameObject, 1);
        }

        if(coll.gameObject.tag == "Pauline" && Settings.friendlyFire) {
            PaulineStats.health -= 0.5f;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            Destroy(gameObject);
        }

        if(coll.gameObject.tag == "Destroy") {
            Destroy(gameObject);
        }
    }

    void ResetEnemyColor() {
        enemy.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnBecameInvisible() {
        Destroy(gameObject, 3);
    }
}
