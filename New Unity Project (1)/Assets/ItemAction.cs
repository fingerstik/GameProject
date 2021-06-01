﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAction : MonoBehaviour
{
     public float speed = 1f;

     public GameObject player;
     public GameObject playerItemPoint;
     public GameObject Item;
     public PlayerController playerLogic;
     public Animator ani;
     public GameObject tablePoint;

     private Vector3 forceDirection;
     private bool IsPlayerEnter;
     private bool IsTableEnter;
     private bool IsEnable;
     public bool IsEmpty;
     private float Timer;
     private float WaitingTime;

     public enum ItemState
     {
          Box,
          Player,
          Table,
          Plate,
     }
     public ItemState itemState;

     public void Awake()
     {
          player = GameObject.FindGameObjectWithTag("Player");
          playerItemPoint = GameObject.FindGameObjectWithTag("ItemPoint");
          Item = GameObject.FindGameObjectWithTag("Item");
          tablePoint = GameObject.FindGameObjectWithTag("Table");

          ani = player.GetComponent<Animator>();
          playerLogic = player.GetComponent<PlayerController>();

          itemState = ItemState.Box;
          IsEnable = false;

          Timer = 0.0f;
          WaitingTime = 0.5f;
     }

     public void Update()
     {
          Timer += Time.deltaTime;
          if (Timer > WaitingTime) {
               Timer = 0;
               if (IsEnable && IsPlayerEnter)
               {
                    if (IsEmpty)
                    {
                         transform.SetParent(playerItemPoint.transform);
                         transform.localPosition = Vector3.zero;
                         transform.rotation = new Quaternion(0, 0, 0, 0);

                         IsPlayerEnter = false;
                         itemState = ItemState.Player;
                    }
               }
               if (IsEnable && IsTableEnter)
               {
                    if (!IsEmpty)
                    {
                         transform.SetParent(tablePoint.transform);
                         transform.localScale = new Vector3(0.15f, 0.36f, 0.15f);
                         transform.localPosition = Vector3.zero;
                         transform.rotation = new Quaternion(0, 0, 0, 0);

                         IsTableEnter = false;
                         itemState = ItemState.Table;
                    }
               }
               IsEnable = false;
          }
     }

     public void OnEnableDown()
     {
          if (!IsEnable)
          {
               IsEnable = true;
               ani.SetTrigger("Enable");
               IsEmpty = GetIsEmpty();
          }
     }


     private void OnTriggerEnter(Collider other)
     {
          if (other.gameObject == player)
          {
               IsPlayerEnter = true;
          }
          if (other.gameObject == tablePoint)
          {
               IsTableEnter = true;
          }
     }
     private void OnTriggerExit(Collider other)
     {
          if (other.gameObject == player)
          {
               IsPlayerEnter = false;
          }
          if (other.gameObject == tablePoint)
          {
               IsTableEnter = true;
          }
     }

     public bool GetIsEmpty()
     {
          int cCount = playerItemPoint.transform.childCount;
          return (cCount == 0 ? true : false);
     }
}