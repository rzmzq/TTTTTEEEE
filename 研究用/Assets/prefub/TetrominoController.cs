using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    public float fallInterval = 1.0f;
    public float lockDelay = 0.5f;

    private float fallTimer = 0f;
    private float lockTimer = 0f;
    private bool isGrounded = false;

    void Update()
    {
        fallTimer += Time.deltaTime;

        if (fallTimer >= fallInterval)
        {
            fallTimer = 0f;

            if (CanMove(Vector3.down))
            {
                Move(Vector3.down);
                isGrounded = false;
                lockTimer = 0f;
            }
            else
            {
                isGrounded = true;
            }
        }

        if (isGrounded)
        {
            lockTimer += Time.deltaTime;
            if (lockTimer >= lockDelay)
            {
                LockTetromino();
            }
        }
    }

    void Move(Vector3 dir)
    {
        transform.position += dir;
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            0
        );
    }

    bool CanMove(Vector3 dir)
    {
        foreach (Transform block in transform)
        {
            Vector2 pos = block.position + dir;

            if (!GridManager.IsInsideGrid(pos))
            {
                Debug.Log("Outside Grid: " + pos);
                return false;
            }

            if (!GridManager.IsCellEmpty(pos))
            {
                Debug.Log("Cell Not Empty: " + pos);
                return false;
            }
        }
        return true;
    }

    void LockTetromino()
    {
        foreach (Transform block in transform)
        {
            Vector2 pos = new Vector2(
                Mathf.Round(block.position.x),
                Mathf.Round(block.position.y)
            );

            if (pos.y >= GridManager.height)
                continue;

            GridManager.grid[(int)pos.x, (int)pos.y] = block;
        }

        FindObjectOfType<TetrominoSpawner>().OnTetrominoLocked();
        enabled = false;
    }
}
