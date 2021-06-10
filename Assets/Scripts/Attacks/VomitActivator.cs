using UnityEngine;

public class VomitActivator : MonoBehaviour {
    public GameObject vomitImage;
    public GameObject vomitParticle;
    public float warningDuration = 2.0f;
    public float vomitDuration = 2.0f;

    void Start() {
        Invoke("ActivateVomit", warningDuration);
    }

    void ActivateVomit() {
        vomitImage.SetActive(true);
        if(!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
        Invoke("DeactivateVomit", vomitDuration);
    }

    void DeactivateVomit() {
        vomitImage.SetActive(false);
        vomitParticle.GetComponent<ParticleSystem>().Stop();
        Destroy(gameObject, 3);
    }
}
