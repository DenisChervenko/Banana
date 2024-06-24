using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image _inventoryFull;

    [SerializeField] private Transform _parentCell;
    [SerializeField] private int _inventorySize;

    [SerializeField] private InventoryCell _inventoryCellPrefab;
    [SerializeField] private InventoryCell[] _inventoryCells;

    [Inject] private EventController _eventController;
    [Inject] private DiContainer _container;

    private void Awake()
    {
        _inventoryCells = new InventoryCell[_inventorySize];
        for(int i = 0; i < _inventoryCells.Length; i++)
            _inventoryCells[i] = _container.InstantiatePrefabForComponent<InventoryCell>(_inventoryCellPrefab, _parentCell);
    }

    public void AddItem(BananaBase banana)
    {
        foreach(var cell in _inventoryCells)
        {
            if(cell.cellIsEmpty)
            {
                _eventController.onBananaStartNotice.Invoke();

                cell.SetCellValue(banana);
                break;
            }
        }

        if(!_inventoryCells[_inventoryCells.Length - 1].cellIsEmpty)
            _inventoryFull.enabled = true;
    }

    private void SortInventory()
    {
        _inventoryFull.enabled = false;

        for(int i = 0; i < _inventoryCells.Length - 1; i++)
        {
            int nextElement = i + 1;

            if(_inventoryCells[i].cellIsEmpty && !_inventoryCells[nextElement].cellIsEmpty)
            {
                _inventoryCells[i].SetCellValue(_inventoryCells[nextElement].currentBanana);
                _inventoryCells[nextElement].ClearValue();
            }
                

            if(_inventoryCells[i].cellIsEmpty && _inventoryCells[nextElement].cellIsEmpty)
                break;
        }
    }

    private void OnEnable() 
    {
        _eventController.onBananaGet += AddItem;
        _eventController.onBananaSort += SortInventory;
    }

    private void OnDisable()
    {
        _eventController.onBananaGet -= AddItem;
        _eventController.onBananaSort -= SortInventory;
    }
}
