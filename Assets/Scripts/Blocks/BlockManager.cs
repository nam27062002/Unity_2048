using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Blocks
{
    public class BlockManager : MonoBehaviour
    {
        [SerializeField] private Block blockPrefab;
        
        private List<Block> _blocks;
        private NodeManager _nodeManager;
        private DataConfig _dataConfig;
        private int[,] _matrix;
        private void Awake()
        {
            _blocks = new List<Block>();
        }

        public void Init(NodeManager nodeManager,DataConfig dataConfig, ref int[,] matrix)
        {
            _matrix = matrix;
            _nodeManager = nodeManager;
            _dataConfig = dataConfig;
            SpawnBlock(2);
        }

        public void SpawnBlock(int amount)
        {
            var freeNodes = _nodeManager.GetFreeNode();
            foreach (var node in freeNodes.Take(amount))
            {
                var block = Instantiate(blockPrefab, node.Pos, Quaternion.identity,transform);
                block.name = SetNameBlock(node.Pos);
                var value = Random.value > _dataConfig.Probability ? 4 : 2;
                block.Init(_dataConfig.GetBlockTypeByValue(value));
                SetValueMatrix((int)node.Pos.x,(int)node.Pos.y,value);
                node.OccupiedBlock = block;
                _blocks.Add(block);
            }
            
            if (freeNodes.Count() == 1)
            {
                return;
            }
        }

        private void SetValueMatrix(int x, int y, int value)
        {
            _matrix[y, x] = value;
        }
        
        private static string SetNameBlock(Vector3 pos)
        {
            return $"Node {pos.y} - {pos.x}";
        }
        
        
    }
}