#region

using UnityEngine;

#endregion
public class SpriteOffset : MonoBehaviour
{
    public float speed = 3.0f;
    private Renderer rd;

    // Use this for initialization
    private void Start()
    {
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        rd.material.mainTextureOffset = new Vector2(Time.time * speed, 0);
    }
}