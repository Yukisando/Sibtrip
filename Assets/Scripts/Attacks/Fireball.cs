using UnityEngine;

public class Fireball : MonoBehaviour {
    public GameObject hitMarker;
    public float fireballDamage = 2.0f;
    Transform rubbish;

    private void Start()
    {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Pauline")
        {
            PaulineStats.health -= fireballDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Adrien")
        {
            AdrienStats.health -= fireballDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Destroy")
        {
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject, 3);
    }
}
