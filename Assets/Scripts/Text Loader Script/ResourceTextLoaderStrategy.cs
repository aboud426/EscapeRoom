using UnityEngine;

[System.Serializable]
public class ResourceTextLoaderStrategy : ITextLoaderStrategy
{
    [SerializeField] private string resourceName;

    public ResourceTextLoaderStrategy(string resourceName)
    {
        this.resourceName = resourceName;
    }

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
