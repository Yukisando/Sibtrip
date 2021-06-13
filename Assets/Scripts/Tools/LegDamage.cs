#region

using UnityEngine;

#endregion
public class LegDamage : MonoBehaviour
{
    private SpiderLeg leg;

    private void Start()
    {
        leg = GetComponentInParent<SpiderLeg>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            leg.health--;
        }
    }
}