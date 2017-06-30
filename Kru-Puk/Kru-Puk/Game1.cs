using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
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

      SoundEffect[] KruSounds = new SoundEffect[5];
      KruSounds[0] = Content.Load<SoundEffect>("Kru_Fire");
      KruSounds[1] = Content.Load<SoundEffect>("Kru_Reload1");
      KruSounds[2] = Content.Load<SoundEffect>("Kru_Reload2");
      KruSounds[3] = Content.Load<SoundEffect>("Scream");

      


      Texture2D[][] zombieAnimations = new Texture2D[4][];
      zombieAnimations[0] = new Texture2D[3]; // zombie walking animation array
      zombieAnimations[0][0] = Content.Load<Texture2D>("zombie_idle");
      zombieAnimations[0][1] = Content.Load<Texture2D>("zombie_walk1");
      zombieAnimations[0][2] = Content.Load<Texture2D>("zombie_walk2");
      zombieAnimations[1] = new Texture2D[3];
      zombieAnimations[1][0] = Content.Load<Texture2D>("damaged_zombie_idle");
      zombieAnimations[1][1] = Content.Load<Texture2D>("damaged_zombie_walk1");
      zombieAnimations[1][2] = Content.Load<Texture2D>("damaged_zombie_walk2");
      zombieAnimations[2] = new Texture2D[3];
      zombieAnimations[2][0] = Content.Load<Texture2D>("zombie_attack1");
      zombieAnimations[2][1] = Content.Load<Texture2D>("zombie_attack2");
      zombieAnimations[2][2] = Content.Load<Texture2D>("zombie_attack3");
      zombieAnimations[3] = new Texture2D[3];
      zombieAnimations[3][0] = Content.Load<Texture2D>("damaged_zombie_attack1");
      zombieAnimations[3][1] = Content.Load<Texture2D>("damaged_zombie_attack2");
      zombieAnimations[3][2] = Content.Load<Texture2D>("damaged_zombie_attack3");

      Texture2D[][] playerAnimations = new Texture2D[1][];
      playerAnimations[0] = new Texture2D[3];
      playerAnimations[0][0] = Content.Load<Texture2D>("kru_idle");
      playerAnimations[0][1] = Content.Load<Texture2D>("kru_walk1");
      playerAnimations[0][2] = Content.Load<Texture2D>("kru_walk2");

      Texture2D[] levelBackgrounds = new Texture2D[1];
      levelBackgrounds[0] = Content.Load<Texture2D>("LegendOfKruMainPlain");

      Texture2D[] assets = new Texture2D[0];
      // assets[0] = Content.Load<Texture2D>("name_of_file");

      Texture2D[] button = new Texture2D[2];
      button[0] = Content.Load<Texture2D>("button");
      button[1] = Content.Load<Texture2D>("button_clicked");

      Texture2D[][] areas = new Texture2D[1][];
      areas[0] = new Texture2D[2]; //this is the list for specific areas (not yet discovered texture / discovered texture)
      // areas[0][0] = Content.Load<Texture2D>("name_of_file");
      // areas[0][1] = Content.Load<Texture2D>("name_of_file");

      Texture2D[] platforms = new Texture2D[2];
      platforms[0] = Content.Load<Texture2D>("Outline_Horizontal_NO");
      platforms[1] = Content.Load<Texture2D>("Outline_Vertical");

      Texture2D projectile = Content.Load<Texture2D>("bullet");

      Texture2D logo = Content.Load<Texture2D>("TheLegendOfKruLogo");

      Texture2D menuBackground = Content.Load<Texture2D>("LegendOfKruMainPlain");

      Texture2D assaultRifle = Content.Load<Texture2D>("kru_idle"); // WRONG TEXTURE

      Texture2D backboard = Content.Load<Texture2D>("kru_idle"); //WRONG TEXTURE

      Window window = new Window(spriteBatch.GraphicsDevice);

      main = new Main(this, window, font, zombieAnimations, levelBackgrounds, assets, areas, logo, menuBackground, button, platforms, projectile, playerAnimations, assaultRifle, backboard, KruSounds); // textures here

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
            ControlHandler.MoveLeft(main.GetPlayer());
          //Move player right
          if (state.ThumbSticks.Left.X > 0.0f)
            ControlHandler.MoveRight(main.GetPlayer());

          /*
          //Move crosshair up
          if (state.ThumbSticks.Right.Y > 0.0f)
          {
            ControlHandler.GunUp();
          }
          //Move crosshair down
          if (state.ThumbSticks.Right.Y < 0.0f)
          {
            ControlHandler.GunDown();
          }
          */

          //Player Jump
          if (state.IsButtonDown(Buttons.A))
            ControlHandler.Jump(main.GetPlayer());


          //ACTIONS
          //Fire + Vibrate FOR RIGHT TRIGGER
          if (state.IsButtonDown(Buttons.RightTrigger))
          {
            ControlHandler.Fire(main.GetPlayer());
            GamePad.SetVibration(PlayerIndex.One, 0.4f, 0.4f);
          }
          else
          { GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f); }

          //Reload
          if (state.IsButtonDown(Buttons.RightStick))
            ControlHandler.Reload(main.GetPlayer());
          if (state.IsButtonDown(Buttons.X))
            ControlHandler.Reload(main.GetPlayer());

          //Interact
          if (state.IsButtonDown(Buttons.B))
            ControlHandler.Interact(main.GetPlayer());
        }
      }

      else //KEYBOARD INPUT
      {
        //ACTIONS
        //RELOAD
        if (Keyboard.GetState().IsKeyDown(Keys.R))
          ControlHandler.Reload(main.GetPlayer());
        //INTERACT
        if (Keyboard.GetState().IsKeyDown(Keys.E))
          ControlHandler.Interact(main.GetPlayer());
        //FIRE
        if (Keyboard.GetState().IsKeyDown(Keys.Space))
          ControlHandler.Fire(main.GetPlayer());

        //MOVEMENT
        //JUMP
        if (Keyboard.GetState().IsKeyDown(Keys.W))
          ControlHandler.Jump(main.GetPlayer());
        //MOVE LEFT
        if (Keyboard.GetState().IsKeyDown(Keys.A))
          ControlHandler.MoveLeft(main.GetPlayer());
        //MOVE RIGHT
        if (Keyboard.GetState().IsKeyDown(Keys.D))
          ControlHandler.MoveRight(main.GetPlayer());

        /*
        //CROSSHAIR
        //MOVE CROSSHAIR UP
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
          ControlHandler.GunUp();
        //MOVE CROSSHAIR DOWN
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
          ControlHandler.GunDown();
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
