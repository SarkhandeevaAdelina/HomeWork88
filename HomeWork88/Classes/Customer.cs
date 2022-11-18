using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork88.Classes
{
    internal class Customer
    {
        /// <summary>
        /// Имя закзщика
        /// </summary>
        readonly private string name;
        /// <summary>
        /// Инициализируем заказщика именем name
        /// </summary>
        /// <param name="name"></param>
        public Customer(string name)
        {
            this.name = name;
        }
    }
}
