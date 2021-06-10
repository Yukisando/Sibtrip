using UnityEngine;

public class CameraFollow2D : MonoBehaviour {
    private Camera cam;
    public Transform player1; // Reference to the player's transform.
    public Transform player2; // Reference to the player's transform.

    // Use this for initialization
    private void Start() {
        cam = GetComponent<Camera>();
    }

    void SetCameraPos() {
        Vector3 middle = (player1.position + player2.position) * 0.5f;
        cam.transform.position = new Vector3(
            middle.x,
            cam.transform.position.y,
            cam.transform.position.z
        );
    }

    // Update is called once per frame
    private void LateUpdate() {
        SetCameraPos();
    }
}