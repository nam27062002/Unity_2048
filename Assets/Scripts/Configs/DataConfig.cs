using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu()]
    public class DataConfig : ScriptableObject
    {
        [SerializeField] [Range(3,8)] private int width = 4;
        [SerializeField] [Range(3,8)] private int height = 4;
        [SerializeField] [Range(0f,1f)] private float probability = 0.8f;
        [SerializeField] private List<BlockType> blockTypes;

        public int Width => width;
        public int Height => height;
        
        public List<BlockType> BlockTypes => blockTypes;
        public float Probability => probability;
        public BlockType GetBlockTypeByValue(int value) => blockTypes.First(t => t.value == value);
    }
}