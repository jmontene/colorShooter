using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExt
{
    public static Vector3 GetDirectionTo(this Transform transform, Transform target)
    {
        return (target.position - transform.position).normalized;
    }
}
