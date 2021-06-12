#region

using UnityEngine;

#endregion
public class Web : MonoBehaviour
{
    public GameObject hitMarker;
    public float webDamage = 2.0f;
    public float webSpeed = .1f;
    private Transform rubbish;
    private Vector3 target;

    private void Start()
    {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
        target = SpiderHead.closestPlayer.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, webSpeed);
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            Destroy(gameObject);
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Pauline")
        {
            PaulineStats.health -= webDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Adrien")
        {
            AdrienStats.health -= webDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Destroy")
        {
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 3);
    }
}