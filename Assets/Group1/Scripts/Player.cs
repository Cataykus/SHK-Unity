using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedAbilityBoost;
    [SerializeField] private float _speeedAbilityDuration;

    public event UnityAction EnemyKilled;

    void Update()
    {
        Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Move(float x, float y)
    {
        float deltaTimeSpeed = _speed * Time.deltaTime;
        transform.Translate(x * deltaTimeSpeed, y * deltaTimeSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Destroy(enemy.gameObject);
            EnemyKilled?.Invoke();
            StartCoroutine(ActivateSpeedAbility());
        }
    }

    private IEnumerator ActivateSpeedAbility()
    {
        _speed *= _speedAbilityBoost;
        yield return new WaitForSeconds(_speeedAbilityDuration);
        _speed /= _speedAbilityBoost;
    }
}
