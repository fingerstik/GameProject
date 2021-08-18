using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAction : MonoBehaviour
{
     public GameObject Item;
     public GameObject ItemPoint;
     public GameObject player;

     public bool isPlayerEnter;
     public bool isButtonDown;
     // Start is called before the first frame update
     void Awake()
     {
          player = GameObject.FindGameObjectWithTag("Player");

          isPlayerEnter = false;
     }

     // Update is called once per frame
     void Update()
     {
          if(isPlayerEnter && isButtonDown)
          {
               if(ItemPoint.transform.childCount == 0)
               {
                    Invoke("ItemMake", 0.5f);
                    isButtonDown = false;
                    isPlayerEnter = false;
               }
          }
     }

     public void ItemMake() {
          Quaternion newRot = Quaternion.Euler(ItemPoint.transform.rotation.x, ItemPoint.transform.rotation.y + 90f, ItemPoint.transform.rotation.z);
          GameObject MadeItem = Instantiate(Item, ItemPoint.transform.position, newRot);
          MadeItem.transform.SetParent(ItemPoint.transform);
     }

     public void OnButtonDown()
     {
          if (isPlayerEnter)
          {
               isButtonDown = true;
          }
     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.gameObject == player)
          {
               isPlayerEnter = true;
          }
     }
     private void OnTriggerExit(Collider other)
     {
          if (other.gameObject == player)
          {
               isPlayerEnter = false;
          }
     }
}
