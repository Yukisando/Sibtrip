using UnityEngine;

public class DisplayPets : MonoBehaviour {

    private void Start() {
        GetComponent<Animator>().SetBool("Cage", false);

        if(Settings.catsFreed && name == "Cats") {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Settings.dogsFreed && name == "Dogs") {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Settings.melonFreed && name == "Melon") {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
