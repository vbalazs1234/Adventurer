using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer
{
    internal class SoundManager
    {
        private SoundEffect BackgroundMusic;
        public SoundEffectInstance BackgroundMusicInstance { get; private set; }

        public SoundManager(Game game)
        {
            //need to be set
            BackgroundMusic = game.Content.Load<SoundEffect>("background-music.wav");
            BackgroundMusicInstance = BackgroundMusic.CreateInstance();
        }
        

        public void PlayMusic()
        {
            if (BackgroundMusicInstance.State != SoundState.Playing)
            {
                BackgroundMusicInstance.IsLooped = true;
                BackgroundMusicInstance.Play();
            }
        }

        public void IncreaseVolume()
        {
            BackgroundMusicInstance.Volume -= SoundEffect.MasterVolume; BackgroundMusicInstance.Volume = 0;
        }

        public void StopMusic()
        {
            if (BackgroundMusicInstance.State == SoundState.Playing)
            {
                BackgroundMusicInstance.Stop();
            }
        }
    }
}
