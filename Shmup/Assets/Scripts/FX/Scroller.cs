using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10f;
    [SerializeField] private new Renderer renderer;

    private void Update()
    {
        renderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
