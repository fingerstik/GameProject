using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
     GameObject ItemPoint;
     GameObject player;
     public ScoreManager Score;
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
                    getScore();
               }
               isButtonDown = false;
               isPlayerEnter = false;
          }
     }
     void getScore()
     {
          GameObject ItemPtr = ItemPoint.GetComponentInChildren<Rigidbody>().gameObject;
          if (ItemPtr.tag == "SaladMix")
          {
               Destroy(ItemPtr);
               Score.AddScore();
          }
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
