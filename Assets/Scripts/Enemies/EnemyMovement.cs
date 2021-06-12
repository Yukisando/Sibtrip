#region

using UnityEngine;

#endregion
public class EnemyMovement : MonoBehaviour
{

    [Header("Movements")]
    public GameObject positions;
    public bool includeParentPosition;
    public float speed = 1.0f;

    [Header("Logic")]
    public float waitFor;
    private float timer;
    public bool destinationReached;
    public bool docked;

    public static bool isDocked;
    public static bool isReached;
    private Vector3 parentPosition;
    private Vector3 destination;
    private Transform[] targets;
    public int targetIndex = 0;

    private void Start()
    {
        timer = waitFor;
        parentPosition = transform.parent.transform.position;
        targets = positions.GetComponentsInChildren<Transform>();
        destination = GetDestination();
        SetNextDestination();
    }

    // Update is called once per frame
    private void Update()
    {
        isDocked = docked;
        isReached = destinationReached;

        if (!(Vector3.Distance(transform.position, destination) < 0.1f))
        {
            docked = false;
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        else
        {
            destination = GetDestination();
            SetNextDestination();
        }
    }

    private Vector3 GetDestination()
    {
        destinationReached = false;
        return targets[GetNextDestinationIndex()].position;
    }

    private int GetNextDestinationIndex()
    {
        return targetIndex;
    }

    private void SetNextDestination()
    {
        if (timer <= 0.0f || waitFor == 0)
        {
            if (Vector3.Distance(transform.position, targets[targetIndex].position) < 0.1f)
            {
                destinationReached = true;
                timer = waitFor;
                targetIndex++;
            }
            if (targetIndex >= targets.Length)
            {
                targetIndex = Random.Range(0, targets.Length);
            }

            if (Vector3.Distance(parentPosition, targets[targetIndex].position) < 0.1f && !includeParentPosition)
            {
                targetIndex++;
            }
        }
        else
        {
            docked = true;
            timer -= Time.deltaTime;
        }
    }
}