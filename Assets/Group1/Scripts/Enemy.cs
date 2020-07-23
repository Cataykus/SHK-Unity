using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _movementRadius = 4;

    private Vector3 _target;

    private void Start()
    {
        InstallNewTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            InstallNewTarget();
    }

    private void InstallNewTarget()
    {
        _target = Random.insideUnitCircle * _movementRadius;
    }
}
