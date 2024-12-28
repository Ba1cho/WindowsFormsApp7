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
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();
        public Form2()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string clientName = textBox6.Text;
            string contactInfo = textBox8.Text;

            // Проверяем, что поля не пустые
            if (string.IsNullOrEmpty(clientName) || string.IsNullOrEmpty(contactInfo))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string queryString = "INSERT INTO Клиенты (Имя_клиента, Контактная_информация) VALUES (@Name, @ContactInfo)";

            try
            {
                using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnect()))
                {
                    dataBase.openConection();
                    command.Parameters.AddWithValue("@Name", clientName);
                    command.Parameters.AddWithValue("@ContactInfo", contactInfo);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Клиент успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBase.closeConection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string contractName = textBox3.Text;
            string contractNumber = textBox1.Text;
            DateTime signDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            string status = textBox2.Text;
            string clientName = textBox6.Text;
            string contactInfo = textBox8.Text;
            string legallytName = textBox5.Text;
            string employeeName = textBox4.Text;
            decimal amount = decimal.Parse(textBox7.Text);

            if (string.IsNullOrEmpty(contractName) || string.IsNullOrEmpty(contractNumber) || string.IsNullOrEmpty(contractNumber) || string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(contactInfo) || string.IsNullOrEmpty(clientName) || string.IsNullOrEmpty(legallytName))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int legallyID = -1;
            int clientNameID = -1;
            int employeeNameID = -1;
            int idDogovor = -1;


            //отдел
            try
            {
                string legallyqueryString = "SELECT ID_отдела FROM Отделы WHERE Название_отдела = @Name";
                using (SqlCommand command = new SqlCommand(legallyqueryString, dataBase.getConnect()))
                {
                    dataBase.openConection();
                    command.Parameters.AddWithValue("@Name", legallytName);

                    // Выполняем запрос и получаем результат
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        legallyID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске отдела: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConection();
            }
            // клиент
            try
            {
                string ClientllyqueryString = "SELECT ID_клиента FROM Клиенты WHERE Имя_клиента = @Name";
                using (SqlCommand command1 = new SqlCommand(ClientllyqueryString, dataBase.getConnect()))
                {
                    dataBase.openConection();
                    command1.Parameters.AddWithValue("@Name", clientName);

                    // Выполняем запрос и получаем результат
                    object result = command1.ExecuteScalar();
                    if (result != null)
                    {
                        clientNameID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConection();
            }
            //сотрудники
            try
            {
                string EmployequeryString = "SELECT ID_сотрудника FROM Сотрудники WHERE Имя_сотрудника = @Name";
                using (SqlCommand command = new SqlCommand(EmployequeryString, dataBase.getConnect()))
                {
                    dataBase.openConection();
                    command.Parameters.AddWithValue("@Name", employeeName);

                    // Выполняем запрос и получаем результат
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        employeeNameID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConection();
            }
            if (legallyID >= 0 && clientNameID >= 0 && employeeNameID >= 0)
            {
                string queryStringDogovorADD = "INSERT INTO Договоры2 (Название_договора, Номер_договора, Дата_подписания, Срок_действия, Сумма_договора, Статус) VALUES (@Name, @Number, @SignDate, @EndDate, @Amount, @Status)";
                try
                {
                    
                    using (SqlCommand command = new SqlCommand(queryStringDogovorADD, dataBase.getConnect()))
                    {

             
                        dataBase.openConection();
                        command.Parameters.AddWithValue("@Name", contractName);
                        command.Parameters.AddWithValue("@Number", contractNumber);
                        command.Parameters.AddWithValue("@SignDate", signDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Status", status);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Договор успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataBase.closeConection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataBase.closeConection();
                }

                string queryStringDogovor = "SELECT ID_договора FROM Договоры2 WHERE Название_договора = @Name";
                try
                {
                    using (SqlCommand command = new SqlCommand(queryStringDogovor, dataBase.getConnect()))
                    {
                        dataBase.openConection();
                        command.Parameters.AddWithValue("@Name", contractName);
                        // Выполняем запрос и получаем результат
                        object result = command.ExecuteScalar();
                        dataBase.closeConection();
                        if (result != null)
                        {
                            
                            
                            idDogovor = Convert.ToInt32(result);
                            string queryStringPartic = "INSERT INTO Участники_договора (ID_договора, ID_клиента, ID_сотрудника, ID_отдела) VALUES (@ContractId, @ClientId, @EmployeeId, @DepartmentId)";

                            try
                            {
                                using (SqlCommand commandPartic = new SqlCommand(queryStringPartic, dataBase.getConnect()))
                                {
                                    dataBase.openConection();
                                    command.Parameters.AddWithValue("@ContractId", idDogovor);
                                    command.Parameters.AddWithValue("@ClientId", clientNameID);
                                    command.Parameters.AddWithValue("@EmployeeId", employeeNameID);
                                    command.Parameters.AddWithValue("@DepartmentId", legallyID);

                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Участник договора успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                dataBase.closeConection();
                            }

                        }
                        dataBase.closeConection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при поиске договора: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataBase.closeConection();
                }
            }
            else
            {
                MessageBox.Show($"Ошибка при добавлении: Не все данные введены");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
