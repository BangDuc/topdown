using System.Collections.Generic;
using UnityEngine;

public interface IServiceDetectPlayer
{
    bool isDetect();
    GameObject GetPlayer();

}
public interface IServiceDetectGameObject
{
    bool isDetect();
    List<GameObject> Get();
}