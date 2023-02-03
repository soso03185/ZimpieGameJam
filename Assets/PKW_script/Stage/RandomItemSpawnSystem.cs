using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawnSystem : MonoBehaviour
{
    [Range(0, 20)] public int randomPositionRange = 10;
    [SerializeField] private GameObject itemPrefab;
    //[SerializeField] private float spawnInterval = 0.5f;
    private float k = 5.0f;

    private void Start()
    {
        StartCoroutine(StartSpawnSystem());
    }

    IEnumerator StartSpawnSystem()
    {
        while (true)
        {
            var objClone = Instantiate(itemPrefab);
            float randomPositionX = Random.Range(-randomPositionRange / 2, randomPositionRange / 2);
            objClone.transform.position = new Vector2(this.transform.position.x + randomPositionX, this.transform.position.y);
            yield return new WaitForSeconds(k / randomPositionRange);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 from = new Vector3(this.transform.position.x + -randomPositionRange / 2, this.transform.position.y);
        Vector3 to = new Vector3(this.transform.position.x + randomPositionRange / 2, this.transform.position.y);

        Gizmos.DrawLine(from, to);
    }

}
