﻿using System;
using Raylib;
using RL = Raylib.Raylib;
using System.Diagnostics;
using System.Collections.Generic;


namespace GraphicalTestApp
{
    class Game
    {
        //The current root Actor
        private Actor _root = null;
        //The next root Actor
        private Actor _next = null;
        //The Timer for the entire Game
        private Timer _gameTimer = new Timer();
        private Stopwatch stopwatch = new Stopwatch();
        public static int score;
        //window sizes to
        public static int windowsizeX;
        public static int windowsizeY;
        public static List<Astroid> AstroidList = new List<Astroid>();

        public static Random random = new Random();

        //Creates a Game and new Scene instance as its active Scene
        public Game(int width, int height, string title)
        {
            windowsizeX = width;
            windowsizeY = height;
            RL.InitWindow(width, height, title);
            RL.SetTargetFPS(0);
        }
        
        //Run the game loop
        public void Run()
        {

            stopwatch.Start();
            //Update and draw until the game is over
            while (!RL.WindowShouldClose())
            {
             

                //Change the Scene if needed
                if (_root != _next)
                {
                    _root = _next;
                }

                //Start the Scene if needed
                if (!_root.Started)
                {
                    _root.Start();
                }

                //Update the active Scene
                _root.Update(_gameTimer.GetDeltaTime());
                if (stopwatch.ElapsedMilliseconds > 1000)
                {
                    float astroidXPos = random.Next(0, windowsizeX);
                    float astroidYPos = random.Next(0, windowsizeY);
                    if (astroidXPos == Player.Instance.X && astroidYPos == Player.Instance.Y)
                    {
                        continue;
                    }
                    Astroid astroid = new Astroid(astroidXPos, astroidYPos, random.Next(-40, 40), random.Next(-40,40));

                    Root.AddChild(astroid);
                    AstroidList.Add(astroid);
                    stopwatch.Restart();
                }
                //Draw the active Scene
                RL.BeginDrawing();
                RL.ClearBackground(Color.BLACK);
                RL.DrawText("score: " + score, 0, 0, 20, Color.WHITE);
                RL.DrawText("Lives:" + Player.Instance.lifes, 0, 30, 20, Color.WHITE);
                _root.Draw();
                RL.EndDrawing();
            }
       

            //End the game
            RL.CloseWindow();
        }

        //The Actor we are currently running
        public Actor Root
        {
            get { return _root; }
            set
            {
                _next = value;
                if (_root == null) _root = value;
            }
        }
    }
}
