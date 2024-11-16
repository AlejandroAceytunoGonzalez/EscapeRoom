using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonRune : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorDisplay;
    [SerializeField] private GameObject correctEffect;
    [SerializeField] private GameObject loseEffect;
    [SerializeField] private GameObject winEffect;
    [SerializeField] private float effectDuration = 0.3f;

    public void Push(bool isGameActive)
    {
        if (isGameActive)
        {
            animator.SetTrigger("Push");
        }
        else
        {
            animator.SetTrigger("Blocked");
        }
    }
    public void Display()
    {
        animatorDisplay.SetTrigger("Display");
    }
    public void CorrectEffect()
    {
        correctEffect.SetActive(true);
        StartCoroutine(DeactivateAfterDelay(correctEffect, effectDuration));
    }

    public void LoseEffect()
    {
        loseEffect.SetActive(true);
        StartCoroutine(DeactivateAfterDelay(loseEffect, effectDuration));
    }

    public void WinEffect()
    {
        winEffect.SetActive(true);
        StartCoroutine(DeactivateAfterDelay(winEffect, effectDuration));
    }

    private IEnumerator DeactivateAfterDelay(GameObject effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        effect.SetActive(false);
    }

}
