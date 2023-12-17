using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [HideInInspector]
    public Transform target;

    public float speed = 20f;
    public float lifetime = 5f;
    public GameObject explosionPrefab;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime);
    }


    void FixedUpdate()
    {
        if(target != null)
            transform.LookAt(target.position);

        rb.velocity = speed * transform.forward;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rocket")) return;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
