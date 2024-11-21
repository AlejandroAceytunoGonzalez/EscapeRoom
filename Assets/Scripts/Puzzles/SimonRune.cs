using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonRune : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem displayEffect;
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
    public Color Display()
    {
        displayEffect.Play();
        return displayEffect.main.startColor.colorMin;
    }
    public void CorrectEffect()
    {

    }

    public void LoseEffect()
    {

    }

    public void WinEffect()
    {

    }

    private IEnumerator DeactivateAfterDelay(GameObject effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        effect.SetActive(false);
    }

}
