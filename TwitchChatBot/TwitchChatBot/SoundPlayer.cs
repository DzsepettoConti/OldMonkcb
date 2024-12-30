using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TwitchChatBot
{
    internal class SoundPlayer
    {
        public void Playsound(string musicPath)
        {
            Console.WriteLine("MP3 fájl lejátszása a háttérben...");


            using (var audioFile = new AudioFileReader(musicPath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                Console.WriteLine("Nyomj egy billentyűt a leállításhoz...");
                Console.ReadKey(); // A konzol nyitva marad, amíg a lejátszás zajlik
            }

            Console.WriteLine("Lejátszás vége.");
        }


    }
}
