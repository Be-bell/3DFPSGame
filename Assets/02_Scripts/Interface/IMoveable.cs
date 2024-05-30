using UnityEngine;

public interface IMoveable
{
    void Move(Vector2 dir);
    void Jump();
    void Roll();
}