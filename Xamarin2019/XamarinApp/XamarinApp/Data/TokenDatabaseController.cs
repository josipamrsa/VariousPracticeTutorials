using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Models;
using SQLite;

namespace XamarinApp.Data
{
    public class TokenDatabaseController
    {
        static object locker = new object();
        SQLiteConnection db;
        public TokenDatabaseController()
        {
            db = DependencyService.Get<ISQlite>().GetConnection();
            db.CreateTable<Token>();
        }

        public Token GetToken()
        {
            lock (locker)
            {
                if (db.Table<Token>().Count() == 0) { return null; }
                else { return db.Table<Token>().First(); }
            }
        }

        public int SaveToken(Token t)
        {
            lock (locker)
            {
                if (t.Id != 0)
                {
                    db.Update(t);
                    return t.Id;
                }
                else { return db.Insert(t); }
            }
        }

        public int DeleteToken(int id)
        {
            lock (locker) { return db.Delete<Token>(id); }
        }
    }
}
