using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    [SerializeField] float catPauseTime;
    [SerializeField] float catWalkTime;
    [SerializeField] float attackRange;
    [SerializeField] float chaseRange;
    [SerializeField] float catSpeed;
    [SerializeField] int catDamage;
    [SerializeField] PlayerData pd;
    [SerializeField] float attackInterval;
    [SerializeField] float rotationSpeed;

    GameObject player;
    public bool attacking;
    Rigidbody rb;
    [SerializeField] LayerMask mask;
    float angle;
    bool walking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(CatCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, chaseRange, mask);
        if (colliders.Length > 0)
        {
            attacking = true;
            player = colliders[0].gameObject;

            
        }
        else
        {
            attacking = false;
            player = null;
        }
    }

    private void FixedUpdate()
    {
        if (attacking)
        {
            if(player != null)
            {
                //Debug.Log(new Vector3(player.transform.position.x, 0.5f, player.transform.position.z));
                //rb.MoveRotation(Quaternion.LookRotation(new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), Vector3.up));
                //rb.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), Vector3.up);
                //rb.velocity = transform.forward * catSpeed;
                Vector3 direction = new Vector3(player.transform.position.x, 0.5f, player.transform.position.z) - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed);
                rb.velocity = transform.forward * catSpeed;
            }
            
        }

        if (walking)
        {
            rb.velocity = transform.forward * catSpeed;
        }
        
    }

    IEnumerator CatCoroutine()
    {
        while (true)
        {
            if (attacking)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, mask);
                if (colliders.Length > 0)
                {
                    pd.ChangeEnergy(-catDamage);
                    yield return new WaitForSeconds(attackInterval);
                }
                yield return null;
            }
            else
            {
                angle = Random.Range(0f, 360f);
                rb.MoveRotation(Quaternion.Euler(0, angle, 0));

                walking = true;

                //yield return new WaitForSeconds(Random.Range(0, catWalkTime));
                yield return new WaitForSeconds(catWalkTime);

                walking = false;
                rb.velocity = Vector3.zero;

                //yield return new WaitForSeconds(Random.Range(0, catPauseTime));
                yield return new WaitForSeconds(catPauseTime);
            }
            yield return null;
            
        }
    }
}
