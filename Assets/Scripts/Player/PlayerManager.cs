using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : RoomResponsive
{
    private Rigidbody2D rb;
    //private bool insideRoom = false;

    internal bool isOnBossFight = false;

    private Touch touch;
    private Image movePanel;
    
    [SerializeField] private float speedModifier = 0.01f;

    private Animator anim;
    internal Weapon weapon;

    private void Start()
    {
        Events.BossFight.UpsertListener(OnBossFight);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();
        movePanel = GameObject.FindGameObjectWithTag("MovePanel").GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
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

            if (!RectTransformUtility.RectangleContainsScreenPoint(movePanel.rectTransform, touch.position) && touch.phase == TouchPhase.Began)
            {
                weapon.Shoot();
            }
        }
    }

    private void Movement()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (RectTransformUtility.RectangleContainsScreenPoint(movePanel.rectTransform, touch.position))
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y + touch.deltaPosition.y * speedModifier, 0);
                }
            }
        }

        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
    }

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

    public void OnBossFight()
    {
        isOnBossFight = true;
    }

}
