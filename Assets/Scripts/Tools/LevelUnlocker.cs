using UnityEngine;

public class LevelUnlocker : MonoBehaviour {
    public static bool tarongaLocked = false;
    public static bool lunaLocked = false;
    public static bool reptileLocked = false;

    private void Start() {
        if (PlayerPrefs.GetInt("taronga") == 1) {
            tarongaLocked = false;
        }

        if (PlayerPrefs.GetInt("luna") == 1) {
            lunaLocked = false;
        }

        if (PlayerPrefs.GetInt("reptile") == 1) {
            reptileLocked = false;
        }
    }

    public void UnlockLevel(string code) {
        if (code == "2061") {
            PlayerPrefs.SetInt("taronga", 1);
            lunaLocked = false;
        }

        if (code == "safari") {
            PlayerPrefs.SetInt("luna", 1);
            tarongaLocked = false;
        }

        if (code == "i love spiders") {
            PlayerPrefs.SetInt("reptile", 1);
            reptileLocked = false;
        }
    }
}
