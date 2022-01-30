using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;
    public float invulnerableTime = 3f;
    public float damageBlinkFreq = 0.1f;

    public float _currentInvulnerableTime = 0f;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }

        if (_currentInvulnerableTime > 0f)
        {
            _currentInvulnerableTime -= Time.deltaTime;
        }
    }

    public void TakeDamage()
    {
        if (_currentInvulnerableTime > 0f) return;

        health--;
        _currentInvulnerableTime = invulnerableTime;

        StartCoroutine(DamageBlink());
    }

    private IEnumerator DamageBlink()
    {
        while (_currentInvulnerableTime > 0f)
        {
            _spriteRenderer.enabled = false;
            yield return new WaitForSeconds(damageBlinkFreq);
            _spriteRenderer.enabled = true;
            yield return new WaitForSeconds(damageBlinkFreq);
        }
    }
}
