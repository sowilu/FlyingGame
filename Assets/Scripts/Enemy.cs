using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject rocket;
    public Transform gun;
    public float fireRate = 1;
    public GameObject baseBuilding;
    public GameObject crater;

    Transform target;

    private void Start()
    {
        InvokeRepeating("Fire", 0, fireRate);
    }

    void Update()
    {
        if(target != null)
        {
            gun.LookAt(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Rocket"))
        {
            //TODO: take damage, check health
            Explode();
        }
    }

    void Fire()
    {
        if(target != null)
        {
            var r = Instantiate(rocket, gun.transform.position + Vector3.up, gun.rotation);
            r.GetComponent<Rocket>().target = target;
        }
    }

    void Explode()
    {
        //TODO: sound + vfx
        baseBuilding.SetActive(false);
        crater.SetActive(true);
    }

}
