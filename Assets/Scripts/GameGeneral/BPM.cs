using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPM : MonoBehaviour
{
    #region Properties
    [SerializeField] public float _bpm;
    [SerializeField] float _timeToShoot;
    [SerializeField] float _offsetTimer;

    [SerializeField] AudioSource beatSound;
    [SerializeField] AudioSource bgAudio;

    public float _BpmTimer;
    private bool _okToShoot;
    private float timeToShoot => _timeToShoot / 2;
    public float BpmTimer { get { return _BpmTimer; } }
    public bool okToShoot { get { return _okToShoot; } }
    public float offsetTimer { get { return _offsetTimer; } }
    public float bpm { get { return _bpm; } }
    #endregion

    public Image beatIndicator;

    private void OnEnable()
    {
        _BpmTimer = BpmToSeconds();
        StartCoroutine(Offset(_offsetTimer));
    }

    float BpmToSeconds()
    {
        return 60 / _bpm;
    }

    IEnumerator Offset(float offset)
    {
        bgAudio.Play();

        float timePassed = 0;
        while (timePassed < offset)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(BPMBehaviour(timePassed - offset));
    }

    IEnumerator BPMBehaviour(float extra)
    {
        //when reaching x > y, just remove y from next x, not set x=0
        _BpmTimer = BpmToSeconds();
        float timePassed = extra;
        while (timePassed < BpmTimer)
        {
            timePassed += Time.deltaTime;
            if (!_okToShoot && BpmTimer - timePassed <= timeToShoot)
            {
                _okToShoot = true;
            }
            yield return null;
        }

        Events.OnBeat.Invoke();

        StartCoroutine(OkToShoot(timePassed - BpmTimer));
        StartCoroutine(BPMBehaviour(timePassed - BpmTimer));

        if (_BpmTimer <= timeToShoot)
        {
            Debug.LogError("WARNING BPM timer is smaller than time to Shoot.");
        }
    }
    IEnumerator OkToShoot(float time)
    {
        //the "extra space" for shooting should be both before & after the beat
        //don't use corutines.

        beatIndicator.enabled = true;
        beatSound.Play();

        float timePassed = time;
        while (timePassed < timeToShoot)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }

        _okToShoot = false;
        beatIndicator.enabled = false;
    }
}
