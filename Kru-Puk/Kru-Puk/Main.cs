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
    private EntityFactory entityfactory;
    private Level[] levels;
    public Main(Texture2D[] zombieWalking, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas) // all textures
    {
      entityfactory = new EntityFactory(zombieWalking, levels, assets, areas); // put all textures in here
    }

    public void AddLevels()
    {
      // !!! Instantiate all asset lists here !!!
      // By creating a list for each area, you can put assets into groups for each area
      // The position of the assets is based on the area's position
      Asset[] assets1 = new Asset[2];
      assets1[0] = entityfactory.CreateAsset(new Point(0, 0), 0); // position, assettextureID
      assets1[1] = entityfactory.CreateAsset(new Point(100, 0), 1);
      Asset[] assets2 = new Asset[1];
      assets2[0] = entityfactory.CreateAsset(new Point(200, 200), 2);

      // by creating a list of areas, you can put areas into groups for each level
      Area[] areas = new Area[2]; // number of areas
      areas[0] = entityfactory.CreateArea(new Point(0, 0), 500, 400, 0, assets1); // position, width, height, areabackgroundID, assets
      areas[1] = entityfactory.CreateArea(new Point(500, 0), 500, 400, 1, assets2);

      IEntity[] entities = new IEntity[1]; // number of entities
      entities[0] = entityfactory.CreateZombie(new Point(0, 0)); // position

      levels = new Level[0]; // number of levels
      levels[0] = entityfactory.CreateLevel(areas, entities, new Point(0, 0)); //areas, entities, spawnpoint
    }

    public void Draw(SpriteBatch spritebatch)
    {
    }

    public void Update(float dt)
    {
    }
  }
}
