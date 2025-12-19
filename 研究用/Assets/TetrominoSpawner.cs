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
            Debug.Log("ySpawnerzSpaceƒL[‚ª‰Ÿ‚³‚ê‚½");

            if (!hasActiveTetromino)
            {
                Debug.Log("ySpawnerzSpawnğŒOKASpawn()ŒÄ‚Ño‚µ");
                Spawn();
            }
            else
            {
                Debug.Log("ySpawnerz‚·‚Å‚ÉƒAƒNƒeƒBƒu‚ÈƒeƒgƒŠƒ~ƒm‚ª‚ ‚é");
            }
        }
    }

    public void Spawn()
    {
        if (tetrominoPrefabs.Length == 0)
        {
            Debug.LogError("ySpawnerztetrominoPrefabs ‚ª‹ó‚Å‚·");
            return;
        }

        int index = Random.Range(0, tetrominoPrefabs.Length);
        Debug.Log("ySpawnerzSpawn index = " + index);

        Instantiate(
            tetrominoPrefabs[index],
            spawnPoint.position,
            Quaternion.identity
        );

        hasActiveTetromino = true;
        Debug.Log("ySpawnerzƒXƒ|[ƒ“Š®—¹");
    }

    public void OnTetrominoLocked()
    {
        Debug.Log("ySpawnerzTetromino Locked ¨ Ÿ‚ğƒXƒ|[ƒ“‰Â”\");
        hasActiveTetromino = false;
    }
}
