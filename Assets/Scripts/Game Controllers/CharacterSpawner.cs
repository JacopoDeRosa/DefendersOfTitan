using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Character _template;
    [SerializeField] private float _spawnRange;
    [SerializeField] private float _spawnRate;
    [SerializeField] private int _spawnAmount;

    private WaitForSeconds _wait;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _spawnRange);
    }

    private void Start()
    {
        StartCoroutine(SpawningRoutine());
    }
    private void SpawnCharacter()
    {
        Vector2 randomOffset = Random.insideUnitCircle * _spawnRange;
        Vector3 position = transform.position + new Vector3(randomOffset.x, 0, randomOffset.y);

        Instantiate(_template, position, transform.rotation);
    }

    private IEnumerator SpawningRoutine()
    {
        _wait = new WaitForSeconds(_spawnRate);

        for (int i = 0; i < _spawnAmount; i++)
        {
            SpawnCharacter();
            yield return _wait;
        }
    }

}