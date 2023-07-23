using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    //two hit impact particles 
    [SerializeField] private Transform HitEnemyParticle;
    [SerializeField] private Transform HitOtherParticle;

    private Rigidbody arrowRigidbody;

    private void Awake()
    {
        //get required components and variables from the rigidbody
        arrowRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //speed of the arrow
        float speed = 50f;
        arrowRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ArrowTarget>() != null)
        {
            //Hit Target then HitEnemyParticle will be instantiated
            Instantiate(HitEnemyParticle, transform.position, Quaternion.identity);
        }
        else
        {
            //Hit something else then HitOtherParticle will be instantiated
            Instantiate(HitOtherParticle, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
