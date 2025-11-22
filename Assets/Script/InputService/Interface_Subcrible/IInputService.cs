using System;

public interface IInputService
{
    void Subcrible(Action action);
    void UnSubcrible(Action action);
}
