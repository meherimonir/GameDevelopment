using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject brickPrefab;
    public int rows = 5;
    public int columns = 8;
    public float brickSpacingX = 1.2f;
    public float brickSpacingY = 0.6f;
    public Vector2 startPosition = new Vector2(-4.8f, 3f);

    void Start()
    {
        CreateBricks();
    }

    void CreateBricks()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float x = startPosition.x + (col * brickSpacingX);
                float y = startPosition.y + (row * brickSpacingY);
                Vector3 brickPosition = new Vector3(x, y, 0);

                Instantiate(brickPrefab, brickPosition, Quaternion.identity);
            }
        }
    }
}