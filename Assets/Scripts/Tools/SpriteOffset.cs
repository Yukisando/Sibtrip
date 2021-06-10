using UnityEngine;

public class SpriteOffset: MonoBehaviour {
    public float speed = 3.0f;
    Renderer rd;

    // Use this for initialization
    void Start() {
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        rd.material.mainTextureOffset = new Vector2(Time.time * speed, 0);
    }
}
