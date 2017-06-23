using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kru_Puk
{
    class Level : ILevel // InterfaceNotImplemented
    {
        private Area[] areas;
        private Texture2D[] backgrounds;
        private ???[] assets;
        private IEntity[] entities;
        private Tuple<float, float> spawnpoint;

        Level(Area[] areas, Texture2D[] backgrounds, ???[] assets, IEntity[] entities, Tuple<float,float> spawnpoint)
        {
            this.areas = areas;
            this.backgrounds = backgrounds;
            this.assets = assets;
            this.entities = entities;
            this.spawnpoint = spawnpoint;

        }
    }
}
