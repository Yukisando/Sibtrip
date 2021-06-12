#region

using UnityEngine;

#endregion
public class NeckSystem : MonoBehaviour
{
    public Transform neckBase;
    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, neckBase.position);
    }
}