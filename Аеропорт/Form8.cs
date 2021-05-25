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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Пасажир". При необходимости она может быть перемещена или удалена.
            this.пасажирTableAdapter.Fill(this.аеропортDataSet.Пасажир);

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.пасажирBindingSource.EndEdit();

                    АеропортDataSet.ПасажирDataTable deletedTable = (АеропортDataSet.ПасажирDataTable)
                        аеропортDataSet.Пасажир.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.ПасажирDataTable newTable = (АеропортDataSet.ПасажирDataTable)
                        аеропортDataSet.Пасажир.GetChanges(DataRowState.Added);

                    АеропортDataSet.ПасажирDataTable modifiedTable = (АеропортDataSet.ПасажирDataTable)
                        аеропортDataSet.Пасажир.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            пасажирTableAdapter.Update(deletedTable);
                        }

                        // Update the Customers table.
                        пасажирTableAdapter.Update(аеропортDataSet.Пасажир);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            пасажирTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            пасажирTableAdapter.Update(modifiedTable);
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
