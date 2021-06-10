using UnityEngine;

public class LegDamage : MonoBehaviour {
    SpiderLeg leg;

    private void Start() {
        leg = GetComponentInParent<SpiderLeg>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Projectile") {
            leg.health--;
        }
    }
}
