using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Решение 5-й задачи
/// </summary>
namespace lssn_2
{
    class GameObjectException : Exception
    {

        public bool WrongSize;
        public bool WrongSpeed;

        public GameObjectException()
        {
            WrongSize = false;
            WrongSpeed = false;
        }
    }
}