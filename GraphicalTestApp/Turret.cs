﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using Rl = Raylib.Raylib;

namespace GraphicalTestApp
{
    class Turret : Entity
    {
        public Sprite _TurretSprite = new Sprite("Images/gun08.png");
       //load fire sound
        Sound fireSound = Rl.LoadSound("Sounds/Laser_Shoot.wav");
        
        public Turret(float x, float y) : base(x, y)
        {
            //add turret sprite to turret
            AddChild(_TurretSprite);
            
           
           
        }
        public void fire()
        {
            //lower volume of all sounds
            Rl.SetMasterVolume(10);
            //play fire sound
            Rl.PlaySound(fireSound);
            
            
            Bullet bulletOne = new Bullet(XAbsolute, YAbsolute);
            //rotate turret to match turret
            bulletOne.Rotate(GetRotation());
            //fire bullet in direction based off rotation of turret
            bulletOne.XVelocity = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 1000;
            bulletOne.YVelocity = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 1000;
            //add bullet to root
            Parent.Parent.AddChild(bulletOne);

            
            
        }

    }
}
