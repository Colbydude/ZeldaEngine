namespace ZeldaEngine
{
    public enum ComponentType
    {
        AIMovement,
        Animation,
        Collision,
        PlayerInput,
        Sprite
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public enum Input
    {
        Left,
        Right,
        Up,
        Down,
        None
    }

    public enum State
    {
        Standing,
        Walking
    }
}