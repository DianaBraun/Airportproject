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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Рейс". При необходимости она может быть перемещена или удалена.
            this.рейсTableAdapter.Fill(this.аеропортDataSet.Рейс);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.рейсBindingSource.EndEdit();

                    АеропортDataSet.РейсDataTable deletedTable = (АеропортDataSet.РейсDataTable)
                        аеропортDataSet.Рейс.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.РейсDataTable newTable = (АеропортDataSet.РейсDataTable)
                        аеропортDataSet.Рейс.GetChanges(DataRowState.Added);

                    АеропортDataSet.РейсDataTable modifiedTable = (АеропортDataSet.РейсDataTable)
                        аеропортDataSet.Рейс.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            рейсTableAdapter.Update(deletedTable);
                        }

                        // Update the Customers table.
                        рейсTableAdapter.Update(аеропортDataSet.Рейс);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            рейсTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            рейсTableAdapter.Update(modifiedTable);
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
