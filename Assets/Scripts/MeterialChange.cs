using UnityEngine;

public class MeterialChange : MonoBehaviour
{
    [SerializeField] Material skyBoxMaterial;

    void Start()
    {
        RenderSettings.skybox = skyBoxMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
