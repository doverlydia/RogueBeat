using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerManager : RoomResponsive
{
    internal bool isOnBossFight = false;
    internal Weapon weapon;

    [SerializeField] private float speedModifier = 0.01f;
    [SerializeField] private float lerpTotouchSpeed = 10f;
    [SerializeField] private float playerDistanceFromTouch = 1f;

    int touchID;
    bool move;

    #region Depricated
    //private Image movePanel; //Depricated
    //private bool insideRoom = false; //Depricated
    #endregion

    private void Start()
    {
        Events.BossFight.UpsertListener(OnBossFight);
        weapon = GetComponentInChildren<Weapon>();

        #region MovePanel - Depricated
        // movePanel = GameObject.FindGameObjectWithTag("MovePanel").GetComponent<Image>();
        #endregion
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch currentTouch = Input.GetTouch(i);
                if (currentTouch.phase == TouchPhase.Began && CheckTouch(currentTouch.position))
                {
                    touchID = currentTouch.fingerId;
                    move = true;
                }
                if (currentTouch.fingerId == touchID && currentTouch.phase == TouchPhase.Ended)
                {
                    move = false;
                }
            }
        }
        if (move)
        {
            Movement(touchID);
        }
    }
    public bool CheckTouch(Vector2 touchPosition)
    {
        return (Vector2.Distance((Vector2)transform.TransformPoint(GameManager.Instance.shootButton.transform.position) ,touchPosition)>200);
    }
    private void Movement(int? touchToMoveWith)
    {
        if (touchToMoveWith != null)
        {
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch((int)touchToMoveWith).position);
            if (Input.GetTouch((int)touchToMoveWith).phase == TouchPhase.Stationary || Input.GetTouch((int)touchToMoveWith).phase == TouchPhase.Moved)
                transform.position = Vector3.Lerp(transform.position, new Vector3(touchWorldPos.x, touchWorldPos.y + playerDistanceFromTouch, 0), lerpTotouchSpeed * Time.deltaTime);

            #region TrackPad Movement - Depricated
            //if (RectTransformUtility.RectangleContainsScreenPoint(movePanel.rectTransform, touch.position))
            //{
            //    if (touch.phase == TouchPhase.Moved)
            //    {
            //        transform.position = new Vector3(
            //            transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y + touch.deltaPosition.y * speedModifier, 0);
            //    }
            //}
            #endregion
            Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
        }
    }

    #region roomsDerpricated
    //public override void OnRoomEnter()
    //{
    //    print("im inside a room because event");
    //    insideRoom = true;
    //}

    //public override void OnRoomExit()
    //{
    //    print("im outside a room because event");
    //    insideRoom = false;
    //}
    #endregion

    public void OnBossFight()
    {
        isOnBossFight = true;
    }

}
