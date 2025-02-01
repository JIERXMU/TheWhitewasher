using MizukiTool.AStar;
using UnityEngine;

public class PaintBrushWasherController : MonoBehaviour
{
    private bool isPlayerEnter = false;
    void Update()
    {
        if (isPlayerEnter && KeyboardSet.IsKeyDown(KeyEnum.Interact))
        {
            PorpsManager.Instance.AddProp(new PropClass(this.Porp, this.ColorMod));
            Destroy(this.gameObject);
        }
    }

    public PointMod PointM
    {
        get
        {
            return SOManager.colorSO.GetPointMod(ColorMod);
        }
    }
    public ColorEnum ColorMod;
    public PorpEnum Porp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Player Enter");
            isPlayerEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Player Exit");
            isPlayerEnter = false;
        }
    }
    void OnValidate()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = SOManager.colorSO.GetColor(ColorMod);
    }
}
