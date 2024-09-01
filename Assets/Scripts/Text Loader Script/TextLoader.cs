using UnityEngine;
using TMPro;

public class TextLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private ResourceTextLoaderStrategySO textLoaderStrategy; // Use ScriptableObject

    public void Start()
    {
        if (textLoaderStrategy != null)
        {
            LoadTextFromStrategy();
        }
        else
        {
            Debug.LogError("Text loader strategy is not set.");
        }
    }

    private void LoadTextFromStrategy()
    {
        string text = textLoaderStrategy.LoadText();
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = text;
            
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component is not assigned.");
        }
    }
}
