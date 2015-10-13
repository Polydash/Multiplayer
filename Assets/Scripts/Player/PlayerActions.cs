using UnityEngine;
using System.Collections;
using InControl;

public class PlayerActions : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;

    public PlayerActions()
    {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }

    public static PlayerActions Create()
    {
        PlayerActions playerActions = new PlayerActions();

        playerActions.Left.AddDefaultBinding(Key.LeftArrow);
        playerActions.Right.AddDefaultBinding(Key.RightArrow);
        playerActions.Up.AddDefaultBinding(Key.UpArrow);
        playerActions.Down.AddDefaultBinding(Key.DownArrow);

        playerActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        playerActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        playerActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        playerActions.Left.AddDefaultBinding(InputControlType.DPadLeft);
        playerActions.Right.AddDefaultBinding(InputControlType.DPadRight);
        playerActions.Up.AddDefaultBinding(InputControlType.DPadUp);
        playerActions.Down.AddDefaultBinding(InputControlType.DPadDown);

        playerActions.ListenOptions.IncludeUnknownControllers = true;

        return playerActions;
    }

    private void Awake()
    {
    }
}
