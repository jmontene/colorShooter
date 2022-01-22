using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlimeEnemy : Enemy
{
    [SerializeField] private float _chaseRadius = 5f;
    [SerializeField] private float _attackRadius = 1.5f;
    [SerializeField] private float _attackChargeTime = 2f;
    [SerializeField] private float _attackDistance = 3f;
    [SerializeField] private float _attackTime = 1f;
    [SerializeField] private float _attackCooldown = 3f;
    [SerializeField] private float _movementSpeed = 1f;

    private bool _isAttacking = false;


    // Update is called once per frame
    void Update()
    {
        if (_isAttacking) return;

        var target = GameManager.Instance.Player.transform;

        if (!IsTargetWithinRadius(target, _chaseRadius)) return;

        if (IsTargetWithinRadius(target, _attackRadius))
        {
            StartCoroutine(Attack(target));
            return;
        }

        Chase(target);
    }

    private IEnumerator Attack(Transform target)
    {
        _isAttacking = true;

        yield return new WaitForSeconds(_attackChargeTime);

        var heading = transform.GetDirectionTo(target);
        var finalPosition = transform.position + heading * _attackDistance;

        yield return transform.DOMove(finalPosition, _attackTime).WaitForCompletion();

        yield return new WaitForSeconds(_attackCooldown);

        _isAttacking = false;
    }

    private void Chase(Transform target)
    {
        var heading = transform.GetDirectionTo(target);
        transform.position = transform.position + heading * _movementSpeed * Time.deltaTime;
    }
}
