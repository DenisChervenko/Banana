using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using System.Runtime.CompilerServices;

public class ViewBanana : MonoBehaviour
{
    [SerializeField] private CanvasGroup _inventoryCanvas;
    [SerializeField] private CanvasGroup _viewCanvas;

    private bool _isInventoryVisible = true;

    [SerializeField] private Image _bananaIcon;
    [SerializeField] private TMP_Text _bananaName;

    [Inject] private EventController _eventController;

    BananaBase _bananaBase;

    public void ShowBanana(BananaBase banana)
    {
        _bananaBase = banana;

        _bananaIcon.sprite = _bananaBase.icon;
        _bananaName.text = _bananaBase.name;

        CanvasState();
    }
    public void HideBanana() => CanvasState();
        
    private void CanvasState()
    {
        if(_isInventoryVisible)
        {
            _inventoryCanvas.DOFade(0, 0.4f).OnComplete(() => _viewCanvas.DOFade(1, 0.4f));
            _isInventoryVisible = false;
        }
        else
        {
            _inventoryCanvas.DOFade(1, 0.4f).OnComplete(() => _viewCanvas.DOFade(0, 0.4f).OnComplete(() =>
            {
                _bananaIcon.sprite = null;
                _bananaName.text = null;
            }));
            _isInventoryVisible = true;
        }

        _inventoryCanvas.interactable = !_inventoryCanvas.interactable;
        _inventoryCanvas.blocksRaycasts = !_inventoryCanvas.blocksRaycasts;

        _viewCanvas.interactable = !_viewCanvas.interactable;
        _viewCanvas.blocksRaycasts = !_viewCanvas.blocksRaycasts;
    }

    private void OnEnable() => _eventController.onBananaShow += ShowBanana;
    private void OnDisable() => _eventController.onBananaShow -= ShowBanana;

}
