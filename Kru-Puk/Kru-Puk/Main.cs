using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class Main : IDrawable, IUpdateable
  {
    private SpriteFont font;
    private EntityFactory entityfactory;
    private Menu menu;
    private Window window;
    private LevelIterator level;
    private Game game;
    private IGUI HUD;
    private bool onMenu;
    public Main(Game game, Window window, SpriteFont font, Texture2D[][] zombieAnimations, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas, Texture2D logo, Texture2D menuBackground, Texture2D[] button, Texture2D[] platforms, Texture2D projectile, Texture2D[][] playerAnimations, Texture2D assaultRifle, Texture2D backboard) // all textures
    {
      entityfactory = new EntityFactory(zombieAnimations, playerAnimations, levels, assets, areas, platforms, projectile, assaultRifle); // put all textures in here
      this.font = font; //unassigned spritefont. The font works, but idk where to use it/put it yet.
      this.window = window;
      this.menu = new Menu(this, window, logo, menuBackground, button, font);
      this.onMenu = true;
      this.game = game;
      this.HUD = new GUI(this, font, window, backboard);
      AddLevels();
    }

    public void ToggleMenu()
    {
      if (onMenu)
      {
        onMenu = false;
      }
      else
      {
        onMenu = true;
      }
    }

    public IOption<Player> GetPlayer()
    {
      return level.GetCurrent().Visit<IOption<Player>>((currentLevel) => new Some<Player>(currentLevel.GetPlayer()), () => new None<Player>());
    }

    public IOption<Level> GetLevel()
    {
      return level.GetCurrent();
    }

    public void AddLevels()
    {
      // !!! Instantiate all asset lists here !!!
      // By creating a list for each area, you can put assets into groups for each area
      // The position of the assets is based on the area's position
      Asset[] assets1 = new Asset[0];
      //assets1[0] = entityfactory.CreateAsset(new Point(0, 0), 0); // position, assettextureID
      //assets1[1] = entityfactory.CreateAsset(new Point(100, 0), 1);
      Asset[] assets2 = new Asset[0];
      //assets2[0] = entityfactory.CreateAsset(new Point(200, 200), 2);

      // by creating a list of areas, you can put areas into groups for each level
      Area[] areas = new Area[1]; // number of areas

      IEntity[] area1entities = new IEntity[1]; // number of entities
      area1entities[0] = entityfactory.CreateZombie(new Rectangle(new Point(0, 0), new Point(56, 109)));

      Platform[] area1platforms = new Platform[11];
      area1platforms[0] = entityfactory.CreatePlatform(new Rectangle(0, 680, 128, 40), 0);
      area1platforms[1] = entityfactory.CreatePlatform(new Rectangle(128, 680, 128, 40), 0);
      area1platforms[2] = entityfactory.CreatePlatform(new Rectangle(256, 680, 128, 40), 0);
      area1platforms[3] = entityfactory.CreatePlatform(new Rectangle(384, 680, 128, 40), 0);
      area1platforms[4] = entityfactory.CreatePlatform(new Rectangle(512, 680, 128, 40), 0);
      area1platforms[5] = entityfactory.CreatePlatform(new Rectangle(640, 680, 128, 40), 0);
      area1platforms[6] = entityfactory.CreatePlatform(new Rectangle(768, 680, 128, 40), 0);
      area1platforms[7] = entityfactory.CreatePlatform(new Rectangle(896, 680, 128, 40), 0);
      area1platforms[8] = entityfactory.CreatePlatform(new Rectangle(1024, 680, 128, 40), 0);
      area1platforms[9] = entityfactory.CreatePlatform(new Rectangle(1152, 680, 128, 40), 0);
      area1platforms[10] = entityfactory.CreatePlatform(new Rectangle(768, 500, 128, 40), 0);

      areas[0] = entityfactory.CreateArea(new Rectangle(0, 0, 400, 500), 0, assets1, area1entities, area1platforms); // position, width, height, areabackgroundID, assets
      //areas[1] = entityfactory.CreateArea(new Rectangle(400, 0, 400, 500), 1, assets2);

      IEntity[] entities = new IEntity[2]; // number of entities
      entities[0] = entityfactory.CreateZombie(new Rectangle(new Point(0, 0), new Point(56, 109)));
      entities[1] = entityfactory.CreateZombie(new Rectangle(new Point(window.WholeWindow().Right - 56, 0), new Point(56, 109)));

      Player player = entityfactory.CreatePlayer(new Rectangle(window.Center(), new Point(95, 128)), entityfactory.CreateStarterPouch(new IWeapon[1] { entityfactory.CreateAssaultRifle(30, 30, 10) }, 1), 60, 100);

      //SET FOLLOWING OBJECTS
      entities[0].SetFollowingObject(player);
      entities[1].SetFollowingObject(player);



      Level[] levels = new Level[1]; // number of levels
      levels[0] = entityfactory.CreateLevel(areas, new Point(0, 0), 0, 0); //areas, entities, spawnpoint, backgroundID

      //spawn new zombie if timer hits 60
      levels[0].setAction((timer) => { if (timer ==60) { timer = 0;  IZombie zombie = entityfactory.CreateZombie(new Rectangle(new Point(window.WholeWindow().Right - 65,0), new Point(56, 109))); zombie.SetFollowingObject(player); zombie.AddEntity(levels[0]); }return timer; });
      player.AddEntity(levels[0]);
      foreach (IEntity entity in entities) { entity.AddEntity(levels[0]); }
      
      this.level = new LevelIterator(levels);
  }


    public void Exit()
    {
      game.Exit();
    }

    public void Draw(SpriteBatch spritebatch)
    {
      if(onMenu)
      {
        menu.Draw(spritebatch);
      }
      else
      {
        level.GetCurrent().Visit((level) => level.Draw(spritebatch), () => Console.WriteLine("End screen!!"));
        HUD.Draw(spritebatch);
      }
    }

    public void Update(float dt)
    {
      if(onMenu)
      {
        menu.Update(dt);
      }
      else
      {
        level.GetCurrent().Visit((level) => level.Update(dt), () => Console.WriteLine("End screen!!"));
        HUD.Update(dt);
      }
    }
  }
}
