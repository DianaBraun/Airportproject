using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аеропорт
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Країна". При необходимости она может быть перемещена или удалена.
            this.країнаTableAdapter.Fill(this.аеропортDataSet.Країна);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.країнаBindingSource.EndEdit();

                    АеропортDataSet.КраїнаDataTable deletedTable = (АеропортDataSet.КраїнаDataTable)
                        аеропортDataSet.Країна.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.КраїнаDataTable newTable = (АеропортDataSet.КраїнаDataTable)
                        аеропортDataSet.Країна.GetChanges(DataRowState.Added);

                    АеропортDataSet.КраїнаDataTable modifiedTable = (АеропортDataSet.КраїнаDataTable)
                        аеропортDataSet.Країна.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            країнаTableAdapter.Update(deletedTable);
                        }

                        // Update the Customers table.
                        країнаTableAdapter.Update(аеропортDataSet.Країна);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            країнаTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            країнаTableAdapter.Update(modifiedTable);
                        }

                        аеропортDataSet.AcceptChanges();
                    }

                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Update");
                    }

                    finally
                    {
                        if (deletedTable != null)
                        {
                            deletedTable.Dispose();
                        }
                        if (newTable != null)
                        {
                            newTable.Dispose();
                        }
                        if (modifiedTable != null)
                        {
                            modifiedTable.Dispose();
                        }
                    }
                }
            }
        }
    }
}
