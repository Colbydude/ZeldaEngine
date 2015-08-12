namespace ZeldaEngine
{
    public enum ComponentType
    {
        AIMovement,
        Animation,
        Camera,
        Collision,
        EnemyOctorok,
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
        Enter,
        None
    }

    public enum State
    {
        Standing,
        Walking
    }
}