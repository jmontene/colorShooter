using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseColorChangeController : MonoBehaviour
{
    public bool isPink = true;
    public bool changing;

    public bool IsChanging()
    {
        return changing;
    }

    public abstract void Change();
    public abstract void UpdateColor(bool isPink);
}
