using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballThrower : MonoBehaviour
{
    [SerializeField] private Rigidbody _snowball;
    [SerializeField] private float _speedBall;
    [SerializeField] private Transform _transformRightHand;
    [SerializeField] private SnowballCollector _snowballCollector;
    public void ThrowSnowball()
    {
        _snowballCollector.Throw();
        var snowball = Instantiate(_snowball,_transformRightHand.position,Quaternion.identity);
        snowball.AddForce(Vector3.up + transform.forward*_speedBall);
    }
}
