using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasTeste
{
    public static class Constants
    {
        public const string DatabaseFilename = "ToDoSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        // abre a base de dados no modo de leitura/escrita
        SQLite.SQLiteOpenFlags.ReadWrite |
        // cria a base de dados caso ainda não exista
        SQLite.SQLiteOpenFlags.Create |
        // ativa acesso multi-threaded à base de dados
        SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
