using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRecipe : MonoBehaviour
{
     public GameObject Recipe11;
     public GameObject Recipe12;
     public GameObject Recipe13;
     public GameObject Recipe21;
     public GameObject Recipe22;
     public GameObject Recipe23;
     public GameObject Recipe31;
     public GameObject Recipe32;
     public GameObject Recipe33;
     // Start is called before the first frame update
     void Start()
     {
          Recipe11.SetActive(false);
          Recipe12.SetActive(false);
          Recipe13.SetActive(false);
          Recipe21.SetActive(false);
          Recipe22.SetActive(false);
          Recipe23.SetActive(false);
          Recipe31.SetActive(false);
          Recipe32.SetActive(false);
          Recipe33.SetActive(false);
     }

     public void OnRecipe(int i, int j)
     {
          switch(i)
          {
               case 1:
                    switch (j)
                    {
                         case 1:
                              Recipe11.SetActive(true);
                              break;
                         case 2:
                              Recipe12.SetActive(true);
                              break;
                         case 3:
                              Recipe13.SetActive(true);
                              break;
                    }
                    break;
               case 2:
                    switch (j)
                    {
                         case 1:
                              Recipe21.SetActive(true);
                              break;
                         case 2:
                              Recipe22.SetActive(true);
                              break;
                         case 3:
                              Recipe23.SetActive(true);
                              break;
                    }
                    break;
               case 3:
                    switch (j)
                    {
                         case 1:
                              Recipe31.SetActive(true);
                              break;
                         case 2:
                              Recipe32.SetActive(true);
                              break;
                         case 3:
                              Recipe33.SetActive(true);
                              break;
                    }
                    break;
          }
     }


     public void OffRecipe(int i, int j)
     {
          switch (i)
          {
               case 1:
                    switch (j)
                    {
                         case 1:
                              Recipe11.SetActive(false);
                              break;
                         case 2:
                              Recipe12.SetActive(false);
                              break;
                         case 3:
                              Recipe13.SetActive(false);
                              break;
                    }
                    break;
               case 2:
                    switch (j)
                    {
                         case 1:
                              Recipe21.SetActive(false);
                              break;
                         case 2:
                              Recipe22.SetActive(false);
                              break;
                         case 3:
                              Recipe23.SetActive(false);
                              break;
                    }
                    break;
               case 3:
                    switch (j)
                    {
                         case 1:
                              Recipe31.SetActive(false);
                              break;
                         case 2:
                              Recipe32.SetActive(false);
                              break;
                         case 3:
                              Recipe33.SetActive(false);
                              break;
                    }
                    break;
          }
     }
}
