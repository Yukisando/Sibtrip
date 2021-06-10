using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    void Start() {
        Destroy(gameObject, 5);
    }
}
