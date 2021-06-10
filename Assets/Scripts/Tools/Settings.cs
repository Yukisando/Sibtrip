using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Settings : MonoBehaviour {
    public bool resetGame = false;
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

    private void Awake() {
        if (PlayerPrefs.GetInt("dogsFreed") == 1) {
            dogsFreed = true;
        } else {
            dogsFreed = false;
        }

        if (PlayerPrefs.GetInt("catsFreed") == 1) {
            catsFreed = true;
        } else {
            catsFreed = false;
        }

        if (PlayerPrefs.GetInt("melonFreed") == 1) {
            melonFreed = true;
        } else {
            melonFreed = false;
        }

        deathSounds = GetComponent<AudioSource>();
    }

    private void Start() {
        deathSounds.clip = clips[0];
        friendlyFire = _friendlyFire;
    }

    private void Update() {
        if (resetGame) ResetGame();
        if (!pauline.activeSelf && !adrien.activeSelf && !replay) {
            EnemyStats.health = EnemyStats.initHealth;
            EnemyStats.stage = 1.0f;
            SceneManager.LoadScene("Map");
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            SceneManager.LoadScene("Map");
        }

        if (!pauline.activeSelf) {
            if (!paulineRespawned) {
                paulineRespawned = true;
                StartCoroutine(RespawnPauline());
            }
        }

        if (!adrien.activeSelf) {
            if (!adrienRespawned) {
                adrienRespawned = true;
                StartCoroutine(RespawnAdrien());
            }
        }

        if (EnemyStats.health <= 0.0f) {
            win = true;
        } else {
            win = false;
        }
    }

    private IEnumerator RespawnPauline() {
        deathSounds.clip = clips[1];
        if (!deathSounds.isPlaying) {
            deathSounds.Play();
        }

        yield return new WaitForSeconds(respawnDelay);
        PaulineStats.health = 1.0f;
        pauline.SetActive(true);
        paulineRespawned = false;
    }

    private IEnumerator RespawnAdrien() {
        deathSounds.clip = clips[0];
        if (!deathSounds.isPlaying) {
            deathSounds.Play();
        }

        yield return new WaitForSeconds(respawnDelay);
        AdrienStats.health = 1.0f;
        adrien.SetActive(true);
        adrienRespawned = false;
    }

    void ResetGame() {
        PlayerPrefs.DeleteAll();
    }
}
