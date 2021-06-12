#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion
public class PaulineStats : MonoBehaviour
{
    [SerializeField]
    private float weapon_damage = 1.0f;
    public static float weaponDamage = 1.0f;

    [SerializeField]
    private float _health = 1.0f;
    public static float health = 1.0f;

    [SerializeField]
    public static bool facingRight = true;
    public static bool twoSided;

    public float invinsibilityDuration = 1.0f;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Reptile")
        {
            twoSided = true;
        }
        if (SceneManager.GetActiveScene().name == "Home")
        {
            twoSided = true;
        }
        health = _health;
        weaponDamage = weapon_damage;
    }

    private void Update()
    {
        if (health <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        health = 100.0f;
        Invoke("ResetHealth", invinsibilityDuration);
    }

    private void ResetHealth()
    {
        health = 1.0f;
    }
}