using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // Variables de estado del juego
            bool gameOver = false;
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            // Creamos el mapa del juego
            List<Lane> lanes = new List<Lane>();
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.Green }));//Final del mapa
            lanes.Add(new Lane(1, true, ConsoleColor.Blue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(2, true, ConsoleColor.Blue, false, true, 0.7f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(3, true, ConsoleColor.Blue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(4, true, ConsoleColor.Blue, false, true, 0.7f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(5, true, ConsoleColor.Blue, false, true, 0.8f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.Green }));//Mitad del mapa
            lanes.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.Green }));//Salida
            lanes.Add(new Lane(13, false, ConsoleColor.Black, false, false, 0, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.Green }));//Linea para que se vea el fondo negro

            // Creamos el Jugador
            Player frog = new Player();

            while (!gameOver)
            {
                Console.Clear();

                // Dibujamos el mapa
                foreach (Lane lane in lanes)
                {
                    lane.Draw();
                }

                // Dibujamos el personaje
                frog.Draw();

                // Actualizamos el mapa
                foreach (Lane lane in lanes)
                {
                    lane.Update();
                }

                // Leemos el input y actualizamos el personaje
                Vector2Int input = Utils.Input();
                
                gameState = frog.Update(input, lanes);
                
                // Comprobamos si hemos ganado o perdido
                if (gameState != Utils.GAME_STATE.RUNNING)
                {
                    gameOver = true;
                }

                // Avanzamos un frame
                TimeManager.NextFrame();
            }

            // Print de victoria o derrota
            switch (gameState)
            {
                case Utils.GAME_STATE.WIN:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("¡Has ganado!");
                    break;
                case Utils.GAME_STATE.LOOSE:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Has perdido!");
                    break;
            }
        }
    }
}