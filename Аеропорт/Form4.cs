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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Owner = this;
            f14.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Квиток". При необходимости она может быть перемещена или удалена.
            this.квитокTableAdapter.Fill(this.аеропортDataSet.Квиток);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    {
                        this.Validate();
                        this.квитокBindingSource.EndEdit();

                        АеропортDataSet.КвитокDataTable deletedTable = (АеропортDataSet.КвитокDataTable)
                            аеропортDataSet.Квиток.GetChanges(DataRowState.Deleted);

                        АеропортDataSet.КвитокDataTable newTable = (АеропортDataSet.КвитокDataTable)
                            аеропортDataSet.Квиток.GetChanges(DataRowState.Added);

                        АеропортDataSet.КвитокDataTable modifiedTable = (АеропортDataSet.КвитокDataTable)
                            аеропортDataSet.Квиток.GetChanges(DataRowState.Modified);

                        try
                        {
                            // Remove all deleted orders from the Orders table.
                            if (deletedTable != null)
                            {
                                квитокTableAdapter.Update(deletedTable);
                            }

                            // Update the Customers table.
                            квитокTableAdapter.Update(аеропортDataSet.Квиток);

                            // Add new orders to the Orders table.
                            if (newTable != null)
                            {
                                квитокTableAdapter.Update(newTable);
                            }

                            // Update all modified Orders.
                            if (modifiedTable != null)
                            {
                                квитокTableAdapter.Update(modifiedTable);
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
}
