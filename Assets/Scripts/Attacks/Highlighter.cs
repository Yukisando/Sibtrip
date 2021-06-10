using UnityEngine;
using UnityStandardAssets.Utility;

public class Highlighter : MonoBehaviour {
    public GameObject hitMarker;
    SpriteRenderer sr;
    Transform rubbish;
    GameObject enemy;

    AutoMoveAndRotate movement;

    private void Awake() {
        movement = GetComponent<AutoMoveAndRotate>();

        sr = GetComponent<SpriteRenderer>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(EnemyStats.stage == 0) return;
    }

    private void Start() {
        if(!PaulineStats.facingRight && AdrienStats.twoSided) movement.moveUnitsPerSecond.value = -movement.moveUnitsPerSecond.value;

        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
        sr.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "EnemyPart") {
            if(EnemyStats.stage == 0) return;
            EnemyStats.health -= PaulineStats.weaponDamage;
            if(coll.gameObject.tag == "EnemyPart")
                coll.gameObject.transform.parent.gameObject.GetComponent<SpiderLeg>().health -= PaulineStats.weaponDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            enemy.GetComponent<SpriteRenderer>().color = new Color(200, 0, 0, 100);
            Invoke("ResetEnemyColor", .1f);
            sr.enabled = false;
            Destroy(gameObject, 1);
        }

        if(coll.gameObject.tag == "Adrien" && Settings.friendlyFire) {
            AdrienStats.health -= 0.5f;
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
