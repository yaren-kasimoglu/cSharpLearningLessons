using EFCore_CodeFirst_Application.DAL.Context;
using EFCore_CodeFirst_Application.DAL.Entities;
using EFCore_CodeFirst_Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCore_CodeFirst_Application
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            FillControl();
            FillOrderDetailGridLayout();
            FillForm();         
        }

        private void FillOrderDetailGridLayout()
        {
            gridOrderDetail.AutoGenerateColumns = false;
            gridOrderDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var productColumn = new DataGridViewTextBoxColumn();
            productColumn.Name = "ProductName";
            productColumn.HeaderText = "Ürün Adı";
            productColumn.DataPropertyName = "ProductName";

            var unirPticeColumn = new DataGridViewTextBoxColumn();
            unirPticeColumn.Name = "UnitPrice";
            productColumn.HeaderText = "Fiyatı";
            unirPticeColumn.DataPropertyName = "UnitPrice";

            var quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            productColumn.HeaderText = "Miktarı";
            quantityColumn.DataPropertyName = "Quantity";

            var discountedColumn = new DataGridViewTextBoxColumn();
            discountedColumn.Name = "Discount";
            productColumn.HeaderText = "İndirim Oranı";
            discountedColumn.DataPropertyName = "Discount";

            gridOrderDetail.Columns.Add(productColumn);
            gridOrderDetail.Columns.Add(unirPticeColumn);
            gridOrderDetail.Columns.Add(quantityColumn);
            gridOrderDetail.Columns.Add(discountedColumn);
        }

        private void FillForm()
        {
            int orderID = Convert.ToInt32(this.Tag);
            if (orderID>0)
            {
                using (CrmContext db=new CrmContext())
                {
                    var result = db.Order.FirstOrDefault(o => o.OrderId == orderID);

                    if (result!=null)
                    {
                        dtpOrderDate.Value = Convert.ToDateTime(result.OrderDate);
                        cmbCustomers.SelectedValue = result.CustomerId;
                        txtOrderCode.Text = result.OrderCode;
                    }
                }
                FillOrderDetailGrid();
            }
        }

        private void FillOrderDetailGrid()
        {
            int orderID = Convert.ToInt32(this.Tag);

            using (CrmContext db=new CrmContext())
            {
                var orderDetails = db.OrderDetail.Where(o => o.OrderId == orderID).Select(o => new OrderDetailDTO()
                {
                    ProductId = o.ProductId,
                    Discount = o.Discount,
                    OrderDetailId = o.OrderDetailId,
                    ProductName = o.Product.ProductName,
                    Quantity =o.Quantity,
                    UnitPrice= o.Price

                }).ToList() ;

                gridOrderDetail.DataSource = null;
                gridOrderDetail.DataSource = orderDetails;              
            }
        }

        private void FillControl()
        {
            FillCustomer();
            FillProduct();
        }

        private void FillProduct()
        {
            using (CrmContext db = new CrmContext())
            {
                var result = db.Product.Select(p => new { Value = p.ProductId, Text = p.ProductName }).ToList();
                cmbProduct.DisplayMember = "Text";
                cmbProduct.ValueMember = "Value";
                cmbProduct.DataSource = result;
            }
        }

        private void FillCustomer()
        {
            using (CrmContext db = new CrmContext())
            {
                var result = db.Customer.Select(c => new { Value = c.CustomerId, Text = c.CustomerName }).ToList();
                cmbCustomers.DisplayMember = "Text";
                cmbCustomers.ValueMember = "Value";
                cmbCustomers.DataSource = result;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            txtOrderCode.Text = "";
            dtpOrderDate.Value = DateTime.Now;
            cmbCustomers.SelectedValue = -1;
            cmbProduct.SelectedValue = -1;
            nuDiscount.Value = 0;
            nuPrice.Value = 0;
            nuQuantity.Value = 0;
            //alt detay grid i temizle
            gridOrderDetail.DataSource = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            int orderID = Convert.ToInt32(this.Tag);
            Order order = null;
            try
            {
                using (CrmContext db = new CrmContext())
                {
                    if (orderID == 0)
                    {
                        order = new Order();
                        order.OrderCode = Guid.NewGuid().ToString();
                        db.Order.Add(order);
                    }
                    else
                    {
                        order = db.Order.FirstOrDefault(o => o.OrderId == orderID);
                    }
                    if (order != null)
                    {
                        order.OrderDate = dtpOrderDate.Value;
                        order.CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue);
                    }
                    db.SaveChanges();
                    this.Tag = order.OrderId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();
        }

        private void FormDelete()
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderDetailAdd();
        }

        private void OrderDetailAdd()
        {
            if (OrderDetailValidation())
            {
                using (CrmContext db=new CrmContext())
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.ProductId=Convert.ToInt32(cmbProduct.SelectedValue);
                    orderDetail.Quantity=Convert.ToSingle(nuQuantity.Value);
                    orderDetail.Discount=Convert.ToSingle(nuDiscount.Value);
                    orderDetail.Price = nuPrice.Value;
                    orderDetail.OrderId = Convert.ToInt32(this.Tag);
                    db.OrderDetail.Add(orderDetail);

                }
            }
        }
        public bool OrderDetailValidation()
        {
            bool result = true;
            int orderID = Convert.ToInt32(this.Tag);
            if (orderID<=0)
            {
                result = false;
                MessageBox.Show("İlk başta sipariş kaydedilmelidir");
            }
            if (cmbProduct.SelectedIndex<=-1)
            {
                result = false;
                MessageBox.Show("Ürün seçimi yapılmamış.");
            }

            return result;
        }
    }
}
