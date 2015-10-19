using UnityEngine;
using System.Collections;
using InControl;

public class PlayerActions : PlayerActionSet
{
    public PlayerAction LeftMove;
    public PlayerAction RightMove;
    public PlayerAction UpMove;
    public PlayerAction DownMove;

    public PlayerAction LeftAim;
    public PlayerAction RightAim;
    public PlayerAction UpAim;
    public PlayerAction DownAim;

	public PlayerAction Shoot;
    public PlayerTwoAxisAction Move;
    public PlayerTwoAxisAction Aim;

    public PlayerActions()
    {
        //Move
        LeftMove  = CreatePlayerAction("Move Left");
        RightMove = CreatePlayerAction("Move Right");
        UpMove    = CreatePlayerAction("Move Up");
        DownMove  = CreatePlayerAction("Move Down");
        Move      = CreateTwoAxisPlayerAction(LeftMove, RightMove, DownMove, UpMove);

        //Aim
        LeftAim  = CreatePlayerAction("Aim Left");
        RightAim = CreatePlayerAction("Aim Right");
        UpAim    = CreatePlayerAction("Aim Up");
        DownAim  = CreatePlayerAction("Aim Down");
        Aim      = CreateTwoAxisPlayerAction(LeftAim, RightAim, DownAim, UpAim);

        //Shoot 
        Shoot = CreatePlayerAction("Shoot");
    }

    public static PlayerActions Create()
    {
        PlayerActions playerActions = new PlayerActions();

		//Move
        playerActions.LeftMove.AddDefaultBinding(Key.LeftArrow);
        playerActions.RightMove.AddDefaultBinding(Key.RightArrow);
        playerActions.UpMove.AddDefaultBinding(Key.UpArrow);
        playerActions.DownMove.AddDefaultBinding(Key.DownArrow);

        playerActions.LeftMove.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerActions.RightMove.AddDefaultBinding(InputControlType.LeftStickRight);
        playerActions.UpMove.AddDefaultBinding(InputControlType.LeftStickUp);
        playerActions.DownMove.AddDefaultBinding(InputControlType.LeftStickDown);

        playerActions.LeftMove.AddDefaultBinding(InputControlType.DPadLeft);
        playerActions.RightMove.AddDefaultBinding(InputControlType.DPadRight);
        playerActions.UpMove.AddDefaultBinding(InputControlType.DPadUp);
        playerActions.DownMove.AddDefaultBinding(InputControlType.DPadDown);

        //Aim
        playerActions.LeftAim.AddDefaultBinding(InputControlType.RightStickLeft);
        playerActions.RightAim.AddDefaultBinding(InputControlType.RightStickRight);
        playerActions.UpAim.AddDefaultBinding(InputControlType.RightStickUp);
        playerActions.DownAim.AddDefaultBinding(InputControlType.RightStickDown);

		//Shoot
		playerActions.Shoot.AddDefaultBinding(Key.LeftControl);
        playerActions.Shoot.AddDefaultBinding(InputControlType.RightBumper);
        playerActions.Shoot.AddDefaultBinding(InputControlType.RightTrigger);

		//Misc
        playerActions.ListenOptions.IncludeUnknownControllers = true;

        return playerActions;
    }
}
