using UnityEngine;

public interface IDestroyService
{
    bool CanDestroy();
    void Destroy();
}
