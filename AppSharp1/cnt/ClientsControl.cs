using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace AppSharp1
{
    public partial class ClientsControl : UserControl, PageInterface
    {
        private List<ClientItem> clients = new List<ClientItem>();

        public ClientsControl()
        {
            InitializeComponent();
            LoadClients();
        }

        public Page getPage()
        {
            return Page.Clients;
        }

        private void LoadClients()
        {
            clients.Clear();
            ClientsListBox.Items.Clear();

            try
            {
                var cmd = new NpgsqlCommand("SELECT id, name FROM clients ORDER BY id", DataBase.Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var client = new ClientItem(reader.GetInt32(0), reader.GetString(1));
                    clients.Add(client);
                }

                reader.Close();

                foreach (var client in clients)
                {
                    ClientsListBox.Items.Add(client.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            string name = clientNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cmd = new NpgsqlCommand("INSERT INTO clients(name) VALUES (@name)", DataBase.Connection);
                cmd.Parameters.AddWithValue("name", name);
                cmd.ExecuteNonQuery();

                clientNameTextBox.Clear();
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveClient_Click(object sender, EventArgs e)
        {
            int selectedIndex = ClientsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select a client!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var client = clients[selectedIndex];

            try
            {
                var cmd = new NpgsqlCommand("DELETE FROM clients WHERE id = @id", DataBase.Connection);
                cmd.Parameters.AddWithValue("id", client.Id);
                cmd.ExecuteNonQuery();

                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to remove client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class ClientItem
        {
            public int Id { get; }
            public string Name { get; }

            public ClientItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public string GetDisplay()
            {
                return $"{Id} - {Name}";
            }

            public override string ToString()
            {
                return GetDisplay();
            }
        }

        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            string name = clientNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = ClientsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select a client!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var client = clients[selectedIndex];

            try
            {
                var cmd = new NpgsqlCommand("UPDATE clients SET name = @name WHERE id = @cid", DataBase.Connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cid", client.Id);
                cmd.ExecuteNonQuery();

                clientNameTextBox.Clear();
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
