using ScheduleAppListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppListImplement
{
    internal class DataListSingelton
    {
        private static DataListSingelton? _instance;

        public List<Room> Rooms { get; set; } // Список аудиторий
        public List<Teacher> Teachers { get; set; } // Список преподавателей
        public List<Subject> Subjects { get; set; } // Список предметов
        public List<Group> Groups { get; set; } // Список групп
        public List<Schedule> Schedules { get; set; } // Список расписания
        public List<User> Users { get; set; } // Список пользователей

        private DataListSingelton()
        {
            // Инициализация списков
            Rooms = new List<Room>();
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
            Groups = new List<Group>();
            Schedules = new List<Schedule>();
            Users = new List<User>();
        }

        public static DataListSingelton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataListSingelton();
            }

            return _instance;
        }
    }
}
