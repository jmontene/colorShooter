using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorChanger : BaseColorChangeController
{
    public Color colorWhite;
    public Color colorPink;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Change()
    {
        UpdateColor(!isPink);
    }

    public override void UpdateColor(bool isPink)
    {
        this.isPink = isPink;
        _spriteRenderer.color = isPink ? colorPink : colorWhite;
    }
}
