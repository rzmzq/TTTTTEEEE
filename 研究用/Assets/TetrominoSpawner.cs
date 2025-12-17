using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    public GameObject[] tetrominoPrefabs;
    public Transform spawnPoint;

    private bool hasActiveTetromino = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasActiveTetromino)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int index = Random.Range(0, tetrominoPrefabs.Length);
        Instantiate(tetrominoPrefabs[index], spawnPoint.position, Quaternion.identity);
        hasActiveTetromino = true;
    }

    public void OnTetrominoLocked()
    {
        hasActiveTetromino = false;
    }
}
