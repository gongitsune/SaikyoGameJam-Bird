using System.Collections.Generic;
using Projects.Scripts.Common;
using Projects.Scripts.Player;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Projects.Scripts.Structures
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] levelPrefab;
        [SerializeField] private PlayerController player;
        [SerializeField] private float scanInterval = 0.5f;
        [SerializeField] private float maxRadius = 30f;
        [SerializeField] private float levelSize;
        [SerializeField] private Vector3 scale;
        private readonly List<Transform> _generated = new();
        private float _lastScanTime, _lastGenerateTime;

        private ObjectPool<GameObject> _pool;

        private void Start()
        {
            _pool = new ObjectPool<GameObject>(() =>
            {
                var randomIndex = Random.Range(0, levelPrefab.Length);
                var level = Instantiate(levelPrefab[randomIndex]);
                level.transform.localScale = scale;
                return level;
            }, obj => obj.SetActive(true), obj => obj.SetActive(false));
        }

        private void Update()
        {
            DestroyScan();
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            if (Time.time - _lastGenerateTime < scanInterval) return;
            _lastGenerateTime = Time.time;

            var positions = new Vector3[]
            {
                new(0, 0, 0),
                new(-levelSize, 0, 0),
                new(levelSize, 0, 0),
                new(0, 0, -levelSize),
                new(0, 0, levelSize),
                new(-levelSize, 0, -levelSize),
                new(levelSize, 0, -levelSize),
                new(-levelSize, 0, levelSize),
                new(levelSize, 0, levelSize)
            };

            var playerPos = player.transform.position;
            playerPos.y = 0;
            foreach (var position in positions)
            {
                var offsetPos = ((position + playerPos) / levelSize).Floor() * levelSize;
                if ((offsetPos - playerPos).sqrMagnitude > maxRadius * maxRadius) continue;
                if (_generated.Exists(structure => structure.position == offsetPos)) continue;

                var randomIndex = Random.Range(0, levelPrefab.Length);
                var level = _pool.Get();
                level.transform.position = offsetPos;
                level.transform.localScale = scale;
                _generated.Add(level.transform);
            }
        }

        private void DestroyScan()
        {
            if (Time.time - _lastScanTime < scanInterval) return;
            _lastScanTime = Time.time;

            var playerPos = player.transform.position;
            _generated.ForEach(structure =>
            {
                if ((structure.position - playerPos).sqrMagnitude > maxRadius * maxRadius)
                    _pool.Release(structure.gameObject);
            });
            _generated.RemoveAll(structure =>
                (structure.position - playerPos).sqrMagnitude > maxRadius * maxRadius);
        }
    }
}