using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public static float health = 100.0f;
    public static float initHealth = 100.0f;
    public static float stage = 1.0f;

    private void Start() {
        health = initHealth;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            stage = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            stage = 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            stage = 2.5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            stage = 3.5f;
        }
    }
}
