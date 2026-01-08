using UnityEngine;

public class TetrominoMove : MonoBehaviour
{
    public float moveAmount = 1f; // 1ƒ}ƒX•ª‚ÌˆÚ“®—Ê

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveAmount;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveAmount;
        }
    }
}
