using mvalencia_S5_T1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvalencia_S5_T1.Utils
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection con;

        public string StatusMessage { get; set; }

        private void Init()
        {
            if (con is not null)
                return;
            con = new(_dbPath);
            con.CreateTable<Persona>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");
                Persona person = new() { Name = nombre };
                result = con.Insert(person);

                StatusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("File to add {0}. Error: {1}", result, ex.Message);
            }
        }
        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return con.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Filed to retrive data. {0}", ex.Message);
            }
            return new List<Persona>();
        }
    }
}
