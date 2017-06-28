using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Kru_Puk
{
  static class ControlHandler //Change the Console.WriteLine for real outputs || Some possible void outputs have already been coded ||
  {
    public static void MoveLeft(IOption<Player> player)
    {
      Console.WriteLine("Move left!");
      player.Visit((currentPlayer) => currentPlayer.Move("left"), () => { });
      //player1.Move.Left();
    }

    public static void MoveRight(IOption<Player> player)
    {
      Console.WriteLine("Move Right!");
      player.Visit((currentPlayer) => currentPlayer.Move("right"), () => { });
      //player1.Move.Right();
    }

    public static void Jump(IOption<Player> player)
    {
      Console.WriteLine("Jump!");
      player.Visit((currentPlayer) => currentPlayer.Move("jump"), () => { });
      //player1.Move.Jump();
    }

    public static void GunUp(IOption<Player> player)
    {
      Console.WriteLine("Move gun up");
      player.Visit((currentPlayer) => currentPlayer.Move("gun_up"), () => { });
      //NotYetImplemented
    }

    public static void GunDown(IOption<Player> player)
    {
      Console.WriteLine("Move gun down");
      player.Visit((currentPlayer) => currentPlayer.Move("gun_down"), () => { });
      //NotYetImplemented
    }

    public static void Fire(IOption<Player> player)
    {
      Console.WriteLine("Fire!");
      player.Visit((currentPlayer) => currentPlayer.Move("fire"), () => { });
      //player1.WeaponPouch.Currentweapon.Use();
    }

    public static void Reload(IOption<Player> player)
    {
      Console.WriteLine("Reloading");
      player.Visit((currentPlayer) => currentPlayer.Move("reload"), () => { });
      //player1.WeaponPouch.Currentweapon.Reload();
    }

    public static void Interact(IOption<Player> player)
    {
      Console.WriteLine("Interacting");
      player.Visit((currentPlayer) => currentPlayer.Move("interacting"), () => { });
    }
  }
}
