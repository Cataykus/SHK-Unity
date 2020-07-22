using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _radiusToNewTarget = 4;

    private Vector3 _target;

    private void Start()
    {
        SetNewTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            SetNewTarget();
    }

    private void SetNewTarget()
    {
        _target = Random.insideUnitCircle * _radiusToNewTarget;
    }
}
