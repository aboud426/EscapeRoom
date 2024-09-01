using UnityEngine;

public class TextureManager : MonoBehaviour
{
    [SerializeField] private string textureName = "MyTexture"; // Name of the texture file without the .png extension
    [SerializeField] private Material targetMaterial; // Material to which the texture will be applied

    private void Start()
    {
        ApplyTexture();
    }

    public void ApplyTexture()
    {
        // Load the texture from the Resources folder
        Texture2D texture = Resources.Load<Texture2D>($"Textures/{textureName}");

        if (texture != null)
        {
            // Ensure the target material is assigned
            if (targetMaterial != null)
            {
                // Apply the texture to the material's main texture
                targetMaterial.mainTexture = texture;
            }
            else
            {
                Debug.LogError("Target material is not assigned.");
            }
        }
        else
        {
            Debug.LogError($"Texture '{textureName}' not found in Resources/Textures.");
        }
    }
}
