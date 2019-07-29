using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Suppliers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void suppliersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.suppliersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.travelExpertsDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Products_Suppliers' table. You can move, or remove it, as needed.
            this.products_SuppliersTableAdapter.Fill(this.travelExpertsDataSet.Products_Suppliers);
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.travelExpertsDataSet.Products);
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.travelExpertsDataSet.Suppliers);

            GetProducts();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }
        
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void supplierIdTextBox_TextChanged(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void GetProducts()
        {
            if (Int32.TryParse(supplierIdTextBox.Text, out int SupplierId))
            {
                dgvProducts.DataSource = Products_SuppliersDB.GetProductsBySupplier(SupplierId);
            }
        }

    }
}
