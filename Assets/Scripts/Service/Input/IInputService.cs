using UnityEngine;

namespace Service.Input
{
    public interface IInputService
    {
        float GetHorizontal();
        float GetVertical();
    }
}