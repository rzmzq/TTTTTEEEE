using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    public float fallInterval = 1.0f;
    public float lockDelay = 0.5f;

    float fallTimer;
    float lockTimer;
    bool isGrounded;

    void Update()
    {
        HandleInput();
        HandleFall();
        HandleLock();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("ÅyControllerÅzLeftÉLÅ[ì¸óÕ");
            TryMove(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("ÅyControllerÅzRightÉLÅ[ì¸óÕ");
            TryMove(Vector3.right);
        }
    }


    void HandleFall()
    {
        fallTimer += Time.deltaTime;

        if (fallTimer < fallInterval) return;

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

    void HandleLock()
    {
        if (!isGrounded) return;

        lockTimer += Time.deltaTime;

        if (lockTimer >= lockDelay)
            LockTetromino();
    }

    void TryMove(Vector3 dir)
    {
        if (!CanMove(dir)) return;

        Move(dir);
        isGrounded = false;
        lockTimer = 0f;
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
            Vector2 nextPos = (Vector2)block.position + (Vector2)dir;

            if (!GridManager.IsCellEmpty(nextPos))
                return false;
        }
        return true;
    }

    void LockTetromino()
    {
        foreach (Transform block in transform)
        {
            Vector2 pos = block.position;
            int x = Mathf.RoundToInt(pos.x);
            int y = Mathf.RoundToInt(pos.y);

            if (x < 0 || x >= GridManager.width) continue;
            if (y < 0 || y >= GridManager.height) continue;

            GridManager.grid[x, y] = block;
        }

        FindObjectOfType<TetrominoSpawner>().OnTetrominoLocked();
        enabled = false;
    }
}
