﻿using System;
using Raylib;
using RL = Raylib.Raylib;

namespace GraphicalTestApp
{
    class Sprite : Actor
    {
        private Texture2D _texture = new Texture2D();
        private Image _image = new Image();

        public float Width
        {
            get { return _texture.width / Game.UnitSize.x; }
        }

        public float Height
        {
            get { return _texture.height / Game.UnitSize.y; }
        }

        public float Top
        {
            get { return YAbsolute + 0.5f; }
        }

        public float Bottom
        {
            get { return YAbsolute + Height + 0.5f; }
        }

        public float Left
        {
            get { return XAbsolute + 0.5f; }
        }

        public float Right
        {
            get { return XAbsolute + Width + 0.5f; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public void Load(string path)
        {
            _image = RL.LoadImage(path);
            _texture = RL.LoadTextureFromImage(_image);
            X = -Width / 2;
            Y = -Height / 2;
        }
    }
}