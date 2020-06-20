using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XamarinApp.Data
{
    public interface ISQlite
    {
        SQLiteConnection GetConnection();
    }
}
