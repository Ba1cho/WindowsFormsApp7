using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form3 : Form
    {
        DataBase dataBase = new DataBase();
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var FIO = textBox2.Text;
            var post_job = textBox3.Text;
            var nuber_Brigade = textBox5.Text;

            if (  string.IsNullOrEmpty(FIO) || string.IsNullOrEmpty(post_job) || string.IsNullOrEmpty(nuber_Brigade))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL-запрос для добавления сотрудника
           // string query = "INSERT INTO Сотрудники (Имя_сотрудника, Должность, Контактная_информация) VALUES (@Name = '{FIO}', @Position = '{post_job}', @ContactInfo = 'nuber_Brigade')";

            // Выполнение запроса
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = "INSERT INTO Сотрудники (Имя_сотрудника, Должность, Контактная_информация) VALUES (@Name, @Position, @ContactInfo)";
            using (SqlCommand command = new SqlCommand(querystring, dataBase.getConnect()))
            {
                // Добавляем параметры для защиты от SQL-инъекций
                dataBase.openConection();
                command.Parameters.AddWithValue("@Name", FIO);
                command.Parameters.AddWithValue("@Position", post_job);
                command.Parameters.AddWithValue("@ContactInfo", nuber_Brigade);

                // Выполняем запрос
                command.ExecuteNonQuery();
                MessageBox.Show("Сотрудник успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataBase.closeConection();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string departmentName = textBox4.Text;

            // Проверяем, что поле не пустое
            if (string.IsNullOrEmpty(departmentName))
            {
                MessageBox.Show("Введите название отдела!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL-запрос для добавления отдела
            string queryString = "INSERT INTO Отделы (Название_отдела) VALUES (@Name)";

            try
            {
                using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnect()))
                {
                    dataBase.openConection();
                    command.Parameters.AddWithValue("@Name", departmentName);

                    // Выполняем запрос
                    command.ExecuteNonQuery();
                    MessageBox.Show("Отдел успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBase.closeConection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string employeeName = textBox2.Text;

            // Проверяем, что поле имени не пустое
            if (string.IsNullOrEmpty(employeeName))
            {
                MessageBox.Show("Введите имя сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL-запрос для удаления сотрудника по имени
            string queryString = "DELETE FROM Сотрудники WHERE Имя_сотрудника = @Name";

            try
            {
                // Создаем команду для выполнения SQL-запроса
                using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnect()))
                {
                    // Открываем соединение с базой данных
                    dataBase.openConection();

                    // Добавляем параметр для защиты от SQL-инъекций
                    command.Parameters.AddWithValue("@Name", employeeName);

                    // Выполняем запрос
                    int rowsAffected = command.ExecuteNonQuery();

                    // Проверяем, была ли удалена хотя бы одна запись
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Сотрудник успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Сотрудник с таким именем не найден.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Закрываем соединение с базой данных
                    dataBase.closeConection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
