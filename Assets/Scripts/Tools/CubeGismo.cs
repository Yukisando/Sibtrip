#region

using UnityEngine;

#endregion
public class CubeGismo : MonoBehaviour
{
    public Color color = new Color(1, 0, 0, 0.5f);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}