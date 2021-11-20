using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerManager : RoomResponsive
{
    private Rigidbody2D rb;
    //private bool insideRoom = false;

    internal bool isOnBossFight = false;

    private Touch touch;
    private Image movePanel;

    [SerializeField] private float speedModifier = 0.01f;
    [SerializeField] private float lerpTotouchSpeed = 10f;
    [SerializeField] private float playerDistanceFromTouch = 1f;

    private Animator anim;
    internal Weapon weapon;

    private void Start()
    {
        Events.BossFight.UpsertListener(OnBossFight);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();

        #region MovePanel - Depricated
        // movePanel = GameObject.FindGameObjectWithTag("MovePanel").GetComponent<Image>();
        #endregion
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (!EventSystem.current.IsPointerOverGameObject(id))
            {
                Movement();
            }
        }

        if (Input.touchCount > 0)
        {
            if (Input.touchCount > 1)
            {
                    touch = Input.GetTouch(1);
            }
            else
            {
                    touch = Input.GetTouch(0);
            }

            #region TrackPad based shooting - Depricated

            //if (!RectTransformUtility.RectangleContainsScreenPoint(movePanel.rectTransform, touch.position) && touch.phase == TouchPhase.Began)
            //{
            //    weapon.Shoot();
            //}

            #endregion
        }
    }

    private void Movement()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
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
        }

        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
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
