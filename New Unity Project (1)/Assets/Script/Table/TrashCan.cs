using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
     GameObject ItemPoint;
     GameObject player;
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
                    Invoke("Trash", 0.5f);
               }
               isButtonDown = false;
               isPlayerEnter = false;

          }
     }
     void Trash()
     {
          GameObject ItemPtr = ItemPoint.GetComponentInChildren<Rigidbody>().gameObject;
          Destroy(ItemPtr.gameObject, 0);

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
