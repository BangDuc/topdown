using UnityEngine;

public class DestroyObjectByHP : MonoBehaviour, IDestroyService
{
    [SerializeField] Health_Base health;
    [SerializeField] GameObject GameObjectToDestroy;
    public bool CanDestroy()
    {
        return health.IsDead;
    }

    public void Destroy()
    {
        GameObjectToDestroy.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(!CanDestroy()) return;
        Destroy();
    }


}
