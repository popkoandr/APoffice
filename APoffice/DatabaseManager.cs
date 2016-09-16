//#define SetProperty
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace APoffice
{
    public static class DatabaseManager
    {
        private static SqlConnection _currentConnection;
        
        public static SqlConnection CurrentConnection
        {
            get
            {
                if (_currentConnection == null)
                {
                    MessageBox.Show("There is no connection to db");
                    return null;
                }
                return _currentConnection;
            }
            private set
            {
                _currentConnection = value;
            }
        }

        /// <summary>
        /// Connect user "Andrew" to APofficeDb
        /// </summary>
        public static void ConnectUserToDatebase()
        {
//#if SetProperty
//            var connectionStringBuilder = new SqlConnectionStringBuilder
//            {
//                Pooling = true,
//                DataSource = @".\SQLEXPRESS",
//                InitialCatalog = "APofficeDB",
//                UserID = "Andrew",
//                Password = "22"
//            }; // создание конструктора строк подключения 
//            // используйте конструктор строк подключения для 
//            // предотвращения изменения пользователем структуры строки подключения
//#else
//            var connectionStringBuilder = new SqlConnectionStringBuilder();
//            connectionStringBuilder["Data Source"] = @".\SQLEXPRESS";   // используйте конструктор строк подключения для 
//            connectionStringBuilder["Initial Catalog"] = "APofficeDB";      // предотвращения изменения пользователем структуры строки подключения
//            connectionStringBuilder["User ID"] = "Andrew";//
//            connectionStringBuilder["Password"] = "22";//
//#endif
//            // test open connection to db
//            using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
//            {
//                try
//                {
//                    connection.StateChange += ConnectionStateChange;
//                    connection.Open();
//                    CurrentConnection = connection; // set Current connection Property 
//                    MessageBox.Show("Connection opened to " + connection.Database);

//                }
//                catch (Exception exception)
//                {
//                    MessageBox.Show(exception.Message);
//                }
//            }
        }

        #region How to use config file
            ///////////////////////////////////////////////////////////////////
            //var setting = new ConnectionStringSettings
            //{
            //    Name = "APoffice_ConnectionString",     //имя строки подключения в конфигурационном файле
            //    ConnectionString = @"Data Source=.\SQLEXPRESS;
            //                         Initial Catalog=APoffice;
            //                         Integrated Security=True;"
            //};

            //Configuration config;  // Объект Config представляет конфигурационный файл
            //config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  // Объект ConfigurationManager предоставляет доступ к файлам конфигурации
            //config.ConnectionStrings.ConnectionStrings.Add(setting);
            //config.Save();

            //MessageBox.Show("Строка подключения записана в конфигурационный файл.");

            //// Получение строки подключения.
            //MessageBox.Show(ConfigurationManager.ConnectionStrings["APoffice_ConnectionString"].ConnectionString);

        
        #endregion
        /// <summary>
        /// Event Handling method for connection state chenge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            var connection = sender as SqlConnection;
            MessageBox.Show("Connection " + connection.State);
        }
        /// <summary>
        /// Example of Insertion to DB
        /// </summary>
        public static void Insert()
        {
            CurrentConnection.Open();
            SqlCommand insertCommand = CurrentConnection.CreateCommand(); // создание команды на вставку данных
            insertCommand.CommandText = "INSERT Customers VALUES ('Alex', 'Petrov', 'Petrovich', 'Заворотная 7', NULL, 'Kiyv', '(063)8569584', '2010-01-01')";

            int rowAffected = insertCommand.ExecuteNonQuery(); // выполнение команды на вставку
            MessageBox.Show("INSERT command rows affected: " + rowAffected);
            CurrentConnection.Close();
        }

        /// <summary>
        /// Example of Deleting from DB
        /// </summary>
        public static void Delete()
        {
            CurrentConnection.Open();
            SqlCommand deleteCommand = CurrentConnection.CreateCommand(); // создание команды на удаление данных
            deleteCommand.CommandText = "DELETE Customers WHERE Phone = '(063)8569584'";

             int rowAffected = deleteCommand.ExecuteNonQuery(); // выполнение команды на удаление
           MessageBox.Show("DELETE command rows affected: " + rowAffected);
        }


    }
}
