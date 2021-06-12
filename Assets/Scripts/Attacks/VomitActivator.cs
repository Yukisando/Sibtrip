#region

using UnityEngine;

#endregion
public class VomitActivator : MonoBehaviour
{
    public GameObject vomitImage;
    public GameObject vomitParticle;
    public float warningDuration = 2.0f;
    public float vomitDuration = 2.0f;

    private void Start()
    {
        Invoke("ActivateVomit", warningDuration);
    }

    private void ActivateVomit()
    {
        vomitImage.SetActive(true);
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("DeactivateVomit", vomitDuration);
    }

    private void DeactivateVomit()
    {
        vomitImage.SetActive(false);
        vomitParticle.GetComponent<ParticleSystem>().Stop();
        Destroy(gameObject, 3);
    }
}