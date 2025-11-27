using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class frmListContacts : Form
    {
        DataTable _AllContacts;

        public frmListContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = _AllContacts;
        }

       

        private void dgvAllContacts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show(dgvAllContacts.CurrentRow.Cells[0].Value.ToString());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            frmAddEditContact frm = new frmAddEditContact((int) dgvAllContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            
            _RefreshContactsList();


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
          if(  MessageBox.Show("Are you sure you want to delete contact [" + dgvAllContacts.CurrentRow.Cells[0].Value + "]","Confirm Delete",MessageBoxButtons.OKCancel)==DialogResult.OK)

            {

                //Perform Delele and refresh
               if( clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactsList();
                } 

               else
                    MessageBox.Show("Contact is not deleted.");

            }
          

        }

        private void frmListContacts_Load(object sender, EventArgs e)
        {
            _AllContacts = clsContact.GetAllContacts();

            _RefreshContactsList();

            if (dgvAllContacts.Rows.Count > 0)
            {
                dgvAllContacts.Columns[0].HeaderText = "Contact ID";
                dgvAllContacts.Columns[0].Width = 121;

                dgvAllContacts.Columns[1].HeaderText = "First Name";
                dgvAllContacts.Columns[1].Width = 122;

                dgvAllContacts.Columns[2].HeaderText = "Last Name";
                dgvAllContacts.Columns[2].Width = 121;

                dgvAllContacts.Columns[3].HeaderText = "Email";
                dgvAllContacts.Columns[3].Width = 121;

                dgvAllContacts.Columns[4].HeaderText = "Phone";
                dgvAllContacts.Columns[4].Width = 122;

                dgvAllContacts.Columns[5].HeaderText = "Address";
                dgvAllContacts.Columns[5].Width = 122;

                dgvAllContacts.Columns[6].HeaderText = "Date Of Birth";
                dgvAllContacts.Columns[6].Width = 121;

                dgvAllContacts.Columns[7].HeaderText = "Country ID";
                dgvAllContacts.Columns[7].Width = 121;

                dgvAllContacts.Columns[8].HeaderText = "Image Path";
                dgvAllContacts.Columns[8].Width = 122;
            }
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(-1);
            frm.ShowDialog();
            _RefreshContactsList();
        }
    }
}
