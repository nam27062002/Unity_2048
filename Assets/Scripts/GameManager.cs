using System.Collections.Generic;
using Blocks;
using Configs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DataConfig dataConfig;
    [SerializeField] private NodeManager nodeManager;
    [SerializeField] private BlockManager blockManager;
    [SerializeField] private SpriteRenderer boardPrefab;
    
    private void Awake()
    {
        GenerateBoard();
        nodeManager.GenerateGrid(dataConfig);
        blockManager.Init(nodeManager,dataConfig);
    }

    private void GenerateBoard()
    {
        var center = new Vector2((float)dataConfig.Width / 2 - 0.5f, (float)dataConfig.Height / 2 - 0.5f);
        var board = Instantiate(boardPrefab, center, Quaternion.identity);
        board.size = new Vector2(dataConfig.Width, dataConfig.Height);
    }
    
}