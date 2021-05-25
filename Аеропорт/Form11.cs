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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Співробітник". При необходимости она может быть перемещена или удалена.
            this.співробітникTableAdapter.Fill(this.аеропортDataSet.Співробітник);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    this.Validate();
                    this.співробітникBindingSource.EndEdit();

                    АеропортDataSet.СпівробітникDataTable deletedTable = (АеропортDataSet.СпівробітникDataTable)
                        аеропортDataSet.Співробітник.GetChanges(DataRowState.Deleted);

                    АеропортDataSet.СпівробітникDataTable newTable = (АеропортDataSet.СпівробітникDataTable)
                        аеропортDataSet.Співробітник.GetChanges(DataRowState.Added);

                    АеропортDataSet.СпівробітникDataTable modifiedTable = (АеропортDataSet.СпівробітникDataTable)
                        аеропортDataSet.Співробітник.GetChanges(DataRowState.Modified);

                    try
                    {
                        // Remove all deleted orders from the Orders table.
                        if (deletedTable != null)
                        {
                            співробітникTableAdapter.Update(deletedTable);
                        }

                        // Update the Customers table.
                        співробітникTableAdapter.Update(аеропортDataSet.Співробітник);

                        // Add new orders to the Orders table.
                        if (newTable != null)
                        {
                            співробітникTableAdapter.Update(newTable);
                        }

                        // Update all modified Orders.
                        if (modifiedTable != null)
                        {
                            співробітникTableAdapter.Update(modifiedTable);
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
