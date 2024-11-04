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
        public SoundPlayer townSquareTheme = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Townsquare Theme.wav");
        public SoundPlayer churchTheme = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Church Theme.wav");
        public SoundPlayer mazeTheme = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Maze Theme.wav");
        public SoundPlayer graveTheme = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Graveyard Theme.wav");
        public SoundPlayer barnTheme = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Barn Theme.wav");
        public SoundPlayer churchBattle = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Battle Theme 1.wav");
        public SoundPlayer graveBattle = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Battle Theme 2 - Bloody Tears.wav");
        public SoundPlayer barnBattle = new SoundPlayer("C:\\MSSA\\DS_Algo\\MSSA Roguelike - Mini Project\\Music\\MSSA Roguelike Battle Theme 3.wav");

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
