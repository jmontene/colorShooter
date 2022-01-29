using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{

    [SerializeField] private bool _isFacingRight = true;
    
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CheckFacing(float xDirection)
    {
        bool flip = (_isFacingRight && xDirection < 0) || (!_isFacingRight && xDirection > 0);

        _spriteRenderer.flipX = flip;
    }
}
