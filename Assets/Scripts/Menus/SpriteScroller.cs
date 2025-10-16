using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [Header("Scrolling Settings")]
    public float ScrollSpeed;
    public Vector2 ScrollDirection;

    private Material runtimeMaterial;

    void Start()
    {
        // Get sprite renderer and duplicate the material so we don’t modify shared assets
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        runtimeMaterial = new Material(sr.sharedMaterial);
        sr.material = runtimeMaterial;
    }

    void Update()
    {
        if (runtimeMaterial == null) return;

        Vector2 offset = runtimeMaterial.mainTextureOffset;
        offset += -ScrollDirection.normalized * Time.deltaTime * ScrollSpeed;
        runtimeMaterial.mainTextureOffset = offset;
    }

}
