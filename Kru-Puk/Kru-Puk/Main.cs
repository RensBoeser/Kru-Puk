﻿using Microsoft.Xna.Framework;
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
    private bool onMenu;
    public Main(Game game, Window window, SpriteFont font, Texture2D[][] zombieAnimations, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas, Texture2D logo, Texture2D menuBackground, Texture2D[] button, Texture2D[] platforms, Texture2D projectile) // all textures
    {
      entityfactory = new EntityFactory(zombieAnimations, levels, assets, areas, platforms, projectile); // put all textures in here
      this.font = font; //unassigned spritefont. The font works, but idk where to use it/put it yet.
      this.window = window;
      this.menu = new Menu(this, window, logo, menuBackground, button, font);
      this.onMenu = true;
      this.game = game;
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
      Area[] areas = new Area[0]; // number of areas
      //areas[0] = entityfactory.CreateArea(new Rectangle(0, 0, 400, 500), 0, assets1); // position, width, height, areabackgroundID, assets
      //areas[1] = entityfactory.CreateArea(new Rectangle(400, 0, 400, 500), 1, assets2);

      IEntity[] entities = new IEntity[2]; // number of entities
      entities[0] = entityfactory.CreateZombie(new Rectangle(new Point(0, 0), new Point(56, 109)));
      entities[1] = entityfactory.CreateZombie(new Rectangle(new Point(window.WholeWindow().Right - 56, 0), new Point(56, 109)));

      //SET FOLLOWING OBJECTS
      entities[0].SetFollowingObject(entities[1]);
      entities[1].SetFollowingObject(entities[0]);

      Platform[] platforms = new Platform[1];
      platforms[0] = entityfactory.CreatePlatform(new Rectangle(10, 280, 128, 40), 0);

      Level[] levels = new Level[1]; // number of levels
      levels[0] = entityfactory.CreateLevel(areas, new Point(0, 0), 0, platforms); //areas, entities, spawnpoint, backgroundID
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
      }
    }
  }
}
