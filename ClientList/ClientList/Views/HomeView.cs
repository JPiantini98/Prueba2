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

namespace ClientList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        #region HELPERS
        private void Refresh()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                var lst = from d in db.Clients
                          select d;

                dataGridView1.DataSource = lst.ToList();
            }
        }

        private int GetRowId()
        {
            return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Views.NewClient newClientView = new Views.NewClient();
            newClientView.ShowDialog();

            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetRowId();
            if (id != null)
            {
                Views.NewClient newClientView = new Views.NewClient(id);
                newClientView.ShowDialog();
            }

            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetRowId();
            if (id != null)
            {
                using ( CRUDEntities db = new CRUDEntities())
                {
                    Client clientTable = db.Clients.Find(id);
                    db.Clients.Remove(clientTable);
                    db.SaveChanges();
                    MessageBox.Show("Eliminado exitosamente", "Alerta", MessageBoxButtons.OK);
                }
            }

            Refresh();
        }
    }
}
