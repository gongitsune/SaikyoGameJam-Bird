using System.Collections.Generic;
using Projects.Scripts.Player;
using UnityEngine;

namespace Projects.Scripts.Structures
{
    public class StructureGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] structures;
        [SerializeField] private PlayerController player;
        [SerializeField] private float scanInterval = 0.5f;
        [SerializeField] private float maxRadius = 30f;
        [SerializeField] private int maxStructures = 100;

        private readonly List<Transform> _generated = new();
        private float _lastScanTime;

        private void Update()
        {
            DestroyScan();
            GenerateStructure();
        }
        
        private void GenerateStructure()
        {
            if (_generated.Count > maxStructures) return;

            var playerPos = player.transform.position;
            var structure = structures[Random.Range(0, structures.Length)];
            var pos = new Vector3(Random.Range(-maxRadius, maxRadius), 0, Random.Range(-maxRadius, maxRadius));
            var rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
            var obj = Instantiate(structure, pos + playerPos, rot);
            _generated.Add(obj.transform);
        }

        private void DestroyScan()
        {
            if (Time.time - _lastScanTime < scanInterval) return;
            scanInterval = Time.time;

            var playerPos = player.transform.position;
            _generated.RemoveAll(structure =>
                (structure.position - playerPos).sqrMagnitude > maxRadius * maxRadius);
        }
    }
}