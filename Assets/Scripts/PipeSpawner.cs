using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipeLinePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float repeatTime;
    [SerializeField] float randomRange;

    private Coroutine coroutine;

    private void OnEnable()
    {
        coroutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(repeatTime);
            Vector3 random = Vector3.up * Random.Range(-randomRange, randomRange);
            // °ª * ¹æÇâ = ·£´ý??

            Instantiate(pipeLinePrefab, spawnPoint.position + random, spawnPoint.rotation);
        }
    }
}
