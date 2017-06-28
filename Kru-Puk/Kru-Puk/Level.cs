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
    private Texture2D background;
    private IEntity[] entities;
    private Point spawnpoint;
    private DrawingAdapter drawingAdapter;
    private Platform[] platforms;

    public Level(Area[] areas, Texture2D background, Point spawnpoint, Platform[] platforms)
    {
      this.entities = new IEntity[0];
      this.areas = areas;
      this.background = background;
      this.spawnpoint = spawnpoint;
      this.drawingAdapter = new DrawingAdapter();
      this.platforms = platforms;
    }

    public IEntity[] GetEntities()
    {
      return entities;
    }
    public void AddEntity(IEntity entity)
    {
      List<IEntity> templist = new List<IEntity>();
      foreach(IEntity existingEntity in entities)
      {
        templist.Add(existingEntity);
      }
      templist.Add(entity);
      entities = templist.ToArray();
    }

    public void RemoveEntity(IEntity entity)
    {
      if(entities.Contains(entity))
      {
        List<IEntity> tempList = new List<IEntity>();
        foreach (IEntity existingEntity in entities)
        {
          tempList.Add(existingEntity);
        }
        tempList.Remove(entity);
        entities = tempList.ToArray();
      }
      else
      {
        throw new NotImplementedException("DOES NOT EXIST IN THE LEVEL?!");
      }
    }

    public Platform[] GetPlatforms()
    {
      return this.platforms;
    }

    public void Update(float dt)
    {
      foreach(Area area in areas)
      {
        area.Update(dt);
      }
      foreach(IEntity entity in entities)
      {
        entity.Update(dt);
      }
      foreach (Platform platform in platforms)
      {
        platform.Update(dt);
      }
    }

    public void Draw(SpriteBatch spritebatch)
    {
      drawingAdapter.Draw(spritebatch, background, new Point(0, 0), false);
      foreach (Area area in areas)
      {
        area.Draw(spritebatch);
      }
      foreach (IEntity entity in entities)
      {
        entity.Draw(spritebatch);
      }
      foreach (Platform platform in platforms)
      {
        platform.Draw(spritebatch);
      }
    }

    public bool ExistingEntity(IEntity entity)
    {
      if (entities.Contains(entity))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
