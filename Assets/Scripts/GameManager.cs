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

    private int[,] _matrix;
    private void Awake()
    {
        GenerateBoard();
        InitMatrix();
        nodeManager.GenerateGrid(dataConfig);
        blockManager.Init(nodeManager,dataConfig,ref _matrix);
        ShowMatrix();
    }

    private void InitMatrix()
    {
        _matrix = new int[dataConfig.Height,dataConfig.Width];
        for (var i = 0; i < _matrix.GetLength(0); i++)
        {
            for (var j = 0; j < _matrix.GetLength(1); j++)
            {
                _matrix[i, j] = 0;
            }
        }
    }

    private void ShowMatrix()
    {
        for (var i = _matrix.GetLength(0) - 1; i >= 0; i--)
        {
            string s = "";
            for (var j = 0; j < _matrix.GetLength(1); j++)
            {
                s += $"{_matrix[i, j]} - ";
            }
            Debug.Log(s);
        }
    }
    
    private void GenerateBoard()
    {
        var center = new Vector2((float)dataConfig.Width / 2 - 0.5f, (float)dataConfig.Height / 2 - 0.5f);
        var board = Instantiate(boardPrefab, center, Quaternion.identity);
        board.size = new Vector2(dataConfig.Width, dataConfig.Height);
    }
    
}