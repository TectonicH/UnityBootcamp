using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TigerTail
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Snowball : MonoBehaviour
    {
        /// <summary>Density of packed snow in kg/m^3.</summary>
        private const float DENSITY_OF_SNOWBALL = 200;

        /// <summary>Rigidbody attached to this snowball.</summary>
        private Rigidbody rb;

        /// <summary>SphereCollider attached to this snowball.</summary>
        private SphereCollider sc;

        /// <summary>Total number of completed rotations.</summary>
        private float completedRotations;

        /// <summary>Current size of the snowball.</summary>
        private float currentSize;

        [Tooltip("Particle system for the mist effect below the snowball.")]
        [SerializeField] private ParticleSystem ps;

        [Tooltip("Number of rotations needed to double the snowball's size.")]
        [SerializeField] private float rotationsToDoubleInSize = 15f;

        private void Awake()
        {
            sc = GetComponent<SphereCollider>();
            rb = GetComponent<Rigidbody>();
            CalculateMass();
        }

        private void Update()
        {
            CalculateSize();
            CalculateMass();
            HandleParticleSystem();
        }

        private void HandleParticleSystem()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, sc.radius * currentSize + 0.5f))
            {
                ps.transform.position = hit.point;
                ps.transform.rotation = Quaternion.identity;
            }
        }

        private void FixedUpdate()
        {
            completedRotations += rb.angularVelocity.magnitude * Time.fixedDeltaTime; // Add our current angular speed to the number of completed rotations.
        }

        private void CalculateMass()
        {
            const float SPHERE_VOLUME_CONSTANT = 4 * Mathf.PI / 3;
            var r = sc.radius * currentSize;
            rb.mass = DENSITY_OF_SNOWBALL * SPHERE_VOLUME_CONSTANT * r * r * r; // Multiplying by r 3 times is faster than Mathf.Pow.
        }

        private void CalculateSize()
        {
            currentSize = 1 + completedRotations / rotationsToDoubleInSize;

            transform.localScale = Vector3.one * currentSize;
        }
    }
}
