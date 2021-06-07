using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHandler : MonoBehaviour
{
     bool isEnable;
     // Start is called before the first frame update
     void Start()
     {
          isEnable = false;
     }

     private void Update()
     {
          if (isEnable)
               isEnable = false;
     }

     void OnEnableDown()
     {
          isEnable = true;
     }
}
