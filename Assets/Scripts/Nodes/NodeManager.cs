using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private Node nodePrefab;
    
    private List<Node> _nodes;
    private void Awake()
    {
        _nodes = new List<Node>();
    }

    public void GenerateGrid(DataConfig dataConfig)
    {
        for (var row = 0; row < dataConfig.Height; row++)
        {
            for (var column = 0; column < dataConfig.Width; column++)
            {
                var node = Instantiate(nodePrefab, new Vector2(column, row), Quaternion.identity,transform);
                node.name = SetNameNode(column, row);
                _nodes.Add(node);
            }
        }
    }


    public IOrderedEnumerable<Node> GetFreeNode()
    {
        return _nodes.Where(n => n.OccupiedBlock == null).OrderBy(n => Random.value);
    }
    
    private static string SetNameNode(int column, int row)
    {
        return $"Node {row} - {column}";
    }
}
