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
  class ControlInput: Game
  {
    GraphicsDeviceManager graphics;
    Vector2 position;

    public ControlInput()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
      base.Initialize();

      position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);
    }
    protected override void Update(GameTime gameTime)
    {
      ControlHandler controlhandler = new ControlHandler();
      if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();


      // Check the device for Player One
      GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

      // If there a controller attached, handle it
      if (capabilities.IsConnected)
      {
        // Get the current state of Controller1
        GamePadState state = GamePad.GetState(PlayerIndex.One);

        // You can also check the controllers "type"
        if (capabilities.GamePadType == GamePadType.GamePad)
        {
          // Exit Game
          if (state.IsButtonDown(Buttons.Back))
            Exit();

          //MOVEMENT

          //Move player left
          if (state.ThumbSticks.Left.X < 0.0f)
            controlhandler.MoveLeft();
          //Move player right
          if (state.ThumbSticks.Left.X > 0.0f)
            controlhandler.MoveRight();

          /*
          //Move crosshair up
          if (state.ThumbSticks.Right.Y > 0.0f)
          {
            controlhandler.GunUp();
          }
          //Move crosshair down
          if (state.ThumbSticks.Right.Y < 0.0f)
          {
            controlhandler.GunDown();
          }
          */

          //Player Jump
          if (state.IsButtonDown(Buttons.A))
            controlhandler.Jump();


          //ACTIONS
          //Fire + Vibrate FOR RIGHT TRIGGER
          if (state.IsButtonDown(Buttons.RightTrigger))
          {
            controlhandler.Fire();
            GamePad.SetVibration(PlayerIndex.One, 0.4f, 0.4f);
          }
          else { GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f); }

          //Reload
          if (state.IsButtonDown(Buttons.RightStick))
            controlhandler.Reload();
          if (state.IsButtonDown(Buttons.X))
            controlhandler.Reload();

          //Interact
          if (state.IsButtonDown(Buttons.B))
            controlhandler.Interact();
        }
      }

      else //KEYBOARD INPUT
      {
        //ACTIONS
        //RELOAD
        if (Keyboard.GetState().IsKeyDown(Keys.R))
          controlhandler.Reload();
        //INTERACT
        if (Keyboard.GetState().IsKeyDown(Keys.E))
          controlhandler.Interact();
        //FIRE
        if (Keyboard.GetState().IsKeyDown(Keys.Space))
          controlhandler.Fire();

        //MOVEMENT
        //JUMP
        if (Keyboard.GetState().IsKeyDown(Keys.W))
          controlhandler.Jump();
        //MOVE LEFT
        if (Keyboard.GetState().IsKeyDown(Keys.A))
          controlhandler.MoveLeft();
        //MOVE RIGHT
        if (Keyboard.GetState().IsKeyDown(Keys.D))
          controlhandler.MoveRight();

        /*
        //CROSSHAIR
        //MOVE CROSSHAIR UP
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
          controlhandler.GunUp();
        //MOVE CROSSHAIR DOWN
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
          controlhandler.GunDown();
        */

      }
      base.Update(gameTime);
    }
  }
}
