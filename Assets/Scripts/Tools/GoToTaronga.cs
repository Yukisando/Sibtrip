using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToTaronga : MonoBehaviour {
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (LevelUnlocker.tarongaLocked) image.color = Color.red;
        else image.color = Color.green;
    }

    public void LoadTaronga()
    {
        if (!LevelUnlocker.tarongaLocked) SceneManager.LoadScene("Taronga");
    }
}
