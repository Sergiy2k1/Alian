namespace Service.Input
{
    public class MobileInputService: IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        public float GetHorizontal() => SimpleInput.GetAxisRaw(Horizontal);

        public float GetVertical() => SimpleInput.GetAxisRaw(Vertical);
    }
}