﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Krohonde.RedColony
{
    public class WorkerAnt : Ant
    {
        private Point position;
        private Point goToPosition;
        
        

        public WorkerAnt(Point location, Point speed, RedColony colony) : base(location, speed, colony)
        {
            
        }

        public override void Live(double deltatime)
        {
            

            if (BrickBag > 500)
            {
                Speed.X = MyColony.Location.X - X;
                Speed.Y = MyColony.Location.Y - Y;
                Move(deltatime);
            }

            double distMin = 5000;

            List<Brick> brickpositions = BricksAroundMe();
            if (brickpositions.Count() > 0)
            {
                Brick closest = brickpositions[0];
                foreach (Brick brickporche in brickpositions)
                {
                    if (Helpers.Distance(SDLocation, brickporche.Location) < distMin)
                    {
                        closest = brickporche;
                        distMin = Helpers.Distance(SDLocation, brickporche.Location);
                    }
                }

                int xPos = closest.Location.X;
                int yPos = closest.Location.Y;
                int xMyPos = Convert.ToInt32(X);
                int yMyPos = Convert.ToInt32(Y);
                float distance = Math.Abs(xPos - xMyPos) + Math.Abs(yPos - yMyPos);

                if(distance < 2.0f)
                {
                    ScoutAnt.DesactivateRessource(closest);
                    Pickup(closest);
                }
                else
                {
                    Speed.X = closest.Location.X - X - 1;
                    Speed.Y = closest.Location.Y - Y - 1;
                    Move(deltatime);
                }

                


            }
            else
            {
                Resource procheSelonScouts = ScoutAnt.GoToResource(new Point(X, Y), true, false);

                if (procheSelonScouts != null)
                {
                    goToPosition = new Point(procheSelonScouts.Location.X, procheSelonScouts.Location.Y);
                }


                Speed.X = goToPosition.X - X;
                Speed.Y = goToPosition.Y - Y;
                Move(deltatime);
            }
            

            
        }
    }
}