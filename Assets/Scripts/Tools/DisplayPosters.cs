#region

using UnityEngine;

#endregion
public class DisplayPosters : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (Settings.catsFreed && name == "Cats")
        {
            spriteRenderer.enabled = false;
        }
        if (Settings.dogsFreed && name == "Dogs")
        {
            spriteRenderer.enabled = false;
        }
        if (Settings.melonFreed && name == "Melon")
        {
            spriteRenderer.enabled = false;
        }
    }
}