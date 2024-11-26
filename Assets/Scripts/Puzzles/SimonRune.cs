using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonRune : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Renderer rendererButton;
    [SerializeField, ColorUsage(true, true)] Color wrongColor;
    [SerializeField, ColorUsage(true, true)] private Color correctColor;
    [SerializeField, ColorUsage(true, true)] private Color winColor;
    [SerializeField] private ParticleSystem displayEffect;

    private void Awake()
    {
        Reset();
    }
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
        rendererButton.material.SetColor("_EmissionColor", correctColor);
    }

    public void LoseEffect()
    {
        rendererButton.material.SetColor("_EmissionColor", wrongColor);
    }

    public void WinEffect()
    {
        rendererButton.material.SetColor("_EmissionColor", winColor);
    }
    public void Reset()
    {
        rendererButton.material.SetColor("_EmissionColor", Color.black);
    }

    private IEnumerator DeactivateAfterDelay(GameObject effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        effect.SetActive(false);
    }

}
