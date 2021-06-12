#region

using UnityEngine;

#endregion
public class Fireball : MonoBehaviour
{
    public GameObject hitMarker;
    public float fireballDamage = 2.0f;
    private Transform rubbish;

    private void Start()
    {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
    }

    private void OnTriggerEnter2D(Collider2D coll)
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

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 3);
    }
}