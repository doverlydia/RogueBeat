using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField] GameObject shootingButtonDragger;
    [SerializeField] GameObject SetShootingButtonPanel;

    public void ActivateElement(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void DeactivateElement(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    public void SetShootingButtonPos()
    {
        GameManager.instance.shootButton.transform.localPosition = shootingButtonDragger.transform.localPosition;
        DeactivateElement(SetShootingButtonPanel);
    }
}
