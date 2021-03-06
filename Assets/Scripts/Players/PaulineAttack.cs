#region

using UnityEngine;

#endregion
public class PaulineAttack : MonoBehaviour
{
    public GameObject highlighterPrefab;
    public float reloadTime = .3f;

    private Animator anim;
    private float reloadTimer = 0f;
    private Transform rubbish;
    private static readonly int _attack = Animator.StringToHash("Attack");

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        rubbish = GameObject.FindGameObjectWithTag("rubbish").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        reloadTimer += Time.deltaTime;

        bool attack = Input.GetButton("Fire2");
        if (Settings.controller)
        {
            attack = Input.GetButton("Fire2C");
        }

        Vector3 firePos;
        if (!PaulineStats.facingRight && PaulineStats.twoSided)
        {
            firePos = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z);
        }
        else
        {
            firePos = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z);
        }

        if (attack && reloadTimer > reloadTime)
        {
            reloadTimer = 0f;

            Instantiate(highlighterPrefab, firePos, transform.rotation, rubbish);
            if (anim)
            {
                anim.SetTrigger(_attack);
            }
        }
    }
}