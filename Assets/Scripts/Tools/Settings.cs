#region

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion
[RequireComponent(typeof(AudioSource))]
public class Settings : MonoBehaviour
{
    public GameObject pauline;
    public GameObject adrien;
    private AudioSource deathSounds;
    public AudioClip[] clips;
    public int respawnDelay = 5;
    public bool replay = false;
    public bool _friendlyFire = true;
    public static bool friendlyFire = false;
    public static bool win = false;
    public static bool controller = false;

    public static bool catsFreed;
    public static bool dogsFreed;
    public static bool melonFreed;

    private bool paulineRespawned;
    private bool adrienRespawned;

    private void Awake()
    {
        dogsFreed = PlayerPrefs.GetInt("dogsFreed") == 1;

        catsFreed = PlayerPrefs.GetInt("catsFreed") == 1;

        melonFreed = PlayerPrefs.GetInt("melonFreed") == 1;

        deathSounds = GetComponent<AudioSource>();
    }

    private void Start()
    {
        deathSounds.clip = clips[0];
        friendlyFire = _friendlyFire;
    }

    private void Update()
    {

        if (!pauline.activeSelf && !adrien.activeSelf && !replay)
        {
            EnemyStats.health = EnemyStats.initHealth;
            EnemyStats.stage = 1.0f;
            SceneManager.LoadScene("Map");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Map");
        }

        if (!pauline.activeSelf)
        {
            if (!paulineRespawned)
            {
                paulineRespawned = true;
                StartCoroutine(RespawnPauline());
            }
        }

        if (!adrien.activeSelf)
        {
            if (!adrienRespawned)
            {
                adrienRespawned = true;
                StartCoroutine(RespawnAdrien());
            }
        }

        win = EnemyStats.health <= 0.0f;
    }

    private IEnumerator RespawnPauline()
    {
        deathSounds.clip = clips[1];
        if (!deathSounds.isPlaying)
        {
            deathSounds.Play();
        }

        yield return new WaitForSeconds(respawnDelay);
        PaulineStats.health = 1.0f;
        pauline.SetActive(true);
        paulineRespawned = false;
    }

    private IEnumerator RespawnAdrien()
    {
        deathSounds.clip = clips[0];
        if (!deathSounds.isPlaying)
        {
            deathSounds.Play();
        }

        yield return new WaitForSeconds(respawnDelay);
        AdrienStats.health = 1.0f;
        adrien.SetActive(true);
        adrienRespawned = false;
    }

}