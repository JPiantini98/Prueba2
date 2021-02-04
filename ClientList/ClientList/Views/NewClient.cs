using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientList.Models;

namespace ClientList.Views
{
    public partial class NewClient : Form
    {
        public int? id;
        Client clientTable = null;

        public NewClient(int? id = null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
            {
                LoadData();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                if (id == null)
                {
                    clientTable = new Client();
                }

                clientTable.name = txtName.Text;
                clientTable.lastname = txtLastname.Text;
                clientTable.cedula = txtCedula.Text;
                clientTable.age = Decimal.ToInt32(numAge.Value);

                if (id == null)
                {
                    db.Clients.Add(clientTable);
                }else
                {
                    db.Entry(clientTable).State = System.Data.Entity.EntityState.Modified;
                }

                
                db.SaveChanges();

                this.Close();
            }
        }

        private void LoadData()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                clientTable = db.Clients.Find(id);

                txtName.Text = clientTable.name;
                txtLastname.Text = clientTable.lastname;
                txtCedula.Text = clientTable.cedula;
                numAge.Value = clientTable.age;


            }
        }

        private void txtCedulaPressed(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Valor Inválido, solo se permite números.", "Error", MessageBoxButtons.OK);
            }
        }

        
    }
}
