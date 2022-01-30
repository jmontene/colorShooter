using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;
    protected SpriteFlipper _spriteFlipper;

    public ColorChangeController _colorChange;

    public Room room;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        _spriteFlipper = GetComponent<SpriteFlipper>();
        health = GetComponent<Health>();
    }

    protected bool IsTargetWithinRadius(Transform target, float radius)
    {
        float distance = Vector2.Distance(target.position, transform.position);
        return distance < radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            var player = GameManager.Instance.Player;
            if (player != null && bullet.owner == player.gameObject && 
                bullet.GetComponent<BaseColorChangeController>().isPink == _colorChange.isPink)
            {
                health.TakeDamage();
                Destroy(bullet.gameObject);
            }
        }
    }
}
