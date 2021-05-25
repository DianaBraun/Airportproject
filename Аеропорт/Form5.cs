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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аеропортDataSet.Клас". При необходимости она может быть перемещена или удалена.
            this.класTableAdapter.Fill(this.аеропортDataSet.Клас);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    {
                        this.Validate();
                        this.класBindingSource.EndEdit();

                        АеропортDataSet.КласDataTable deletedTable = (АеропортDataSet.КласDataTable)
                            аеропортDataSet.Клас.GetChanges(DataRowState.Deleted);

                        АеропортDataSet.КласDataTable newTable = (АеропортDataSet.КласDataTable)
                            аеропортDataSet.Клас.GetChanges(DataRowState.Added);

                        АеропортDataSet.КласDataTable modifiedTable = (АеропортDataSet.КласDataTable)
                            аеропортDataSet.Клас.GetChanges(DataRowState.Modified);

                        try
                        {
                            // Remove all deleted orders from the Orders table.
                            if (deletedTable != null)
                            {
                                класTableAdapter.Update(deletedTable);
                            }

                            // Update the Customers table.
                            класTableAdapter.Update(аеропортDataSet.Клас);

                            // Add new orders to the Orders table.
                            if (newTable != null)
                            {
                                класTableAdapter.Update(newTable);
                            }

                            // Update all modified Orders.
                            if (modifiedTable != null)
                            {
                                класTableAdapter.Update(modifiedTable);
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
