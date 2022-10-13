using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class DataBase
    {
        public SqlConnection sqlConnection { get; set; }

        private readonly string ConnectionString= @"Data Source=.\SQLEXPRESS;
                                                        Initial Catalog=DBof;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DataBase()
        {
            sqlConnection = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Метод для отображения данных в виде таблицы
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public object ShowData(string query)
        {
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            return ds.Tables[0];
        }

        public void AddCabinet(Cabinet cabinet)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [TOS] (Name,AI,AO,DI,DO,RS485PLK,RS485SHL)" +
                "VALUES(@Name,@AI,@AO,@DI,@DO,@RS485PLK,@RS485SHL)", sqlConnection);
            command.Parameters.AddWithValue("Name", cabinet.Name);
            command.Parameters.AddWithValue("AI", cabinet.SignalAI);
            command.Parameters.AddWithValue("AO", cabinet.SignalAO);
            command.Parameters.AddWithValue("DI", cabinet.SignalDI);
            command.Parameters.AddWithValue("DO", cabinet.SignalDO);
            command.Parameters.AddWithValue("RS485PLK", cabinet.SignalRS485PLK);
            command.Parameters.AddWithValue("RS485SHL", cabinet.SignalRS485SHL);
            command.ExecuteNonQuery();
        }
        
        public void DeleteCabinet(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [TOS] WHERE [Id] = @Id", sqlConnection);
            command.Parameters.AddWithValue("Id", id);
            command.ExecuteNonQuery();
        }

        public void UpdateCabinet(int id,Cabinet cabinet)
        {
            SqlCommand command = new SqlCommand("UPDATE [TOS] SET Name = @Name, AI = @AI,AO = @AO ," +
                " DI = @DI , DO = @DO , RS485PLK = @RS485PLK , RS485SHL = @RS485SHL WHERE Id=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", id);
            command.Parameters.AddWithValue("Name", cabinet.Name);
            command.Parameters.AddWithValue("AI", cabinet.SignalAI);
            command.Parameters.AddWithValue("AO", cabinet.SignalAO);
            command.Parameters.AddWithValue("DI", cabinet.SignalDI);
            command.Parameters.AddWithValue("DO", cabinet.SignalDO);
            command.Parameters.AddWithValue("RS485PLK", cabinet.SignalRS485PLK);
            command.Parameters.AddWithValue("RS485SHL", cabinet.SignalRS485SHL);
            command.ExecuteNonQuery();
        }

        public void AddField(string name)
        {
            string query = "INSERT INTO Field (name)VALUES(@name)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.ExecuteNonQuery();
        }
        public void DeleteField(int idField)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Field] WHERE [Id] = @Id", sqlConnection);
            command.Parameters.AddWithValue("Id", idField);
            command.ExecuteNonQuery();
        }
        public void UpdateField(string name,int idField)
        {
            SqlCommand command = new SqlCommand("UPDATE [Field] SET name = @name WHERE Id=@Id", sqlConnection);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("Id", idField);
            command.ExecuteNonQuery();
        }
        
        public void AddWellPad(int idField,int num)
        {
            string query = "INSERT INTO WellPad (num,Field_id)VALUES(@num,@Field_id)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("num", num);
            sqlCommand.Parameters.AddWithValue("Field_id", idField);
            sqlCommand.ExecuteNonQuery();
        }
        public void UpdateWellPad(int num,int idWellPad)
        {
            string query = "UPDATE  WellPad Set num = @num WHERE WellPad_id =@WellPad_id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("num", num);
            sqlCommand.Parameters.AddWithValue("WellPad_id", idWellPad);
            sqlCommand.ExecuteNonQuery();
        }
        public void DeleteWellPad(int idWellPad)
        {
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM [WellPad] WHERE [WellPad_id] = @WellPad_id", sqlConnection);
            sqlcommand.Parameters.AddWithValue("WellPad_id", idWellPad);
            sqlcommand.ExecuteNonQuery();
        }

        public void AddWell(int idWellPad,int num, string wellType)
        {
            string query = "INSERT INTO Well (num,wellType,WellPad_id)VALUES(@num,@wellType,@WellPad_id)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("num", num);
            sqlCommand.Parameters.AddWithValue("wellType", wellType);
            sqlCommand.Parameters.AddWithValue("WellPad_id", idWellPad);
            sqlCommand.ExecuteNonQuery();
        }
        public void UpdateWell(int num, string wellType,int idWell)
        {
            string query = "UPDATE  Well Set num = @num,wellType = @wellType WHERE Well_id =@Well_id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("num", num);
            sqlCommand.Parameters.AddWithValue("wellType", wellType);
            sqlCommand.Parameters.AddWithValue("Well_id", idWell);
            sqlCommand.ExecuteNonQuery();
        }
        public void DeleteWell(int idWell)
        {
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM [Well] WHERE [Well_id] = @Well_id", sqlConnection);
            sqlcommand.Parameters.AddWithValue("Well_id", idWell);
            sqlcommand.ExecuteNonQuery();
        }

        public void AddPhysChar(int idWell,string name,string signal)
        {
            string query = "INSERT INTO PhysChar (name,signal,Well_id)VALUES(@name,@signal,@Well_id)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.Parameters.AddWithValue("signal", signal);
            sqlCommand.Parameters.AddWithValue("Well_id", idWell);
            sqlCommand.ExecuteNonQuery();
        }
        public void UpdatePhysChar(string name, string signal, int idPhysChar)
        {
            string query = "UPDATE  PhysChar Set name = @name,signal = @signal WHERE PhysChar_id =@PhysChar_id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.Parameters.AddWithValue("signal", signal);
            sqlCommand.Parameters.AddWithValue("PhysChar_id", idPhysChar);
            sqlCommand.ExecuteNonQuery();
        }
        public void DeletePhysChar(int idPhysChar)
        {
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM PhysChar WHERE PhysChar_id = @PhysChar_id", sqlConnection);
            sqlcommand.Parameters.AddWithValue("PhysChar_id", idPhysChar);
            sqlcommand.ExecuteNonQuery();
        }
        public int CalculationSignal(string typeSignal, int idWellPad)
        {
            int count = 0;
            string query = "SELECT WellPad.WellPad_id, COUNT(*) AS SignalCount " +
              "FROM PhysChar JOIN Well ON PhysChar.Well_id = Well.Well_id JOIN WellPad ON Well.WellPad_id = WellPad.WellPad_id "+
                    "Where PhysChar.signal = '" + typeSignal + "' AND WellPad.WellPad_id =" + idWellPad+
                    "GROUP BY  WellPad.WellPad_id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                count =  (int)dataReader[1];
            }
            dataReader.Close();
            return count;
        }

        public int CalculationWell(string typeWell,int idWellPad)
        {
            string query = "SELECT COUNT(*) FROM Well WHERE Well.WellPad_id  = " + idWellPad + "  AND Well.wellType = '" + typeWell + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            int dob = 0;
            while (dataReader.Read())
            {
                dob = (int)dataReader[0];
            }
            dataReader.Close();
            return dob;
        }
        public List<string[]> CalculationCabinet(int AIrez, int DIrez,int AOrez,int DOrez, int RS485PLKrez,int RS485SHLrez)
        {
            string query3 = "SELECT * FROM TOS";
            SqlCommand sqlCommand3 = new SqlCommand(query3, sqlConnection);
            SqlDataReader reader = sqlCommand3.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                if ((int)reader[2] > AIrez && (int)reader[3] > AOrez &&
                    (int)reader[4] > DIrez && (int)reader[5] > DOrez &&
                    (int)reader[6] > RS485PLKrez && (int)reader[7] > RS485SHLrez)
                {
                    data.Add(new string[7]);
                    data[data.Count - 1][0] = reader[1].ToString();
                    data[data.Count - 1][1] = reader[2].ToString();
                    data[data.Count - 1][2] = reader[3].ToString();
                    data[data.Count - 1][3] = reader[4].ToString();
                    data[data.Count - 1][4] = reader[5].ToString();
                    data[data.Count - 1][5] = reader[6].ToString();
                    data[data.Count - 1][6] = reader[7].ToString();
                }
            }
            reader.Close();
            return data;
        }
    }
}
