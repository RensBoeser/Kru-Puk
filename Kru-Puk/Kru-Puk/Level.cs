using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
  class Level : ILevel
  {
    private Area[] areas;
    private Texture2D[] backgrounds;
    private IEntity[] entities;
    private Point spawnpoint;

    public Level(Area[] areas, Texture2D[] backgrounds, IEntity[] entities, Point spawnpoint)
    {
      this.areas = areas;
      this.backgrounds = backgrounds;
      this.entities = entities;
      this.spawnpoint = spawnpoint;
    }

    public IEntity[] GetEntities()
    {
      return entities;
    }
    public void AddEntity(IEntity entity)
    {
      throw new NotImplementedException();
    }

    public void RemoveEntity(IEntity entity)
    {
      throw new NotImplementedException();
    }

    public void Update(float dt)
    {
      throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spritebatch)
    {
      throw new NotImplementedException();
    }
  }
}
