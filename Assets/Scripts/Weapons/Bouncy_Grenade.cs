﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy_Grenade : MonoBehaviour
{

    public float delay = 3f;
    public float radius = 5f;
    public float force = 5f;

    public GameObject explosionEffect;

    bool hasExploded = false;

    float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            explode();
            hasExploded = true;
        }
    }

    void explode()
    {
        // Show effect 
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        //Add force
        //Damage
        Destroy(explosionEffect, 3);
        Destroy(gameObject);

        //Remove grenade
    }
}
