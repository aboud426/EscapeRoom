using UnityEngine;

[CreateAssetMenu(fileName = "ResourceTextLoaderStrategy", menuName = "TextLoader/ResourceTextLoaderStrategy")]
public class ResourceTextLoaderStrategySO : ScriptableObject, ITextLoaderStrategy
{
    [SerializeField] private string resourceName;

    public string LoadText()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(resourceName);
        if (textAsset != null)
        {
            return textAsset.text;
        }
        else
        {
            Debug.LogError($"Resource '{resourceName}' not found.");
            return string.Empty;
        }
    }
}
