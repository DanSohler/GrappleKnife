using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFadeLerp : MonoBehaviour
{
    public IEnumerator UIElementFade(Image targetImg, TMP_Text targetText, float targetAlphaValue, float lerpDuration, bool isText)
    {
        float elapsedTime = 0;
        float startValue = targetImg.color.a;
        if (isText)
        {
            while (elapsedTime < lerpDuration)
            {
                elapsedTime += Time.deltaTime;
                float newAlpha = Mathf.Lerp(startValue, targetAlphaValue, elapsedTime / lerpDuration);
                targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, newAlpha);
                yield return null;
            }
        }
        else
        {
            while (elapsedTime < lerpDuration)
            {
                elapsedTime += Time.deltaTime;
                float newAlpha = Mathf.Lerp(startValue, targetAlphaValue, elapsedTime / lerpDuration);
                targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, newAlpha);
                yield return null;
            }
        }
        
    }
}
