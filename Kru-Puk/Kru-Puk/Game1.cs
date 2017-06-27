using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Kru_Puk
{
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Main main;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this)
      {
        PreferredBackBufferWidth = 1280,
        PreferredBackBufferHeight = 720
      };
      Content.RootDirectory = "Content";
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
      // TODO: Add your initialization logic here
      this.IsMouseVisible = true;
      base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);

      SpriteFont font = Content.Load<SpriteFont>("Font");

      Texture2D[] zombieWalking = new Texture2D[3]; // zombie walking animation array
      zombieWalking[0] = Content.Load<Texture2D>("zombie_idle");
      zombieWalking[1] = Content.Load<Texture2D>("zombie_walk1");
      zombieWalking[2] = Content.Load<Texture2D>("zombie_walk2");
      Texture2D[] levelBackgrounds = new Texture2D[0];
      // levelBackgrounds[0] = Content.Load<Texture2D>("name_of_file");
      Texture2D[] assets = new Texture2D[0];
      // assets[0] = Content.Load<Texture2D>("name_of_file");
      Texture2D[] button = new Texture2D[2];
      button[0] = Content.Load<Texture2D>("button");
      button[1] = Content.Load<Texture2D>("button_clicked");
      Texture2D[][] areas = new Texture2D[1][];
      areas[0] = new Texture2D[2]; //this is the list for specific areas (not yet discovered texture / discovered texture)
      // areas[0][0] = Content.Load<Texture2D>("name_of_file");
      // areas[0][1] = Content.Load<Texture2D>("name_of_file");
      Texture2D logo = Content.Load<Texture2D>("TheLegendOfKruLogo");
      Texture2D menuBackground = Content.Load<Texture2D>("LegendOfKruMainPlain");


      Window window = new Window(spriteBatch.GraphicsDevice);
      main = new Main(this, window, font, zombieWalking, levelBackgrounds, assets, areas, logo, menuBackground, button); // textures here
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
          Exit();

      // TODO: Add your update logic here
      ControlHandler controlhandler = new ControlHandler();

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
          else
          { GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f); }

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
      main.Update(gameTime.ElapsedGameTime.Milliseconds);
      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // TODO: Add your drawing code here
      spriteBatch.Begin();
      main.Draw(spriteBatch);
      spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
