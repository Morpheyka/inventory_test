using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private GameObject _inventoryWindow;

    public void OpenInventory()
    {
        _startWindow.SetActive(false);
        _inventoryWindow.SetActive(true);
    }

    public void CloseInventory()
    {
        _inventoryWindow.SetActive(false);
        _startWindow.SetActive(true);
    }
}