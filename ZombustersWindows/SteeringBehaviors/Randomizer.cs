using System;

namespace ZombustersWindows
{
    /// <summary>
    /// Helper que torna nombres aleatoris
    /// </summary>
    public static class Randomizer
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Obt� un nombre aleatori entre un m�nim i un m�xim
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int ObtenerAleatorio(int min, int max)
        {
            return rnd.Next(min, max);
        }

        /// <summary>
        /// Torna un aleatori entre -1 i 1
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float ObtenerAleatorioBinomial()
        {
            return (float)(rnd.NextDouble() - rnd.NextDouble());
        }
    }
}
