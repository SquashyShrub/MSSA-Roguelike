using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Roguelike___Mini_Project
{
    internal class MusicThemes
    {
        static string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        static string townPath = Path.Combine(currentDir, "Music", "MSSA Roguelike Townsquare Theme.wav");
        static string churchPath = Path.Combine(currentDir, "Music", "MSSA Roguelike Maze Theme.wav");
        static string mazePath = Path.Combine(currentDir, "Music", "MSSA Roguelike Maze Theme.wav");
        static string gravePath = Path.Combine(currentDir, "Music", "MSSA Roguelike Graveyard Theme.wav");
        static string barnPath = Path.Combine(currentDir, "Music", "MSSA Roguelike Barn Theme.wav");
        static string battle1 = Path.Combine(currentDir, "Music", "MSSA Roguelike Battle Theme 1.wav");
        static string battle2 = Path.Combine(currentDir, "Music", "MSSA Roguelike Battle Theme 2 - Bloody Tears.wav");
        static string battle3 = Path.Combine(currentDir, "Music", "MSSA Roguelike Battle Theme 3.wav");


        public SoundPlayer townSquareTheme = new SoundPlayer(townPath);
        public SoundPlayer churchTheme = new SoundPlayer(churchPath);
        public SoundPlayer mazeTheme = new SoundPlayer(mazePath);
        public SoundPlayer graveTheme = new SoundPlayer(gravePath);
        public SoundPlayer barnTheme = new SoundPlayer(barnPath);
        public SoundPlayer churchBattle = new SoundPlayer(battle1);
        public SoundPlayer graveBattle = new SoundPlayer(battle2);
        public SoundPlayer barnBattle = new SoundPlayer(battle3);

        

        public void Play(SoundPlayer sound)
        {
            sound.Play();
        }
        public void Stop(SoundPlayer sound)
        {
            sound.Stop();
        }
    }
}
