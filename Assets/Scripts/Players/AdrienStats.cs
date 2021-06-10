using UnityEngine;
using UnityEngine.SceneManagement;

public class AdrienStats : MonoBehaviour {
    [SerializeField]
    private float weapon_damage = 1.0f;
    static public float weaponDamage = 1.0f;

    [SerializeField]
    private float _health = 1.0f;
    static public float health = 1.0f;

    [SerializeField]
    static public bool facingRight = true;
    static public bool twoSided;

    public float invinsibilityDuration = 1.0f;

    private void Start() {
        if(SceneManager.GetActiveScene().name == "Reptile") twoSided = true;
        if(SceneManager.GetActiveScene().name == "Home") twoSided = true;
        health = _health;
        weaponDamage = weapon_damage;
    }

    private void Update() {
        if(health <= 0.0f) gameObject.SetActive(false);
    }

    private void OnEnable() {
        health = 100.0f;
        Invoke("ResetHealth", invinsibilityDuration);
    }

    void ResetHealth() {
        health = 1.0f;
    }
}
