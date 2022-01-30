using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected SpriteFlipper _spriteFlipper;

    public ColorChangeController _colorChange;

    public Room room;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        _spriteFlipper = GetComponent<SpriteFlipper>();
    }

    protected bool IsTargetWithinRadius(Transform target, float radius)
    {
        float distance = Vector2.Distance(target.position, transform.position);
        return distance < radius;
    }
}
