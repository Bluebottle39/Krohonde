﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Krohonde
{
    public abstract class Colony
    {
        private const int CONSTRUCTION_ZONE = 50;
        protected IMotherNature myWorld;
        protected System.Windows.Point location;
        protected List<System.Drawing.Point> hill;
        protected List<Ant> ants;
        private readonly Color color;
        private int foodstore;

        public Colony(Color col, System.Windows.Point loc, IMotherNature world)
        {
            myWorld = world;
            // Anthill
            location = loc;
            hill = new List<System.Drawing.Point>();
            hill.Add(new System.Drawing.Point { X = (int)location.X - 43, Y = (int)location.Y - 25 });
            hill.Add(new System.Drawing.Point { X = (int)location.X, Y = (int)location.Y - 50 });
            hill.Add(new System.Drawing.Point { X = (int)location.X + 43, Y = (int)location.Y - 25 });
            hill.Add(new System.Drawing.Point { X = (int)location.X + 43, Y = (int)location.Y + 25 });
            hill.Add(new System.Drawing.Point { X = (int)location.X, Y = (int)location.Y + 50 });
            hill.Add(new System.Drawing.Point { X = (int)location.X - 43, Y = (int)location.Y + 25 });
            ants = new List<Ant>();
            color = col;
        }

        /// <summary>
        /// Remove an ant from the colony (it's dead or illegal)
        /// </summary>
        /// <param name="ant"></param>
        public void Dispose(Ant ant)
        {
            ants.Remove(ant);
        }

        /// <summary>
        /// An ant intends to dump its food bag into the colony's foodstore
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        public bool DumpFood(Ant ant)
        {
            if (!Helpers.IsInPolygon(Hill, ant.SDLocation)) return false; // can't dump from outside
            foodstore += ant.FoodBag;
            ant.EmptyFoodBag();
            return true;
        }

        private bool ConstructibleSpot(System.Drawing.Point p)
        {
            bool inside;
            if (Helpers.IsInPolygon(Hill, p)) return false; // cannot build inside
            for (int s = 1; s < Hill.Count(); s++)
                if (Helpers.DistanceToLine(p, Hill[s - 1], Hill[s],out inside) < CONSTRUCTION_ZONE && inside) return true;
            if (Helpers.DistanceToLine(p, Hill[Hill.Count() - 1], Hill[0], out inside) < CONSTRUCTION_ZONE && inside) return true;
            Console.WriteLine($"Attempt to build non-constructible spot {p}");
            return false;
        }

        public bool BuildExtension(Ant ant)
        {
            // check conditions
            if (ant.BrickBag < MotherNature.BRICKS_TO_BUILD) return false; // not enough bricks in the bag
            if (ant.GetType().Name != "WorkerAnt") return false; // only workers can build
            if (!ConstructibleSpot(ant.SDLocation)) return false; // Bad spot

            // find closest point of the anthill
            double distmin = myWorld.width;
            int closest = 0;
            for (int idx = 0; idx < hill.Count(); idx++)
                if (Helpers.Distance(hill[idx], ant.SDLocation) < distmin)
                {
                    distmin = Helpers.Distance(hill[idx], ant.SDLocation);
                    closest = idx;
                }
            int insertat;
            // find the points before and after the closest
            int before = (closest == 0 ? hill.Count() - 1 : closest - 1);
            int after = (closest == hill.Count() - 1 ? 0 : closest + 1);
            if (Helpers.Distance(hill[before], ant.SDLocation) < Helpers.Distance(hill[after], ant.SDLocation))
                insertat = closest;
            else
                insertat = after;

            hill.Insert(insertat, ant.SDLocation);
            return true;
        }
        public abstract void Spawn(int nbAnts);

        public System.Drawing.Point[] Hill { get => hill.ToArray(); }

        public List<Ant> Population { get => ants; }

        public Color Color { get => color; }

        public int FoodStore { get => foodstore; }

        public System.Windows.Point Location { get => location; }

        public IMotherNature World() { return myWorld; }

        public double Size { get => Helpers.PolygonArea(Hill); }
    }
}
