using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace Kru_Puk
{
  class SoundEngine
  {

    public SoundEffect[] kruSounds;

    public SoundEngine(SoundEffect[] kruSounds)
    {
      this.kruSounds = kruSounds;
    }

    
    
    public void PlayKruFire()
    {
      kruSounds[0].Play();
    }

    public void PlayKruReload()
    {
      kruSounds[1].Play();
      kruSounds[2].Play();
    }

    public void PlayScream()
    {
      kruSounds[3].Play();
    }
    
  }
}
