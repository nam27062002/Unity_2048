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
        private void Awake()
        {
            _blocks = new List<Block>();
        }

        public void Init(NodeManager nodeManager,DataConfig dataConfig)
        {
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
                block.Init(_dataConfig.GetBlockTypeByValue(Random.value > _dataConfig.Probability ? 4 : 2));
                _blocks.Add(block);
            }
            
            if (freeNodes.Count() == 1)
            {
                return;
            }
        }
        
        
    }
}