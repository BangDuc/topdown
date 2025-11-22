using singleton_bang;
using UnityEngine;

public class Player_Manager : Singleton_Monobehaviour<Player_Manager>
{
    [SerializeField]
    private GameObject _player;

    public GameObject Player=> _player;

    protected override void Awake()
    {
        base.Awake();
        var list_tag_player = GameObject.FindGameObjectsWithTag("Player");
        _player = list_tag_player[0];
    }
    void Update()
    {
        
    }
}
