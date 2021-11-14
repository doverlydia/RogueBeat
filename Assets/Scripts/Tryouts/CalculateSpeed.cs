using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateSpeed : MonoBehaviour
{
    [SerializeField] RectTransform destTrans;
    [SerializeField] RectTransform myTransform;
    [SerializeField] float beat = 0.52f;

    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 dest;
    float _speed;
    [SerializeField] float speed
    {
        get => _speed * Time.deltaTime;
        set => _speed = value;
    }
    void Start()
    {
        myTransform = GetComponent<RectTransform>();
        startPos = myTransform.position;
        dest = destTrans.position;
        speed = Vector2.Distance(startPos, dest)/beat;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.position = Vector2.Lerp(startPos, dest, speed); 
        if (Vector2.Distance(myTransform.position, dest) <= 0.1f)
        {
            myTransform.position = startPos;
        }
    }
}
