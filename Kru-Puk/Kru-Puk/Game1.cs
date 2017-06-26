using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
      graphics = new GraphicsDeviceManager(this);
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
      base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);

      SpriteFont font = Content.Load<SpriteFont>("testSpriteFont");

      Texture2D[] zombieWalking = new Texture2D[3]; // zombie walking animation array
      // zombieWalking[0] = Content.Load<Texture2D>("name_of_file");
      // zombieWalking[1] = Content.Load<Texture2D>("name_of_file");
      // zombieWalking[2] = Content.Load<Texture2D>("name_of_file");
      Texture2D[] levelBackgrounds = new Texture2D[0];
      // levelBackgrounds[0] = Content.Load<Texture2D>("name_of_file");
      Texture2D[] assets = new Texture2D[0];
      // assets[0] = Content.Load<Texture2D>("name_of_file");
      Texture2D[] button = new Texture2D[2];
      // button[0] = Content.Load<Texture2D>("name_of_file");
      // button[1] = Content.Load<Texture2D>("name_of_file");
      Texture2D[][] areas = new Texture2D[1][];
      areas[0] = new Texture2D[2]; //this is the list for specific areas (not yet discovered texture / discovered texture)
      // areas[0][0] = Content.Load<Texture2D>("name_of_file");
      // areas[0][1] = Content.Load<Texture2D>("name_of_file");
      Texture2D logo = Content.Load<Texture2D>("name_of_file");
      Texture2D menuBackground = Content.Load<Texture2D>("name_of_file");


      Window window = new Window(spriteBatch.GraphicsDevice);
      main = new Main(window, font, zombieWalking, levelBackgrounds, assets, areas, logo, menuBackground, button); // textures here
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

      base.Draw(gameTime);
    }
  }
}
