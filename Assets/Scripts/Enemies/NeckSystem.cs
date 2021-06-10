using UnityEngine;

public class NeckSystem : MonoBehaviour {
    public Transform neckBase;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update () {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, neckBase.position);
    }
}
