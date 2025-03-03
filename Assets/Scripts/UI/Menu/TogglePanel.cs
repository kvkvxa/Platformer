using UnityEngine;
using UnityEngine.UI;

public class TogglePanel : MonoBehaviour
{
    [SerializeField] private GameObject _aboutPanel;
    [SerializeField] private Button _aboutButton;
    private void OnEnable()
    {
        _aboutButton.onClick.AddListener(OpenPanel);
    }

    private void OnDisable()
    {
        _aboutButton.onClick.RemoveListener(OpenPanel);
    }

    private void Update()
    {
        if (_aboutPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel();
        }
    }
    private void OpenPanel()
    {
        _aboutPanel.SetActive(true);
    }
    private void ClosePanel()
    {
        _aboutPanel.SetActive(false);
    }
}