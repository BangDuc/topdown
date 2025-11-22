using UnityEngine;

public class StopMovingService : MonoBehaviour, IServiceStopMoving
{
    Rigidbody2D rb;

    public void StopMoving()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
    public void SetRigidbody( Rigidbody2D rigid2d_needStop)
    {
        rb = rigid2d_needStop;
    }
}
