using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    public GameObject[] tetrominoPrefabs;
    public Transform spawnPoint;

    private bool hasActiveTetromino = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("【Spawner】Spaceキーが押された");

            if (!hasActiveTetromino)
            {
                Debug.Log("【Spawner】Spawn条件OK、Spawn()呼び出し");
                Spawn();
            }
            else
            {
                Debug.Log("【Spawner】すでにアクティブなテトリミノがある");
            }
        }
    }

    public void Spawn()
    {
        if (tetrominoPrefabs.Length == 0)
        {
            Debug.LogError("【Spawner】tetrominoPrefabs が空です");
            return;
        }

        int index = Random.Range(0, tetrominoPrefabs.Length);
        Debug.Log("【Spawner】Spawn index = " + index);

        GameObject tetromino = Instantiate(
            tetrominoPrefabs[index],
            spawnPoint.position,
            Quaternion.identity
        );

        // ★ 左右移動スクリプトを追加
        if (tetromino.GetComponent<TetrominoMove>() == null)
        {
            tetromino.AddComponent<TetrominoMove>();
        }

        hasActiveTetromino = true;
        Debug.Log("【Spawner】スポーン完了");
    }

    public void OnTetrominoLocked()
    {
        Debug.Log("【Spawner】Tetromino Locked → 次をスポーン可能");
        hasActiveTetromino = false;
    }
}
