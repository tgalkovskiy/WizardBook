using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwapController : MonoBehaviour, IDragHandler
{
    public Button bookPage;
    public Button mainPage;
    public Button spellPage;
    public Button inventoryPage;
    public Button shopPage;
    public Scrollbar scrollbar;
    private bool _isMove = false;
    private float _delta;

    private void Awake()
    {
        bookPage.onClick.AddListener(ShowSpellPage);
        mainPage.onClick.AddListener(ShowMainPage);
        spellPage.onClick.AddListener(ShowSpellPage);
        inventoryPage.onClick.AddListener(ShowInventoryPage);
        shopPage.onClick.AddListener(ShowShopPage);
    }

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
    private void ShowMainPage()
    {
        DOTween.To(() => scrollbar.value, x => scrollbar.value = x, 0, 0.4f).
            OnStart((() => _isMove = true)).OnComplete((() => _isMove = false));
    }
    private void ShowSpellPage()
    {
        DOTween.To(() => scrollbar.value, x => scrollbar.value = x, 0.33f, 0.4f).
            OnStart((() => _isMove = true)).OnComplete((() => _isMove = false));
    }
    private void ShowInventoryPage()
    {
        DOTween.To(() => scrollbar.value, x => scrollbar.value = x, 0.66f, 0.4f).
            OnStart((() => _isMove = true)).OnComplete((() => _isMove = false));
    }
    private void ShowShopPage()
    {
        DOTween.To(() => scrollbar.value, x => scrollbar.value = x, 1, 0.4f).
            OnStart((() => _isMove = true)).OnComplete((() => _isMove = false));
    }
}
