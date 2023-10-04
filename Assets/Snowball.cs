using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    private const float _timeToDestroy = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (DataColliders.OnObstacleActions.TryGetValue(other,out var action))
            action?.Invoke();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        var particles = Instantiate(_particles,transform.position,Quaternion.identity);
        particles.Play();
        Destroy(particles.gameObject,_timeToDestroy);
    }
}
