using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lssn_3
{
    /// <summary>
    /// Класс для обработки исключительных ситуаций с объектами
    /// </summary>
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
