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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Посади". При необходимости она может быть перемещена или удалена.
            this.посадиTableAdapter.Fill(this.аеропортDataSet.Посади);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.посадиBindingSource.EndEdit();

                    АеропортDataSet.ПосадиDataTable deletedTable = (АеропортDataSet.ПосадиDataTable)
                        аеропортDataSet.Посади.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.ПосадиDataTable newTable = (АеропортDataSet.ПосадиDataTable)
                        аеропортDataSet.Посади.GetChanges(DataRowState.Added);

                    АеропортDataSet.ПосадиDataTable modifiedTable = (АеропортDataSet.ПосадиDataTable)
                        аеропортDataSet.Посади.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            посадиTableAdapter.Update(deletedTable);
                        }

                        // Update the Customers table.
                        посадиTableAdapter.Update(аеропортDataSet.Посади);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            посадиTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            посадиTableAdapter.Update(modifiedTable);
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
