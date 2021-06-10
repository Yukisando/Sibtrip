using UnityEngine;

public class DisplayPosters : MonoBehaviour {

    private void Start() {
        if (Settings.catsFreed && name == "Cats") {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Settings.dogsFreed && name == "Dogs") {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Settings.melonFreed && name == "Melon") {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
