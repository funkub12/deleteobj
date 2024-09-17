using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EnablePostProcessing : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public PostProcessProfile postProcessProfile;
    private Bloom bloomLayer = null;

    void Start()
    {
        if (postProcessProfile == null)
        {
            // หากไม่มีโปรไฟล์ ให้สร้างใหม่ใน runtime
            postProcessVolume = gameObject.AddComponent<PostProcessVolume>();
            postProcessVolume.isGlobal = true;
            postProcessProfile = ScriptableObject.CreateInstance<PostProcessProfile>();

            // Add Bloom effect
            bloomLayer = postProcessProfile.AddSettings<Bloom>();
            bloomLayer.intensity.value = 5f;
            bloomLayer.threshold.value = 1f;

            postProcessVolume.profile = postProcessProfile;
        }
        else
        {
            // หากมีโปรไฟล์อยู่แล้ว ให้ใช้โปรไฟล์ที่เลือก
            postProcessVolume = gameObject.AddComponent<PostProcessVolume>();
            postProcessVolume.isGlobal = true;
            postProcessVolume.profile = postProcessProfile;
        }
    }
}
