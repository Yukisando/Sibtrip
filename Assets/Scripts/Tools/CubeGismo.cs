using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGismo : MonoBehaviour {
    public Color color = new Color(1,0,0,0.5f);

    void OnDrawGizmosSelected()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
