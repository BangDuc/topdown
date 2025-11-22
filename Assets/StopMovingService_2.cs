using UnityEngine;

public class StopMovingService_2 : MonoBehaviour, IServiceStopMoving
{
    
    public void SetRigidbody(Rigidbody2D rb_need_stop)
    {
        rb_need_stop.linearDamping = 5f;
    }

    public void StopMoving()
    {
        return;
    }

    
}
