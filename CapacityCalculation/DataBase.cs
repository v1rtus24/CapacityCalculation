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
        private Cabinet cabinet;
        public SqlConnection sqlConnection { get; set; }

        private readonly string ConnectionString= @"Data Source=.\SQLEXPRESS;
                                                        Initial Catalog=DBof;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DataBase()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            cabinet = new Cabinet();
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
    }
}
