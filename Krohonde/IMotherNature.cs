﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krohonde
{
    public interface IMotherNature
    {
        #region Probing the world
        void LookAroundForFood(Ant ant);
        void LookAroundForObstacles(Ant ant);
        void LookAroundForEnemies(Ant ant);
        void SmellAround(Ant ant);
        #endregion
        #region Moving
        void GoFaster(Ant ant);
        void GoSlower(Ant ant);
        void Stop(Ant ant);
        void TurnRight(Ant ant);
        void TurnLeft(Ant ant);
        #endregion
        #region General actions
        void Eat(Ant ant);
        #endregion
        #region Worker ants
        void Build(Ant ant);
        #endregion
    }
}