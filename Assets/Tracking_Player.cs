using UnityEngine;

public class Tracking_Player : MonoBehaviour
{
    [SerializeField]
    GameObject m_Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tracking(m_Player.transform.position);
    }
    public void Tracking(Vector2 position)
    {
        this.transform.position = position;
    }
}
