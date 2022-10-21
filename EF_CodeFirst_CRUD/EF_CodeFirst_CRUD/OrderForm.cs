using EF_CodeFirst_CRUD.DAL.Context;
using EF_CodeFirst_CRUD.DAL.Entities;
using EF_CodeFirst_CRUD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_CRUD
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
            gridOrderDetail.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
            gridOrderDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOrderDetail.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridOrderDetail.MultiSelect = false;
              
            var productColumn = new DataGridViewTextBoxColumn();
            productColumn.Name = "ProductName";
            productColumn.HeaderText = "Ürün Adı";
            productColumn.DataPropertyName = "ProductName";

            var unitPriceColumn = new DataGridViewTextBoxColumn();
            unitPriceColumn.Name = "UnitPrice";
            unitPriceColumn.HeaderText = "Fiyat";
            unitPriceColumn.DataPropertyName = "UnitPrice";    
            
            var quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            quantityColumn.HeaderText = "Miktar";
            quantityColumn.DataPropertyName = "Quantity"; 
            
            var discountedColumn = new DataGridViewTextBoxColumn();
            discountedColumn.Name = "Discount";
            discountedColumn.HeaderText = "İndirim Oranı";
            discountedColumn.DataPropertyName = "Discount";

            gridOrderDetail.Columns.Add(productColumn);
            gridOrderDetail.Columns.Add(unitPriceColumn);
            gridOrderDetail.Columns.Add(quantityColumn);
            gridOrderDetail.Columns.Add(discountedColumn);
        }

        /// <summary>
        ///  //order detail dto nesnesini dolduruyoruz burda--- Doldurulması gereken her yerde method olarak kullanabilelim diye
        /// </summary>
        private void FillOrderDetailGrid()
        {
           
            int orderId = Convert.ToInt32(this.Tag);
            using (CrmContext db=new CrmContext())
            {
                var orderDetails = db.OrderDetail.Where(x => x.OrderId == orderId).Select(x => new OrderDetailDTO()
                {
                    ProductId = x.ProductId,
                    Discount = x.Discount,
                    OrderDetailId = x.OrderDetailId,
                    UnitPrice = x.Price,
                    Quantity = x.Quantity,
                    ProductName = x.Product.ProductName

                }).ToList() ;
                gridOrderDetail.DataSource = null;
                gridOrderDetail.DataSource = orderDetails;
            }
        }

        private void FillForm()
        {
            int orderId = Convert.ToInt32(this.Tag);
            if (orderId>0)
            {
                using (CrmContext db=new CrmContext())
                {
                   var result= db.Order.FirstOrDefault(x => x.OrderId == orderId);
                    if (result!=null)
                    {
                        dtpOrderDate.Value = Convert.ToDateTime(result.OrderDate);
                        cmbCustomers.SelectedValue=result.CustmerId;
                        txtOrderCode.Text=result.OrderCode;
                    }
                }
                FillOrderDetailGrid();
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
                var result = db.Product.Select(x => new { Value = x.ProductId, Text = x.ProductName }).ToList();
                cmbProduct.DisplayMember = "Text";
                cmbProduct.ValueMember = "Value";
                cmbProduct.DataSource = result;

            }
        }

        private void FillCustomer()
        {
            using (CrmContext db= new CrmContext())
            {
                var result = db.Customer.Select(x => new { Value = x.CustomerId, Text = x.CustomerName }).ToList();
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
            cmbCustomers.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            nuPrice.Value = 0;
            nuDiscount.Value = 0;
            nuQuantity.Value = 0;
            //ALt grid i temizle
            gridOrderDetail.DataSource = null;
            this.Tag = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            int orderId = Convert.ToInt32(this.Tag);

            try
            {
                using (CrmContext db = new CrmContext())
                {
                    Order? order = null;
                    if (orderId == 0)
                    {
                        //yeni sipariş ekleme durumunda order code Generate et
                        order = new Order();
                        order.OrderCode=Guid.NewGuid().ToString();  

                        db.Order.Add(order);

                    }
                    else
                    {
                        order = db.Order.FirstOrDefault(p => p.OrderId == orderId);
                    }

                    if (order != null)
                    {
                        order.OrderDate=dtpOrderDate.Value;
                        order.CustmerId = Convert.ToInt32(cmbCustomers.SelectedValue);
                    }
                    db.SaveChanges();
                    this.Tag = order.OrderId;
                    MessageBox.Show("Kayıt Başarılı");
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
       
    }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderDetailAdd();
            OrderDetailControlClear();
        }

        private void OrderDetailAdd()
        {
            if (OrderDetailValidation())
            {
                using (CrmContext db=new CrmContext())
                {
                    OrderDetail orderDetail = null;
                    if (selectedOrderDetailID==0)
                    {
                        orderDetail = new OrderDetail();
                        db.OrderDetail.Add(orderDetail);
                    }
                    else
                    {
                        orderDetail = db.OrderDetail.FirstOrDefault(x => x.OrderDetailId == selectedOrderDetailID);
                    }
                    
                    orderDetail.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
                    orderDetail.Price=nuPrice.Value;
                    orderDetail.Discount = Convert.ToSingle(nuDiscount.Value);
                    orderDetail.Quantity=Convert.ToSingle(nuQuantity.Value);
                    orderDetail.OrderId = Convert.ToInt32(this.Tag);
                    db.SaveChanges();
                    
                }
                FillOrderDetailGrid();
            }
        }

        public bool OrderDetailValidation()
        {
            bool result = true;
            int orderId = Convert.ToInt32(this.Tag);

            if (orderId<=0)
            {
                result = false;
                MessageBox.Show("İlk Başta sipariş kaydedilmelidir.");
            }
            if (cmbProduct.SelectedIndex<=-1)
            {
                result = false;
                MessageBox.Show("Ürün seçimi yapılmamış. Eklemeden önce ürün seçimi yapınız");
            }
            return result; ;
        }

        private void OrderDetailControlClear()
        {
            cmbProduct.SelectedIndex = -1;
            nuDiscount.Value = 0;
            nuQuantity.Value = 0;
            nuPrice.Value = 0;
            selectedOrderDetailID = 0;
        }

        private void btnDeletee_Click(object sender, EventArgs e)
        {
            OrderDetailDelete();
        }

        private void OrderDetailDelete()
        {
            if (gridOrderDetail.SelectedRows.Count>0)
            {
                int index = gridOrderDetail.SelectedRows[0].Index;

                if (gridOrderDetail.DataSource != null)
                {
                    var result = (gridOrderDetail.DataSource as List<OrderDetailDTO>)[index];
                    var dialog=MessageBox.Show("Seçilen satırı silmek istiyor musunuz?","CRM",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

                    if (dialog==DialogResult.OK)
                    {
                        using (CrmContext db=new CrmContext())
                        {
                            var orderDetailItem = db.OrderDetail.FirstOrDefault(x => x.OrderDetailId == result.OrderDetailId);
                            if (orderDetailItem!=null)
                            {
                                db.OrderDetail.Remove(orderDetailItem);
                                db.SaveChanges();
                                FillOrderDetailGrid();
                            }
                        }
                    }
                }          
            }
        }

        int selectedOrderDetailID = 0;
        private void gridOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {

                int orderDetailId = ((gridOrderDetail.DataSource as List<OrderDetailDTO>)[e.RowIndex]).OrderDetailId;
                if (orderDetailId>0)
                {
                    using (CrmContext DB = new CrmContext())
                    {

                        var orderDetail = DB.OrderDetail.FirstOrDefault(x => x.OrderDetailId == orderDetailId);
                        if (orderDetail!=null)
                        {
                            cmbProduct.SelectedValue = orderDetail.ProductId;
                            nuPrice.Value = Convert.ToDecimal(orderDetail.Price);
                            nuQuantity.Value = Convert.ToDecimal(orderDetail.Quantity);
                            nuDiscount.Value = Convert.ToDecimal(orderDetail.Discount);
                            selectedOrderDetailID=orderDetail.OrderDetailId;
                        }
                    }
                }
            }
        }
    }
}
