using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    IServiceDetectPlayer serviceDetectPlayer;
    [SerializeField]
    IServiceStopMoving serviceStopMoving;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float speed = 2;
    void Start()
    {
        serviceDetectPlayer = GetComponentInChildren<IServiceDetectPlayer>();
        serviceStopMoving = GetComponentInChildren<IServiceStopMoving>();
        serviceStopMoving.SetRigidbody(rb);
    }

    // Update is called once per frame
    void Update()
    {
        Chase_Player();
    }
    public void Chase_Player()
    {
        if (serviceDetectPlayer == null) return;
        if (!serviceDetectPlayer.isDetect())
        {
            serviceStopMoving.StopMoving();
            return;
        }
        Vector2 player_position = serviceDetectPlayer.GetPlayer().transform.position;
        Vector2 direct = player_position - new Vector2(rb.position.x, rb.position.y);
        rb.linearVelocity=direct*speed;
        
    }
}

public interface IServiceStopMoving
{
     void StopMoving();
     void SetRigidbody(Rigidbody2D rb_need_stop);
}

public interface IServiceDetectPlayer
{
    bool isDetect();
    GameObject GetPlayer();

}