using Configs;
using UnityEngine;

public class SetCameraCenter : MonoBehaviour
{
    [SerializeField] private DataConfig dataConfig;
    private void Awake()
    {
        var center = new Vector2((float)dataConfig.Width / 2 - 0.5f, (float)dataConfig.Height / 2 - 0.5f);
        transform.position = new Vector3(center.x, center.y, -10);
    }
}
