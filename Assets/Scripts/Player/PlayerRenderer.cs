using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public void FlipPlayer(float moveX)
    {
        if (moveX > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveX < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
