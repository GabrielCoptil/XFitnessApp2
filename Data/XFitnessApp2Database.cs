using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Extensions;
using XFitnessApp2.Models;

namespace XFitnessApp2.Data
{
    public class XFitnessApp2Database
    {
        private readonly SQLiteConnection _database;

        public XFitnessApp2Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<User>();
            _database.CreateTable<Schedule>();
            _database.CreateTable<Rezervare>();
        }
        public List<User> GetUsers() => _database.Table<User>().ToList();
        public User GetUserByUsername(string username) => _database.Table<User>().FirstOrDefault(u => u.Username == username);
        public int SaveUser(User user) => _database.Insert(user);
        public List<Schedule> GetSchedules() => _database.Table<Schedule>().ToList();
        public int SaveSchedule(Schedule schedule) => _database.Insert(schedule);
        public int DeleteSchedule(int id) => _database.Delete<Schedule>(id);
        public Schedule GetScheduleById(int id) => _database.Table<Schedule>().FirstOrDefault(s => s.Id == id);

        public List<Rezervare> GetRezervari() => _database.GetAllWithChildren<Rezervare>();
        public int DeleteRezervare(int id) => _database.Delete<Rezervare>(id);
        public void SaveRezervare(Rezervare rezervare) => _database.Insert(rezervare);
        

    }
}

