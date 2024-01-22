using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer
{
    internal class SoundManager
    {
        private static Song BackgroundMusic;

        public SoundManager()
        {
            // Load the background music using the same content path
            MediaPlayer.IsRepeating = true; // Set to true for looping
        }
        public void LoadContent(ContentManager Content)
        {
            BackgroundMusic = Content.Load<Song>("Sounds/background-music");
          
        }

        public static void PlayMusic()
        {
            // If the music is not playing, start playing
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(BackgroundMusic);
            }
        }
        public void StopMusic()
        {
            // If the music is playing, stop it
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Stop();
            }
        }
        public void SetMusicVolume(float volume)
        {
            MediaPlayer.Volume = volume;
        }
        public void Update()
        {
            // Check and handle any necessary updates
            // For example, restart the music if it has stopped (due to looping)
            if (MediaPlayer.State == MediaState.Stopped)
            {
                SoundManager.PlayMusic();
            }
        }

    }
}
