using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawnSystem : MonoBehaviour
{
    [Range(0, 20)] public int randomPositionRange = 10;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject dustPrefab;
    float MinX { get => -randomPositionRange / 2; }
    float MaxX { get => randomPositionRange / 2; }

    private float k = 5.0f;

    private void Start()
    {
        StartCoroutine(StartSpawnSystem());
    }

    IEnumerator StartSpawnSystem()
    {
        while (true)
        {
            GameObject objClone;

            var randomValue = Random.Range(0, 100);
            if (randomValue < 15) objClone = Instantiate(dustPrefab);
            else objClone = Instantiate(itemPrefab);
            float randomPositionX = Random.Range(MinX, MaxX);
            objClone.transform.position = new Vector2(this.transform.position.x + randomPositionX, this.transform.position.y);
            yield return new WaitForSeconds(k / randomPositionRange);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 from = new Vector3(this.transform.position.x + MinX, this.transform.position.y);
        Vector3 to = new Vector3(this.transform.position.x + MaxX, this.transform.position.y);

        Gizmos.DrawLine(from, to);
    }

}
