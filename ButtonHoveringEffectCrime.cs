using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoveringEffectCrime : MonoBehaviour
{
    private Vector3 originalScale;
    Vector3 hoverScale = new Vector3(5f, 17.5f, 1f); // Adjust the scale as needed
    float transitionSpeed = 5f;
    Vector3 targetScale;
    public GameObject CrimeModeTextPanel;


    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
        CrimeModeTextPanel.SetActive(false);

    }

    void Update()
    {
        // Smoothly scale the button to the target scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
    }
    public void OnPointerEnter()
    {
        targetScale = hoverScale;
        StartCoroutine(CrimeModeTextEnumTrue());
    }

    public void OnPointerExit()
    {
        targetScale = originalScale;
        CrimeModeTextPanel.SetActive(false);
    }

    public IEnumerator CrimeModeTextEnumTrue()
    {
        yield return new WaitForSeconds(0.125f);

        CrimeModeTextPanel.SetActive(true);
    }
}
