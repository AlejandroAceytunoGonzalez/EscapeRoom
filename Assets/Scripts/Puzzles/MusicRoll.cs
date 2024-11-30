using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRoll : MonoBehaviour
{
    [field: SerializeField] public int intendedSet { get; set; }
    [SerializeField] private Transform separatorTransform;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] private AudioSource audioClip;
    [SerializeField] private Animator selectedAnim;
    [SerializeField] private Animator rotatingAnim;

    private MusicPuzzle musicPuzzle;
    private void Awake()
    {
        musicPuzzle = FindObjectOfType<MusicPuzzle>();
        musicPuzzle.OnSelect += StopSound;
    }

    public void PlaySound()
    {
        audioClip.Play();
        rotatingAnim.SetTrigger("Rotate");
    }
    private void StopSound()
    {
        audioClip.Stop();
        AnimatorStateInfo stateInfo = rotatingAnim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Rotating"))
        {
            rotatingAnim.SetTrigger("ForceBack");
        }
    }
    public void SelectMe()
    {
        musicPuzzle.Select(this);
    }
    public void SwitchRot(float rot)
    {
        StartCoroutine(RotateToTarget(rot));
    }
    public void SelectAnim(bool isFirst)
    {
        if (isFirst)
        {
            selectedAnim.SetBool("IsFirstSelect", true);
        }
        else
        {
            selectedAnim.SetBool("IsSecondSelect", true);
        }
    }

    public float GetRotation()
    {
        return separatorTransform.localRotation.eulerAngles.y;
    }
    private IEnumerator RotateToTarget(float targetYRotation)
    {
        float startYRotation = transform.localEulerAngles.y;
        float elapsedTime = 0f;

        if (Mathf.Abs(targetYRotation - startYRotation) > 180f)
        {
            if (targetYRotation > startYRotation)
                startYRotation += 360f;
            else
                targetYRotation += 360f;
        }

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * rotationSpeed;
            float newYRotation = Mathf.Lerp(startYRotation, targetYRotation, elapsedTime);
            Vector3 newRotation = transform.localEulerAngles;
            newRotation.y = newYRotation % 360;
            transform.localEulerAngles = newRotation;
            yield return null;
        }

        Vector3 finalRotation = transform.localEulerAngles;
        finalRotation.y = targetYRotation % 360;
        transform.localEulerAngles = finalRotation;
        selectedAnim.SetBool("IsFirstSelect", false);
        selectedAnim.SetBool("IsSecondSelect", false);
    }
}

