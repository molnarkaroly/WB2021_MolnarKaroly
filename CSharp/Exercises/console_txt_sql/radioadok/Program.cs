using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySqlConnector;

namespace radioadok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kapcsolat
            var server = new MySqlConnectionStringBuilder { Server = "127.0.0.1", UserID = "root", Password = "" };

            var connection = new MySqlConnection(server.ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();

            #region Kiosztas
            string[] kiosztasAdat = File.ReadAllLines("kiosztas.txt", Encoding.UTF8);

            // Parancs Írása
            command.CommandText = "CREATE DATABASE IF NOT EXISTS radioadok CHARACTER SET utf8 COLLATE utf8_hungarian_ci;\n USE radioadok;\n DROP TABLE IF EXISTS kiosztas;\n";
            command.CommandText += $"CREATE TABLE kiosztas (" +
                $"azon INT AUTO_INCREMENT PRIMARY KEY, " +
                $"{kiosztasAdat[0].Split('\t')[0].Trim()} FLOAT, " +
                $"{kiosztasAdat[0].Split('\t')[1].Trim()} FLOAT, " +
                $"{kiosztasAdat[0].Split('\t')[2].Trim()} VARCHAR(255), " +
                $"{kiosztasAdat[0].Split('\t')[3].Trim()} VARCHAR(255), " +
                $"{kiosztasAdat[0].Split('\t')[4].Trim()} VARCHAR(255)" +
                $");\n";

            Console.WriteLine(command.CommandText);

            // Parancs Futtatása
            var reader = command.ExecuteReader();
            reader.Read();
            reader.Close();

            //Adatok Bevitele
            command.CommandText = $"INSERT INTO kiosztas(" +
                $"{kiosztasAdat[0].Split('\t')[0].Trim()}," +
                $"{kiosztasAdat[0].Split('\t')[1].Trim()}," +
                $"{kiosztasAdat[0].Split('\t')[2].Trim()}," +
                $"{kiosztasAdat[0].Split('\t')[3].Trim()}," +
                $"{kiosztasAdat[0].Split('\t')[4].Trim()}) VALUES ";
            for (int i = 1; i < kiosztasAdat.Length; i++)
            {
                command.CommandText += $"(" +
                $"{kiosztasAdat[i].Split('\t')[0].Trim()}," +
                $"{kiosztasAdat[i].Split('\t')[1].Trim()}," +
                $"'{kiosztasAdat[i].Split('\t')[2].Trim()}'," +
                $"'{kiosztasAdat[i].Split('\t')[3].Trim()}',";
                if (kiosztasAdat[i].Split('\t')[4].Trim() != "") command.CommandText += $"'{kiosztasAdat[i].Split('\t')[4].Trim()}')\n";
                else command.CommandText += $"NULL)";
                if (i != kiosztasAdat.Length - 1) command.CommandText += $",\n";
            }
            Console.WriteLine(command.CommandText);
            reader = command.ExecuteReader();
            reader.Read();
            reader.Close();

            command.CommandText = "";
            #endregion



            #region Telepules
            string[] telepulesAdat = File.ReadAllLines("telepules.txt", Encoding.UTF8);

            // Parancs Írása
            command.CommandText = "DROP TABLE IF EXISTS telepules;\n";
            command.CommandText += $"CREATE TABLE telepules (" +
                $"{telepulesAdat[0].Split('\t')[0].Trim()} VARCHAR(255) PRIMARY KEY, " +
                $"{telepulesAdat[0].Split('\t')[1].Trim()} VARCHAR(255)" +
                $");\n";

            Console.WriteLine(command.CommandText);

            // Parancs Futtatása
            reader = command.ExecuteReader();
            reader.Read();
            reader.Close();

            //Adatok Bevitele
            command.CommandText = $"INSERT INTO telepules(" +
                $"{telepulesAdat[0].Split('\t')[0].Trim()}," +
                $"{telepulesAdat[0].Split('\t')[1].Trim()}) VALUES ";
            for (int i = 1; i < telepulesAdat.Length; i++)
            {
                command.CommandText += $"(" +
                $"'{telepulesAdat[i].Split('\t')[0].Trim()}'," +
                $"'{telepulesAdat[i].Split('\t')[1].Trim()}')";
                if (i != telepulesAdat.Length - 1) command.CommandText += $",\n";
            }
            Console.WriteLine(command.CommandText);
            reader = command.ExecuteReader();
            reader.Read();
            reader.Close();

            command.CommandText = "";
            #endregion



            #region Regio
            string[] regioAdat = File.ReadAllLines("regio.txt", Encoding.UTF8);

            // Parancs Írása
            command.CommandText = "DROP TABLE IF EXISTS regio;\n";
            command.CommandText += $"CREATE TABLE regio (" +
                $"{regioAdat[0].Split('\t')[0].Trim()} VARCHAR(255), " +
                $"{regioAdat[0].Split('\t')[1].Trim()} VARCHAR(255) PRIMARY KEY" +
                $");\n";

            Console.WriteLine(command.CommandText);

            // Parancs Futtatása
            reader = command.ExecuteReader();
            reader.Read();
            reader.Close();

            //Adatok Bevitele
            command.CommandText = $"INSERT INTO regio(" +
                $"{regioAdat[0].Split('\t')[0].Trim()}," +
                $"{regioAdat[0].Split('\t')[1].Trim()}) VALUES ";
            for (int i = 1; i < regioAdat.Length; i++)
            {
                command.CommandText += $"(" +
                $"'{regioAdat[i].Split('\t')[0].Trim()}'," +
                $"'{regioAdat[i].Split('\t')[1].Trim()}')";
                if (i != regioAdat.Length - 1) command.CommandText += $",\n";
            }
            Console.WriteLine(command.CommandText);
            reader = command.ExecuteReader();
            reader.Read();
            reader.Close();

            command.CommandText = "";
            #endregion

            command.CommandText = "ALTER TABLE kiosztas ADD CONSTRAINT FOREIGN KEY (adohely) REFERENCES telepules(nev);\n";
            command.CommandText += "ALTER TABLE telepules ADD CONSTRAINT FOREIGN KEY (megye) REFERENCES regio(megye);";

            Console.WriteLine(command.CommandText);
            reader = command.ExecuteReader();
            reader.Read();
            reader.Close();

            // Kapcsolat Lezárása
            connection.Close();

            Console.ReadKey();
        }
    }
}
