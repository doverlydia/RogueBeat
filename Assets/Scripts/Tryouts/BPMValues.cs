using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BPMValues : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private BPM bpm;
    private void Update()
    {
        text.text = bpm._bpm.ToString();
    }
    public void AddToBpm(int val)
    {
        bpm._bpm += val;
    }
}
