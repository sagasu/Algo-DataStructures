using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Design_Parking_System
{
    public class ParkingSystem
    {
        private int _big;
        private int _medium;
        private int _small;

        public ParkingSystem(int big, int medium, int small)
        {
            _big = big;
            _medium = medium;
            _small = small;
        }

        public bool AddCar(int carType)
        {
            return carType switch
            {
                1 => --_big >= 0 ? true : false,
                2 => --_medium >= 0 ? true : false,
                3 => --_small >= 0 ? true : false,
            };

        }
    }
}
