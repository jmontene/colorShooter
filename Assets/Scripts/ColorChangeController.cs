using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeController : MonoBehaviour
{
    public float transformationTime = 0.1f;

    private Animator animator;
    private bool changing;
    private bool isPink;

    private int whiteLayerIndex;

    void Awake() {
        animator = GetComponent<Animator>();
        changing = false;
        isPink = true;
        whiteLayerIndex = animator.GetLayerIndex("White");
    }

    public void Change() {
        if (!changing) {
            StartCoroutine(ChangeCo());
        }
    }

    public bool IsChanging() {
        return changing;
    }

    private IEnumerator ChangeCo() {
        changing = true;
        animator.SetBool("Transforming", true);
        yield return new WaitForSeconds(transformationTime);
        changing = false;
        animator.SetBool("Transforming", false);
        isPink = !isPink;
        animator.SetLayerWeight(whiteLayerIndex, isPink ? 0f : 1f);
    }
}
