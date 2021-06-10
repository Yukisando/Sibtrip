using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToReptile : MonoBehaviour {
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (LevelUnlocker.reptileLocked) image.color = Color.red;
        else image.color = Color.green;
    }

    public void LoadReptile()
    {
        if (!LevelUnlocker.reptileLocked) SceneManager.LoadScene("Reptile");
    }
}
