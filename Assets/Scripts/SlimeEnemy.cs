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
    private Animator _animator = null;
    private Rigidbody2D _rigidbody2D = null;

    override protected void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var target = GameManager.Instance.Player;

        if (target == null || _isAttacking || target.currentRoom != room) return;

        if (!IsTargetWithinRadius(target.transform, _chaseRadius)) return;

        if (IsTargetWithinRadius(target.transform, _attackRadius))
        {
            StartCoroutine(Attack(target.transform));
            return;
        }

        Chase(target.transform);
    }

    private IEnumerator Attack(Transform target)
    {
        _isAttacking = true;

        yield return new WaitForSeconds(_attackChargeTime);

        if (target == null) yield break;

        var heading = transform.GetDirectionTo(target);
        _spriteFlipper.CheckFacing(heading.x);
        var finalPosition = transform.position + heading * _attackDistance;

        _animator.SetTrigger("Attack");

        yield return _rigidbody2D.DOMove(finalPosition, _attackTime).WaitForCompletion();

        yield return new WaitForSeconds(_attackCooldown);

        _isAttacking = false;
    }

    private void Chase(Transform target)
    {
        var heading = transform.GetDirectionTo(target);
        _spriteFlipper.CheckFacing(heading.x);

        var finalPosition = transform.position + heading * _movementSpeed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(finalPosition);
    }
}
