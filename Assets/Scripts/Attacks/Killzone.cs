#region

using UnityEngine;

#endregion
public class Killzone : MonoBehaviour
{

    public bool activated;
    public GameObject hitMarker;
    private readonly float legDamage = 5.0f;
    private Transform rubbish;

    private void Awake()
    {
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Adrien" && activated)
        {
            AdrienStats.health -= legDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
        }

        if (collision.gameObject.tag == "Pauline" && activated)
        {
            PaulineStats.health -= legDamage;
            Instantiate(hitMarker, transform.position, transform.rotation, rubbish);
        }
    }
}