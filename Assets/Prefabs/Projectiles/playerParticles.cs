using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerParticles : MonoBehaviour
{
    ParticleSystem particleSystem;
    LayerMask mask;
    // The particle System
    private ParticleSystem sys;
    // Array of alive particles
    private ParticleSystem.Particle[] aliveParticles;
    // The 2d collider that we want to collide with
    // the particle system
    [SerializeField] private BoxCollider2D boxCollider;

    // Called when any particle meets the condition
    // of the trigger section of the particle system
    private void OnParticleTrigger()
    {
        // Check to see what needs to be initialized
        InitializeIfNeeded();

        // Get the particles that are currently alive
        // and store them in the array
        sys.GetParticles(aliveParticles);

        // Loop through the particles in the array
        foreach (ParticleSystem.Particle particle in aliveParticles)
        {
            // Check for collision
            Bounds bounds = new Bounds(particle.position, particle.GetCurrentSize3D(sys));
            if (boxCollider.bounds.Intersects(bounds))
            {
                Debug.Log("Success");
            }
        }
    }

    // Initialize the variables only once
    private void InitializeIfNeeded()
    {
        //// Get the 2d trigger collider from the GameObject
        if (sys == null)
        {
            sys = GetComponent<ParticleSystem>();
            sys.trigger.SetCollider(0, boxCollider);
        }

        // Initialize the array that holds the alive particles
        if (aliveParticles == null)
            aliveParticles = new ParticleSystem.Particle[sys.main.maxParticles];
    }
}
