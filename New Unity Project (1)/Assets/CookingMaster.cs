using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMaster : MonoBehaviour
{
     GameObject ItemPoint;
     GameObject player;
     public GameObject SlicedSalary;
     public GameObject SlicedTomato;
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
                    MakeItem();
               }
               isButtonDown = false;
               isPlayerEnter = false;

          }
     }
     void MakeItem()
     {
          GameObject ItemPtr = ItemPoint.GetComponentInChildren<Rigidbody>().gameObject;
          Debug.Log(ItemPtr.tag);
          Debug.Log("태그 소환");
          if (ItemPtr.tag == "Tomato") {
               Destroy(ItemPtr);
               Quaternion newRot = Quaternion.Euler(ItemPoint.transform.rotation.x, ItemPoint.transform.rotation.y + 90f, ItemPoint.transform.rotation.z);
               GameObject MadeItem = Instantiate(SlicedTomato, ItemPoint.transform.position, newRot);
               MadeItem.transform.SetParent(ItemPoint.transform);
          }
          else if (ItemPtr.tag == "Salary")
          {
               Destroy(ItemPtr);
               Quaternion newRot = Quaternion.Euler(ItemPoint.transform.rotation.x, ItemPoint.transform.rotation.y + 90f, ItemPoint.transform.rotation.z);
               GameObject MadeItem = Instantiate(SlicedSalary, ItemPoint.transform.position, newRot);
               MadeItem.transform.SetParent(ItemPoint.transform);
          }
          ItemPtr.transform.position = ItemPoint.transform.position;
          ItemPtr.transform.SetParent(ItemPoint.transform);
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
