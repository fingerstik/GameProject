using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
     public static float time;
     // Start is called before the first frame update
     void Start()
     {
          time = 11f;
     }

     // Update is called once per frame
     void Update()
     {
          if(time != 0)
          {
               time -= Time.deltaTime;
               if(time <= 0)
               {
                    time = 0;
               }
          }

          int t = Mathf.FloorToInt(time);
          Text uiText = GetComponent<Text>();
          uiText.text = "Time : " + (t/60).ToString() + ":" + (t%60).ToString();


     }
     public int GetTime()
     {
          return (int)time;
     }
}
