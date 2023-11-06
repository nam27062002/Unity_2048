using Configs;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer colorRenderer;
    [SerializeField] private TextMeshPro text;
    public int Value { get; set; }
    public void Init(BlockType blockType)
    {
        Value = blockType.value;
        text.text = Value.ToString();
        colorRenderer.color = blockType.color;
    }
}
