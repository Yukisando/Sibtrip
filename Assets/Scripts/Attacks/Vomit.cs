using UnityEngine;

public class Vomit: MonoBehaviour {
    public GameObject hitMarker;
    public float vomitDamage = 5.0f;

    Transform rubbish;

    private void Awake() {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Pauline")
        {
            PaulineStats.health -= vomitDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
        }
        if (coll.gameObject.tag == "Adrien")
        {
            AdrienStats.health -= vomitDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
        }
    }
}
