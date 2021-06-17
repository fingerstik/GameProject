using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
     public Image FadeImg;
     public float FadeInTime;
     public float FadeOutTime;
    // Start is called before the first frame update
    public void StartFadeOut()
     {
          StartCoroutine("FadeOut", FadeOutTime);
     }

    // Update is called once per frame
    public void StartFadeIn()
     {
          StartCoroutine("FadeIn", FadeInTime);

     }

     IEnumerator FadeOut(float fadeOutTime)
     {
          float currentTime = 0.0f;
          while(currentTime < fadeOutTime)
          {
               FadeImg.color = new Color(0.0f, 0.0f, 0.0f, currentTime / fadeOutTime);
               currentTime += Time.deltaTime;
               yield return null;
          }
          FadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
     }

     IEnumerator FadeIn(float fadeInTime)
     {
          float currentTime = 0.0f;
          while (currentTime < fadeInTime)
          {
               FadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f - currentTime / fadeInTime);
               currentTime += Time.deltaTime;
               yield return null;
          }
          FadeImg.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
     }
}
