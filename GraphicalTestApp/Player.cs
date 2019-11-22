﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sprite _sprite = new Sprite("Images/player.png");
        private Turret _turret = new Turret(40,0);
        private Turret _turret2 = new Turret(-40, 0);
        private Shield _shield = new Shield(0, 5);
        public AABB _hitbox;
        public static Player Instance;
        
        public Player(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            AABB HitBox = new AABB(_sprite.Height, _sprite.Width);
            _hitbox = HitBox;
            _hitbox.X = -5;
            _hitbox.Y = -5;
            AddChild(_sprite);
            
            AddChild(HitBox);
            AddChild(_turret);
            AddChild(_turret2);
            AddChild(_shield);
            
       
            OnUpdate += BounceCheck;
            OnUpdate += Movement;           
            OnUpdate += Rotation;
            OnUpdate += TurretRotation;


            Instance = this;

        }
        public AABB HitBox()
        {
            return _hitbox;
        }
        private void Movement(float deltaTime)
        {
            //Side Bounce

            //move up input w
            if (Input.IsKeyDown(87))
            {
                YAcceleration = -150;
            }
            //move Down input s
            else if (Input.IsKeyDown(83))
            {
                YAcceleration = 150;
            }
            //move left input a 
            else if (Input.IsKeyDown(68))
            {
                XAcceleration = 150;
            }
            //move right input d
            else if (Input.IsKeyDown(65))
            {
                XAcceleration = -150;
            }
            //slows down the ship if no input
            else
            {
                XAcceleration = 0;
                YAcceleration = 0;
                if(XVelocity >0)
                {
                    XVelocity -= .01f;
                }
                else if(XVelocity < 0 )
                {
                    XVelocity += 0.1f;
                }
               
                if (YVelocity > 0)
                {
                    YVelocity -= .01f;
                }
                else if(YVelocity < 0)
                {
                    YVelocity += .01f;
                }


            }
        }
        //players rotations
        private void Rotation(float deltaTime)
        {
            //rotate left input q
            if (Input.IsKeyDown(69))
            {
                Rotate(1f * deltaTime);
                
            }
            //rotate right input e
            else if (Input.IsKeyDown(81))
            {
                Rotate(-1f * deltaTime);
            }
        }
        //rotate  both turrets
        private void TurretRotation(float deltaTime)
        {
            //rotate turrret right input R
            if (Input.IsKeyDown(82))
            {
               
                    _turret.Rotate(1f * deltaTime);
                    _turret2.Rotate(1f * deltaTime);
                
            }
            //rotate turret left input f
            else if (Input.IsKeyDown(70))
            {
               
                    _turret.Rotate(-1f * deltaTime);
                _turret2.Rotate(-1f * deltaTime);
              
            }
        }
        //bounce player off of sides of screens
        private void BounceCheck(float deltaTime)
        {
            //check left and right sides of window
            if (_hitbox.Right >= Game.windowsizeX || _hitbox.Left <= 0)
            {
                XVelocity = -XVelocity  ;
         
            }
            //bounce of left and right of window
            if (_hitbox.Bottom >= Game.windowsizeY || _hitbox.Top <= 0)
            {

                YVelocity = -YVelocity;
                
            }
        }
 

    }
}
