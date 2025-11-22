using UnityEngine;

public interface IServiceStopMoving
{
     void StopMoving();
     void SetRigidbody(Rigidbody2D rb_need_stop);
}
