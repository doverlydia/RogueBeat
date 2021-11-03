using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeldDown : MonoBehaviour
{
    public bool isHeldDown = false;
    public void onPress()
    {
        isHeldDown = true;
    }

    public void onRelease()
    {
        isHeldDown = false;
    }
}
