﻿// Creep.cs
// General-purpose enemy movement and stats script. Also defines enemy behaviour.

using UnityEngine;
using System.Collections;

public class Creep : MonoBehaviour
{
    // Target for despawning
    private Transform target;

    // The navmesh agent for this 
    NavMeshAgent agent;

    /// <summary>
    /// How much health the unit currently has.
    /// </summary>
	public int health = 50;

    /// <summary>
    /// How much damage the unit inflicts when it successfully leaks through.
    /// </summary>
    public int leakDamage = 1;

    /// <summary>
    /// The current speed of the creep.
    /// </summary>
    public float speed { get { return GetComponent<NavMeshAgent>().speed; } set { GetComponent<NavMeshAgent>().speed = value; } }

    /// <summary>
    /// The current acceleration of the creep.
    /// </summary>
    public float acceleration { get { return GetComponent<NavMeshAgent>().acceleration; } set { GetComponent<NavMeshAgent>().acceleration = value; } }

    // Use this for initialization
    void Start ()
    {
        // The creep is referenced with the NavMesh so it can interact.
        agent = GetComponent<NavMeshAgent>();

        // Creeps are instantiated each wave, and references are made to the despawn point for pathing.
        GameObject despawnGameObject = GameObject.FindWithTag("Despawn");

        if (despawnGameObject != null)
        {
            target = despawnGameObject.transform;
        }
        if (despawnGameObject == null)
        {
            Debug.Log("Cannot find despawn object");
        }

    }

    /// <summary>
    /// Called whenever enemy takes damage
    /// </summary>
    /// <param name="damage">How much damage the enemy will take</param>
	void TakeDamage(int damage)
    {
		health -= damage;
		if (health <= 0)
        {
			Destroy(gameObject);
		}
	}

    // Update
	void Update ()
    {
        if (agent && target)
        {
            agent.SetDestination(target.position);
        }
    }

    // OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Despawn"))
        {
            Destroy(gameObject);
            /*	
			 * {
			 * 	Code for Losing Lives.
			 * }
			*/
        }
    }

}
