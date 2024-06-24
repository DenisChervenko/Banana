using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _rarity;
    [SerializeField] private Image _iconBanana;
    [SerializeField] private Image _nullIcon;

    [SerializeField] private TMP_Text _priceBananaText;
    private int _priceBanana;

    [SerializeField] private Button _saleBanana;
    [SerializeField] private Button _viewButton;

    public bool cellIsEmpty = true;
    [Inject] private EventController _eventController;

    public BananaBase currentBanana;

    public void SetCellValue(BananaBase banana)
    {
        currentBanana = banana;

        if(currentBanana == null)
        {
            Debug.Log("fuck");
            return;
        }
        
        _iconBanana.enabled = true;
        _nullIcon.enabled = false;

        _iconBanana.sprite = currentBanana.icon;
        _priceBanana = currentBanana.price;
        _priceBananaText.text = $"{_priceBanana}";

        cellIsEmpty = false;
        _saleBanana.interactable = true;
        _viewButton.interactable = true;

        _rarity.enabled = true;
        _rarity.color = currentBanana.colorRarity;
    }

    public void ClearValue()
    {
        currentBanana = null;

        _iconBanana.enabled = false;
        _nullIcon.enabled = true;
        _iconBanana.sprite = null;
        _priceBananaText.text = null;
        _priceBanana = 0;

        cellIsEmpty = true;
        _saleBanana.interactable = false;
        _viewButton.interactable = false;

        _rarity.enabled = false;
    }

    public void SaleBanana()
    {
        _eventController.onBananaSale?.Invoke(_priceBanana);
        ClearValue();
        _eventController.onBananaSort?.Invoke();
    }
}
