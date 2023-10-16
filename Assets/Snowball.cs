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
        if (DataColliders.OnObjectsForObstacles.TryGetValue(other,out var action))
        {
            var position = action.Invoke();
            transform.position = new Vector3(position.x,transform.position.y,position.z);
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        var particles = Instantiate(_particles,transform.position,Quaternion.identity);
        particles.Play();
        Destroy(particles.gameObject,_timeToDestroy);
    }
}
