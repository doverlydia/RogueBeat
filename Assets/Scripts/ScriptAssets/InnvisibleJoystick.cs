using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnvisibleJoystick : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    void Start()
    {
        speedModifier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y + touch.deltaPosition.y *speedModifier, 0);
            }
        }
    }
}
