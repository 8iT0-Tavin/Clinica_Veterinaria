using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClinicaVeterinaria
{
    public static class BancoDados
    {
    private const string CS = "server=000.0.0.0;port=3306;database=clinica_veterinaria;uid=root;pwd=;SslMode=disabled;";
        public static MySqlConnection Conectar()
        {
            return new MySqlConnection(CS);
        }

    }
}
