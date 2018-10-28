using System.Numerics;

namespace LED_Planer.Bind
{
    public interface IMovable : ISelectable
    {
        void SetPosition(Vector2 position);
    }
}
