using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]
public class MenuTextureScroll : MonoBehaviour
{
    public float ScrollSpeed;
    public Vector2 ScrollDirection;

    public Image ScrollImage;

    private void Start()
    {
        ScrollImage = GetComponent<Image>();
    }
    void Update()
    {
        ScrollImage.material.mainTextureOffset += -ScrollDirection.normalized * Time.deltaTime * ScrollSpeed;
       
    }
}
