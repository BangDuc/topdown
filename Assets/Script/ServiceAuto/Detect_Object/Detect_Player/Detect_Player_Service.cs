using UnityEngine;

public class Detect_Player_Service : MonoBehaviour, IServiceDetectPlayer
{
    [SerializeField]
    Collider2D Radius;
    [SerializeField]
    GameObject m_Player;
    public GameObject GetPlayer()
    {
        return m_Player;
    }

    public bool isDetect()
    {
       if (m_Player == null) return false;
        return true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_Player != null) return;
        if (collision.tag == "Player")
        {
            m_Player = collision.gameObject;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_Player = null;
            
        }
    }


}
