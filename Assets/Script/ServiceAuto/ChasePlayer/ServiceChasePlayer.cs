using UnityEngine;

public class ServiceChasePlayer :MonoBehaviour, IChaseService
{

    [SerializeField]
    IServiceStopMoving serviceStopMoving;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float speed = 2;
    private void Start()
    {
        serviceStopMoving = GetComponent<IServiceStopMoving>();
        serviceStopMoving.SetRigidbody(rb);

    }
    public void Chase(GameObject Player)
    {
        Vector2 player_position = Player.transform.position;
        Vector2 direct = player_position - new Vector2(rb.position.x, rb.position.y);
        Vector2 direct_nor = direct.normalized;
        rb.linearVelocity = direct_nor * speed;
        if (Mathf.Abs(direct_nor.x) > 0.1f)
        {
            
            float faceDirection = Mathf.Sign(direct_nor.x);

            
            rb.transform.localScale = new Vector3(faceDirection, 1, 1);
        }
    } 
    public void Stop()
    {
        serviceStopMoving.StopMoving();
    }
}
