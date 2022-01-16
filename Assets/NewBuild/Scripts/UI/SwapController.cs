using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwapController : MonoBehaviour, IDragHandler
{
    public Scrollbar scrollbar;
    private bool _isMove = false;
    private float _delta;
    
    public void OnDrag(PointerEventData eventData)
    {
        if(Math.Abs(eventData.delta.x) > 15 && !_isMove)
        {
            if (eventData.delta.x > 0 && scrollbar.value>0.1f)
            {
                _delta = -0.33f;
            }
            else if(eventData.delta.x < 0 && scrollbar.value<0.9f)
            {
                _delta = 0.33f;
            }
            else
            {
                _delta = 0;
            }
            DOTween.To(() => scrollbar.value, x => scrollbar.value = x, scrollbar.value+_delta, 0.4f).
                                OnStart((() => _isMove = true)).OnComplete((() => _isMove = false));
        }
    }
}
