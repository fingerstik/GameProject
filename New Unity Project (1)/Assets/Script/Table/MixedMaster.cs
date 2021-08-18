using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedMaster : MonoBehaviour
{
     GameObject ItemPoint;
     GameObject player;
     public GameObject SaladMix;
     public GameObject TablePoint;

     public bool isPlayerEnter;
     public bool isButtonDown;

     // Start is called before the first frame update
     void Start()
     {
          player = GameObject.FindGameObjectWithTag("Player");
          ItemPoint = GameObject.FindGameObjectWithTag("ItemPoint");
          isPlayerEnter = false;
     }

     // Update is called once per frame
     void Update()
     {
          if (isPlayerEnter && isButtonDown)
          {
               if (ItemPoint.transform.childCount != 0 && TablePoint.transform.childCount == 0)
               {
                    Invoke("SetItem", 0.5f);
               }
               else if (ItemPoint.transform.childCount == 0 && TablePoint.transform.childCount != 0)
               {
                    Invoke("GetItem", 0.5f);
               }
               else if (ItemPoint.transform.childCount != 0 && TablePoint.transform.childCount != 0)
               {
                    MakeItem();
               }
               isButtonDown = false;
               isPlayerEnter = false;

          }
     }
     void GetItem()
     {
          GameObject ItemPtr = TablePoint.GetComponentInChildren<Rigidbody>().gameObject;
          ItemPtr.transform.position = ItemPoint.transform.position;
          ItemPtr.transform.SetParent(ItemPoint.transform);
     }
     void SetItem()
     {
          GameObject ItemPtr = ItemPoint.GetComponentInChildren<Rigidbody>().gameObject;
          ItemPtr.transform.position = TablePoint.transform.position + new Vector3(0, 1.0f, 0);
          ItemPtr.transform.SetParent(TablePoint.transform);

     }
     void MakeItem()
     {
          GameObject ItemPtr1 = ItemPoint.GetComponentInChildren<Rigidbody>().gameObject;
          GameObject ItemPtr2 = TablePoint.GetComponentInChildren<Rigidbody>().gameObject;
          if ((ItemPtr1.tag == "STomato" && ItemPtr2.tag == "SSalary") || (ItemPtr1.tag == "SSalary" && ItemPtr2.tag == "STomato"))
          {
               Destroy(ItemPtr1);
               Destroy(ItemPtr2);
               Quaternion newRot = Quaternion.Euler(ItemPoint.transform.rotation.x, ItemPoint.transform.rotation.y + 90f, ItemPoint.transform.rotation.z);
               GameObject MadeItem = Instantiate(SaladMix, ItemPoint.transform.position, newRot);
               MadeItem.transform.SetParent(ItemPoint.transform);
          }
          ItemPtr1.transform.position = ItemPoint.transform.position;
          ItemPtr1.transform.SetParent(ItemPoint.transform);
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
