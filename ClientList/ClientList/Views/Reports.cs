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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            getClientsNum();
            getClientsPerAge();
            
        }

        private void getClientsNum()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                lblClientsNum.Text = db.Clients.Count().ToString();
            }
        }

        private void getClientsPerAge()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                var clientData =
                    from clientTable in db.Clients
                    select clientTable.age;

                dataGridReports.DataSource = clientData.ToList();
            }
        }


        private void Reports_Load(object sender, EventArgs e)
        {

        }
    }
}
