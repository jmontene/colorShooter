using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeController : BaseColorChangeController
{
    public float transformationTime = 0.1f;

    private Animator animator;
    
    private int whiteLayerIndex;
    private int pinkLayerIndex;

    void Awake() {
        animator = GetComponent<Animator>();
        changing = false;
        whiteLayerIndex = animator.GetLayerIndex("White");
        pinkLayerIndex = animator.GetLayerIndex("Pink");
        SetLayerWeight();
    }

    public override void Change() {
        if (!changing) {
            StartCoroutine(ChangeCo());
        }
    }

    private IEnumerator ChangeCo() {
        changing = true;
        animator.SetBool("Transforming", true);
        yield return new WaitForSeconds(transformationTime);
        changing = false;
        animator.SetBool("Transforming", false);
        isPink = !isPink;
        SetLayerWeight();
    }

    public override void UpdateColor(bool isPink)
    {
        this.isPink = isPink;
        SetLayerWeight();
    }

    public void SetLayerWeight()
    {
        animator.SetLayerWeight(whiteLayerIndex, isPink ? 0f : 1f);
        animator.SetLayerWeight(pinkLayerIndex, isPink ? 1f : 0f);
    }
}
