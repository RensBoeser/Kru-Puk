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
    public Main(Texture2D[] zombieWalking, Texture2D[] levels, Texture2D[] assets, Texture2D[][] areas) // all textures
    {
      entityfactory = new EntityFactory(zombieWalking, levels, assets, areas); // put all textures in here
    }

    public void AddLevel1()
    {
      Asset[] assets = new Asset[2]; // NUMBER OF ASSETS
      assets[0] = entityfactory.CreateAsset(new Point(0, 0), 0); // position, assettextureID
      assets[1] = entityfactory.CreateAsset(new Point(100, 0), 1); // position, assettextureID

      Area[] areas = new Area[1]; // NUMBER OF AREAS
      areas[0] = entityfactory.CreateArea(new Point(0,0), 500, 400, 0, assets); // position, width, height, areabackgroundID, assets

      IEntity[] entities = new IEntity[1]; // NUMBER OF ENTITIES
      entities[0] = entityfactory.CreateZombie(new Point(0, 0)); // position

      Level level = entityfactory.CreateLevel(areas, entities, new Point(0, 0)); //areas, entities, spawnpoint
    }

    public void Draw(SpriteBatch spritebatch)
    {
    }

    public void Update(float dt)
    {
    }
  }
}
