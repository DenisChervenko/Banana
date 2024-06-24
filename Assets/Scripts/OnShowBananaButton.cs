using System;
using UnityEngine;
using Zenject;

public class OnShowBananaButton : MonoBehaviour
{
    [Inject] private EventController _eventController;
    private InventoryCell _inventoryCell;

    public void OnShowBanana()
    {
        _inventoryCell = GetComponentInParent<InventoryCell>();
        _eventController.onBananaShow?.Invoke(_inventoryCell.currentBanana);
    }
}
