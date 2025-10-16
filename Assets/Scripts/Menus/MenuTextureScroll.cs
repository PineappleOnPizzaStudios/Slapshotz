using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(RawImage))]
public class MenuTextureScroll : MonoBehaviour
{
    [Header("Scrolling Settings")]
    public float ScrollSpeed = 0.1f;
    public Vector2 ScrollDirection = Vector2.right;

    private RawImage ScrollImage;

    private void Awake()
    {
        ScrollImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        if (ScrollImage != null)
        {
            Rect Rect = ScrollImage.uvRect;
            Rect.position += -ScrollDirection.normalized * Time.unscaledDeltaTime * ScrollSpeed;
            ScrollImage.uvRect = Rect;
        }
    }
}
